using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    /// <summary>
    /// Class Table is the main hub for this black jack application.
    /// 
    /// Connects decks and participants.
    /// Receives and forwards events from deck and participants.
    /// Dictates the gameplay.
    /// </summary>
    public class Table
    {
        private Deck m_deck;
        private TableRules m_tableRules;
        private Dictionary<int, Participant> m_participantRecord; //This dictionary links participants to a table position
                                                                  //The key (int) is the table position.
        private Dictionary<int, List<Hand>> m_handRecord; //This dictionary links hands to a table position.
                                                          //The key (int) is the table position 
        private int m_handId;       //Id to record number of played hands
        private int m_activeHandId; //Id to identify which hand is being played
        private int m_gameId;       //Id to identify the game

        private bool m_gameIsOngoing;

        private bool m_humanInteraction; //Whether or not to allow messageboxes

        /// <summary>
        /// Constructor
        /// </summary>
        public Table(TableRules tableRules)
        {
            m_participantRecord = new Dictionary<int, Participant>();
            m_handRecord = new Dictionary<int, List<Hand>>();
            m_tableRules = tableRules;
            m_handId = 0;
            m_activeHandId = 0;
            m_gameId = 0;
            m_gameIsOngoing = false;
            m_humanInteraction = true;//Allow messageboxes. Will be disabled when ComputerPlayer connects.
        }

        /// <summary>
        /// Define event for deck creation.
        /// </summary>
        public event EventHandler<DeckCreatedEvent> DeckCreated;

        /// <summary>
        /// Define event for shuffeling the deck.
        /// </summary>
        public event EventHandler<DeckShuffledEvent> DeckShuffled;

        /// <summary>
        /// Define event for when a participant connects.
        /// </summary>
        public event EventHandler<ParticipantEvent> ParticipantConnected;

        /// <summary>
        /// Define event for when a participant disconnects.
        /// </summary>
        public event EventHandler<ParticipantEvent> ParticipantDisconnected;

        /// <summary>
        /// Define event for when cards on the table should be updated in GUI
        /// </summary>
        public event EventHandler<AllHandsEvent> UpdateHands;

        /// <summary>
        /// Define event for when game has completed
        /// </summary>
        public event EventHandler<GameStartStopEvent> GameComplete;

        /// <summary>
        /// Define event for when game starts.
        /// </summary>
        public event EventHandler<GameStartStopEvent> GameStarting;

        private void RaiseGameStartingEvent()
        {
            GameStartStopEvent informGameStarting = new GameStartStopEvent(m_handRecord, m_gameId);
            if(GameStarting != null)
            {
                GameStarting(this, informGameStarting);
            }
        }

        private void RaiseGameCompleteEvent()
        {
            GameStartStopEvent informOfGameComplete = new GameStartStopEvent(m_handRecord, m_gameId);
            if(GameComplete != null)//Check that there are subscribers
            {
                GameComplete(this, informOfGameComplete);
            }
        }
        
        private void RaiseAllHandsEvent()
        {
            //Only send this when we have human players at the table
            bool sendEvent = false;
            foreach(int key in m_participantRecord.Keys)
            {
                if(m_participantRecord[key] is HumanPlayer) { sendEvent = true; }
            }
            if(sendEvent)
            {
                AllHandsEvent updateCardsOnTableEventInfo = new AllHandsEvent(m_handRecord);
                if (UpdateHands != null)//Check that there is a subscriber
                {
                    UpdateHands(this, updateCardsOnTableEventInfo);
                }
            }
        }

        private void RaiseDeckCreatedEvent(DeckCreatedEvent deckCreatedEventInfo)
        {
            if (DeckCreated != null)//Check that there is a subscriber
            {
                DeckCreated(this, deckCreatedEventInfo);
            }
        }

        private void RaiseDeckShuffledEvent(DeckShuffledEvent deckShuffledEvent)
        {
            if (DeckShuffled != null)//Check that there is a subscriber
            {
                DeckShuffled(this, deckShuffledEvent);
            }
        }

        private void RaiseParticipantConnectedEvent(ParticipantEvent participantConnectedEvent)
        {
            if (ParticipantConnected != null)//Check that there is a subscriber
            {
                ParticipantConnected(this, participantConnectedEvent);
            }
        }

        private void RaiseParticipantDisconnectedEvent(ParticipantEvent participantDisconnectedEvent)
        {
            if (ParticipantDisconnected != null)//Check that there is a subscriber
            {
                ParticipantDisconnected(this, participantDisconnectedEvent);
            }
        }

        /// <summary>
        /// Create a black jack deck and send event that it has been created.
        /// </summary>
        /// <param name="nrOfDecks"></param>
        /// <returns></returns>
        public void ConnectDeck(int nrOfDecks)
        {
            //Create the deck
            m_deck = new Deck(nrOfDecks);

            //Raise the event DeckCreatedEvent
            DeckCreatedEvent DeckCreatedEventInfo = new DeckCreatedEvent(m_deck.NrOfDecks);
            RaiseDeckCreatedEvent(DeckCreatedEventInfo);
        }

        /// <summary>
        /// Reshuffle the black jack deck and send event that it has been reshuffled.
        /// </summary>
        public void ShuffleDeck()
        {
            int threshold = m_participantRecord.Count * 10;

            //If there are less cards than threshold
            //available in deck, reshuffle the deck
            if(m_deck.GetSizeOfDeck() < threshold)
            {
                m_deck.Reshuffle();

                //Raise the event DeckCreatedEvent
                DeckShuffledEvent DeckShuffledEventInfo = new DeckShuffledEvent();
                RaiseDeckShuffledEvent(DeckShuffledEventInfo);
            }
        }

        /// <summary>
        /// Connect a dealer to the table.
        /// </summary>
        /// <param name="standOn"></param>
        /// <param name="drawOnSoft"></param>
        public void ConnectDealer(int standOn, bool drawOnSoft)
        {
            //Create the dealer
            Dealer dealer = new Dealer(standOn, drawOnSoft);

            //Add the dealer in the participant record
            m_participantRecord.Add(dealer.TablePosition, dealer);

            //Raise event ParticipantConnectedEvent
            ParticipantEvent ParticipantConnectedEventInfo = new ParticipantEvent(dealer.TablePosition,
                                                                                  dealer.Name);
            RaiseParticipantConnectedEvent(ParticipantConnectedEventInfo);

            //Deal initial cards if enough participants
            DealInitialCards();
        }

        private void onParticipantDisconnected(object sender, ParticipantEvent eventInfo)
        {
            //Set the participant to inactive
            Participant participant = null;
            if(m_participantRecord.TryGetValue(eventInfo.TablePosition, out participant))
            {
                participant.Active = false;
                m_participantRecord[eventInfo.TablePosition] = participant;
            }

            //Set the hand(s) to not playing...
            List<Hand> hands = null;
            if(m_handRecord.TryGetValue(eventInfo.TablePosition, out hands))
            {
                for (int i = 0; i < hands.Count; i++)
                {
                    Hand hand = hands.ElementAt(i);
                    hand.InPlay = false;
                    hands[i] = hand;
                }
            }

            //Forward the event to the logger
            RaiseParticipantDisconnectedEvent(eventInfo);

            //Continue the game
            ContinueGame();
        }

        private void onHumanPlayerActionReceived(object sender, HumanPlayerActionEvent eventInfo)
        {
            HandlePlayerAction(eventInfo.HumanPlayerAction, eventInfo.HandId);
        }

        /// <summary>
        /// Connect a player to the table.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="tablePosition"></param>
        public void ConnectHumanPlayer(string name, int tablePosition)
        {
            //Create the humanplayer
            HumanPlayer humanPlayer = new HumanPlayer(this, name, tablePosition);

            //Subscribe to events from HumanPlayer
            humanPlayer.ParticipantDisconnected += onParticipantDisconnected;
            humanPlayer.HumanAction += onHumanPlayerActionReceived;

            //Add the human player in the Participantrecord
            Participant existingParticipant = null;
            if(m_participantRecord.TryGetValue(humanPlayer.TablePosition, out existingParticipant))
            {
                //Replace the participant if it is not active
                if (!existingParticipant.Active)
                {
                    m_participantRecord[humanPlayer.TablePosition] = humanPlayer;
                }
            }
            else//If there is none at that table position. Add this new player
            {
                m_participantRecord.Add(humanPlayer.TablePosition, humanPlayer);
            }

            //Raise event ParticipantConnectedEvent
            ParticipantEvent ParticipantConnectedEventInfo = new ParticipantEvent(humanPlayer.TablePosition,
                                                                                  humanPlayer.Name);
            RaiseParticipantConnectedEvent(ParticipantConnectedEventInfo);

            //Deal initial cards if enough participants
            DealInitialCards();
        }

        /// <summary>
        /// Method to connect a computer player to the table.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="tablePosition"></param>
        /// <param name="playerRules"></param>
        public void ConnectComputerPlayer(string name,
                                          int tablePosition,
                                          PlayerRules playerRules)
        {
            m_humanInteraction = false; //Disable messageboxes

            //Create the Computer Player
            ComputerPlayer computerPlayer = new ComputerPlayer(this, playerRules, name, tablePosition);

            //Subscribe to events from ComputerPlayer
            computerPlayer.ParticipantDisconnected += onParticipantDisconnected;

            //Add the player in the ParticipantRecord
            Participant existingParticipant = null;
            if (m_participantRecord.TryGetValue(computerPlayer.TablePosition, out existingParticipant))
            {
                //Replace the participant if it is not active
                if (!existingParticipant.Active)
                {
                    m_participantRecord[computerPlayer.TablePosition] = computerPlayer;
                }
            }
            else//If there is none at that table position. Add this new player
            {
                m_participantRecord.Add(computerPlayer.TablePosition, computerPlayer);
            }

            //Raise event ParticipantConnectedEvent
            ParticipantEvent ParticipantConnectedEventInfo = new ParticipantEvent(computerPlayer.TablePosition,
                                                                                  computerPlayer.Name);
            RaiseParticipantConnectedEvent(ParticipantConnectedEventInfo);

            //Deal initial cards if enough participants
            DealInitialCards();
        }

        private bool CanGameBegin()
        {
            bool dealerPresent = false;
            bool enoughParticipants = m_participantRecord.Count > 1;

            int dealerTablePosition = 7;
            Participant retreivedValue;
            if(m_participantRecord.TryGetValue(dealerTablePosition, out retreivedValue))
            {
                if(retreivedValue is Dealer) { dealerPresent = true; }
            }

            return dealerPresent && enoughParticipants && (m_deck != null) && !m_gameIsOngoing;
        }

        private void DealInitialCards()
        {
            if (CanGameBegin())
            {
                m_gameIsOngoing = true;
                m_gameId++;

                RaiseGameStartingEvent();

                ShuffleDeck();//Will reshuffle if necessary

                Participant retreivedParticipant;
                foreach (int key in m_participantRecord.Keys.OrderBy(key => key))
                {
                    retreivedParticipant = m_participantRecord[key];

                    //Create initial hand
                    Hand initialHand = new Hand(m_handId);

                    //Add card(s) to initial hand
                    initialHand.AddCardToHand(m_deck.Draw());
                    if(!(retreivedParticipant is Dealer))
                    {
                        initialHand.AddCardToHand(m_deck.Draw());
                        
                    }

                    //Set dealer flag
                    if ((retreivedParticipant is Dealer))
                    {
                        initialHand.DealerHand = true;
                    }

                    //Check for BJ and if BJ, set the BJ flag in the hand
                    initialHand = EvaluatePlayerHand.ProcessHand(initialHand);

                    //Save the hand in the dictionary m_handRecord
                    List<Hand> initialHands = new List<Hand>();
                    initialHands.Add(initialHand);
                    m_handRecord.Add(retreivedParticipant.TablePosition, initialHands);

                    //Inrease handId
                    m_handId++;
                }

                //Send all active hands in an event
                RaiseAllHandsEvent();

                //Cotinue with participant actions
                ContinueGame();
            }
        }

        /// <summary>
        /// Method which takes the first active hand and triggers/asks for
        /// an action on that hand.
        /// 
        /// If there are no more active hands or players;
        ///  - calculate the winning/result
        ///  - remove inactive players
        ///  - clear the m_handRecord dictionary
        /// </summary>
        private void ContinueGame()
        {
            //Get the next hand in turn (check for InPlay flag set to true)
            int nextTablePosition = -1;
            int nextHandPosition = -1;
            bool nextHandFound = false;
            ActionType nextAction;
            foreach(int key in m_participantRecord.Keys.OrderBy(key => key))
            {
                if(!nextHandFound)
                {
                    List<Hand> hands;
                    if (m_handRecord.TryGetValue(m_participantRecord[key].TablePosition, out hands))
                    {
                        for (int i = 0; i < hands.Count; i++)
                        {
                            if (hands.ElementAt(i).InPlay == true)
                            {
                                nextTablePosition = key;
                                nextHandPosition = i;
                                nextHandFound = true;
                            }
                        }
                    }
                }
            }

            if(nextHandFound)
            {
                if (m_participantRecord[nextTablePosition] is HumanPlayer)
                {
                    m_activeHandId = m_handRecord[nextTablePosition].ElementAt(nextHandPosition).HandId;

                    if(m_participantRecord[nextTablePosition].Active)
                    {
                        ((HumanPlayer)m_participantRecord[nextTablePosition]).TriggerAction(m_handRecord[nextTablePosition].ElementAt(nextHandPosition));

                        //The response from this will be received in an event sent from the HumanPlayer class
                        //see onHumanPlayerActionReceived
                    }
                    else//This will result in Stop action
                    {
                        nextAction = m_participantRecord[nextTablePosition].GetAction(m_handRecord[nextTablePosition].ElementAt(nextHandPosition));
                        HandlePlayerAction(nextAction, m_handRecord[nextTablePosition].ElementAt(nextHandPosition).HandId);
                    }

                }
                else //Computer player or dealer
                {
                    nextAction = m_participantRecord[nextTablePosition].GetAction(m_handRecord[nextTablePosition].ElementAt(nextHandPosition));
                    HandlePlayerAction(nextAction, m_handRecord[nextTablePosition].ElementAt(nextHandPosition).HandId);
                }
            }
            else //Calculate and set winning hands
            {
                
                int dealerKey = 7;
                bool dealerKeyFound = false;
                List<Hand> dealerHands;

                //First find the dealerhand
                foreach (int key in m_handRecord.Keys)
                {
                    if (!dealerKeyFound)
                    {
                        //One hand in the handrecord shall have the dealerhand flag set.
                        for (int i = 0; i < m_handRecord[key].Count; i++)
                        {
                            if (m_handRecord[key].ElementAt(i).DealerHand)
                            {
                                dealerKey = key;
                                dealerKeyFound = true;
                            }
                        }
                    }
                }

                if(dealerKeyFound)
                {
                    //Then retreive the dealerhand (dealer has only one hand (no split))
                    m_handRecord.TryGetValue(dealerKey, out dealerHands);
                    EvaluateWinningHand eval = new EvaluateWinningHand(dealerHands.ElementAt(0));

                    //Now evaluate all player hands against the dealer hand
                    //and save the keys and the hands in a list
                    List<int> keys = new List<int>(m_handRecord.Keys);//Copy the keys so that I can make changes 
                                                                      //to the dictionary in the foreach loop
                    foreach (int key in keys)
                    {
                        for (int i = 0; i < m_handRecord[key].Count; i++)
                        {
                            if (!m_handRecord[key].ElementAt(i).DealerHand)
                            {
                                if (eval.IsHandBetterThanDealerHand(m_handRecord[key].ElementAt(i)))
                                {
                                    List<Hand> hands = m_handRecord[key];
                                    hands.ElementAt(i).WinningHand = true;
                                    m_handRecord[key] = hands;
                                }
                            }
                        }
                    }
                }

                //Send a Game Completed event
                RaiseGameCompleteEvent();

                //Delete all hands
                m_handRecord.Clear();

                //Remove all inactive players
                List<int> listOfKeysToDelete = new List<int>();
                foreach(int key in m_participantRecord.Keys)
                {
                    if(m_participantRecord[key].Active == false)
                    {
                        listOfKeysToDelete.Add(key);
                    }
                }
                for(int i=0; i<listOfKeysToDelete.Count; i++)
                {
                    m_participantRecord.Remove(listOfKeysToDelete[i]);
                }

                //No more playing
                m_gameIsOngoing = false;

                //Start new game if applicable
                DealInitialCards();
            }
        }

        /// <summary>
        /// Method to handle a player action on a specific handId.
        /// After action and handId have been verified OK, action is performed and
        /// event is sent to inform about the new hands.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="handId"></param>
        private void HandlePlayerAction(ActionType action, int handId)
        {
            int tablePosition = -1;
            int handPosition = -1;
            bool handIdentified = false;
            foreach(int key in m_handRecord.Keys)
            {
                if(!handIdentified)
                {
                    List<Hand> hands;
                    if (m_handRecord.TryGetValue(m_participantRecord[key].TablePosition, out hands))
                    {
                        for (int i = 0; i < hands.Count; i++)
                        {
                            if (hands.ElementAt(i).HandId == handId)
                            {
                                tablePosition = key;
                                handPosition = i;
                                handIdentified = true;
                            }
                        }
                    }
                }
            }

            if(handIdentified)
            {
                List<Hand> hands;
                string msgToHuman = "";
                switch (action)
                {
                    case ActionType.Stop:
                        hands = m_handRecord[tablePosition];
                        hands.ElementAt(handPosition).InPlay = false;
                        m_handRecord[tablePosition] = hands;
                        if (m_humanInteraction)
                        {
                            //Present messagebox to make game less speedy for humans
                            msgToHuman = String.Format("{0} stopped", m_participantRecord[tablePosition].Name);
                            System.Windows.MessageBox.Show(msgToHuman);
                        }
                        break;
                    case ActionType.Draw:
                        hands = m_handRecord[tablePosition];
                        int drawnCard = m_deck.Draw();
                        hands.ElementAt(handPosition).AddCardToHand(drawnCard);
                        //Set BJ flag and unset InPlay flag if BJ or bust (handvalue > 21)
                        hands[handPosition] = EvaluatePlayerHand.ProcessHand(hands.ElementAt(handPosition));
                        //Update the handRecord with this new hand
                        m_handRecord[tablePosition] = hands;
                        if(m_humanInteraction)
                        {
                            //Present messagebox to make game less speedy for humans
                            msgToHuman = String.Format("{0} drew {1}",
                                                       m_participantRecord[tablePosition].Name,
                                                       drawnCard.ToString());
                            System.Windows.MessageBox.Show(msgToHuman);
                        }
                        break;
                    case ActionType.Split:
                        hands = m_handRecord[tablePosition];
                        //Check if split is allowed
                        if (EvaluatePlayerHand.IsSplitAllowed(m_tableRules, hands.ElementAt(handPosition)))
                        {
                            //Split is not yet supported
                        }
                        break;
                    case ActionType.Double:
                        hands = m_handRecord[tablePosition];
                        //Check if double is allowed
                        if(EvaluatePlayerHand.IsDoubleAllowed(m_tableRules, hands.ElementAt(handPosition)))
                        {
                            //Double not yet supported
                        }
                        break;
                    default:
                        break;
                }
            }

            //Send all active hands in an event
            RaiseAllHandsEvent();

            //Continue the game
            ContinueGame();
        }
    }
}
