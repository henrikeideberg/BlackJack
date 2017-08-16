using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BlackJack.Windows
{
    /// <summary>
    /// Interaction logic for TableWindow.xaml
    /// </summary>
    public partial class TableWindow : Window
    {
        Table m_table;

        /// <summary>
        /// Constructor
        /// </summary>
        public TableWindow(TableRules tableRules)
        {
            InitializeComponent();

            //Create the table logic
            m_table = new Table(tableRules);

            //Subscribe to the table events
            m_table.DeckCreated += onDeckCreatedReceived;
            m_table.DeckShuffled += onDeckShuffledReceived;
            m_table.ParticipantConnected += onParticipantConnectedEvent;
            m_table.ParticipantDisconnected += onParticipantDisconnectedEvent;
            m_table.UpdateHands += onUpdateCardsOnTable;
            m_table.GameStarting += onGameStartingEvent;
            m_table.GameComplete += onGameCompleteEvent;

            InitGui();
        }

        private void InitGui()
        {
            buttonConnectDeck.Background = Brushes.DarkOrange;
            buttonDealer.Background = Brushes.DarkOrange;
            buttonPlayer1.Background = Brushes.DarkOrange;
            buttonPlayer2.Background = Brushes.DarkOrange;
            buttonPlayer3.Background = Brushes.DarkOrange;
            buttonPlayer4.Background = Brushes.DarkOrange;
            buttonPlayer5.Background = Brushes.DarkOrange;
            buttonPlayer6.Background = Brushes.DarkOrange;

            ResetHandTextBlocks();
        }

        private void ResetHandTextBlocks()
        {
            textBlockDealerHand.Text = "-";
            textBlockPlayer1Hand.Text = "-";
            textBlockPlayer2Hand.Text = "-";
            textBlockPlayer3Hand.Text = "-";
            textBlockPlayer4Hand.Text = "-";
            textBlockPlayer5Hand.Text = "-";
            textBlockPlayer6Hand.Text = "-";
        }

        private void buttonConnectDeck_Click(object sender, RoutedEventArgs e)
        {
            //Read how many decks we shall use
            int nrOfDecks = 0;
            Convertions.ConvertStringToInteger(textBoxNrOfDecks.Text, out nrOfDecks);

            //If input is valid integer then procees to connect the deck
            if (nrOfDecks > 0)
            {
                //Connect the deck
                m_table.ConnectDeck(nrOfDecks);
            }
        }

        private void AddItemToLog(DateTime timeStamp,
                                  string information,
                                  string sender)
        {
            listViewLog.Items.Insert(0,
                                     new ListViewLogItem
                                     {
                                        TimeStamp = timeStamp,//Column 1
                                        Information = information,//Column 2
                                        Sender = sender//Column 3
                                     });
        }

        private void onGameStartingEvent(object sender, GameStartStopEvent eventInfo)
        {
            listBoxMainLog.Items.Insert(0, "Game started: " + eventInfo.GameId.ToString());
        }

        private void onGameCompleteEvent(object sender, GameStartStopEvent eventInfo)
        {
            foreach (int key in eventInfo.HandRecord.Keys)
            {
                //Go through the list of played hands
                for (int i = 0; i < eventInfo.HandRecord[key].Count; i++)
                {
                    //For each hand build a string with all the information
                    listBoxMainLog.Items.Insert(0, eventInfo.HandRecord[key].ElementAt(i).LogString());
                }
            }
            
            listBoxMainLog.Items.Insert(0, "Game ended: " + eventInfo.GameId.ToString());

            ResetHandTextBlocks();
        }

        private void onUpdateCardsOnTable(object sender, AllHandsEvent eventInfo)
        {
            //Get all hands from the received dictionary
            List<Hand> retreivedHands;
            foreach (int key in eventInfo.HandRecord.Keys)
            {
                retreivedHands = eventInfo.HandRecord[key];
                string handString = "";
                for(int i = 0; i<retreivedHands.Count; i++)
                {
                    handString = retreivedHands.ElementAt(i).HandToString();
                }

                //Based on tableposition/key - display the hand in the gui
                switch(key)
                {
                    case 1: //player 1
                        textBlockPlayer1Hand.Text = handString;
                        break;
                    case 2: //player 2
                        textBlockPlayer2Hand.Text = handString;
                        break;
                    case 3: //player 3
                        textBlockPlayer3Hand.Text = handString;
                        break;
                    case 4: //player 4
                        textBlockPlayer4Hand.Text = handString;
                        break;
                    case 5: //player 5
                        textBlockPlayer5Hand.Text = handString;
                        break;
                    case 6: //player 6
                        textBlockPlayer6Hand.Text = handString;
                        break;
                    case 7://dealer
                        textBlockDealerHand.Text = handString;
                        break;
                    default:
                        break;
                }
            }
        }

        private void onDeckCreatedReceived(object sender, DeckCreatedEvent deckCreatedEventInfo)
        {
            if(textBoxNrOfDecks.IsEnabled == true)
            {
                string informationMsg = String.Format("BJ deck created. {0} deck(s) included", deckCreatedEventInfo.NumberOfDecks);

                //add the information in the log window
                AddItemToLog(deckCreatedEventInfo.TimeStamp, informationMsg, sender.ToString());

                //restyle the deck button and textbox to indicate the deck is now available
                textBoxNrOfDecks.IsEnabled = false;
                buttonConnectDeck.Content = "Deck online";
                buttonConnectDeck.Background = Brushes.DarkGreen;
            }
            
        }

        private void onDeckShuffledReceived(object sender, DeckShuffledEvent deckShuffledEventInfo)
        {
            string informationMsg = String.Format("Deck reshuffled");

            //add the information in the log window
            AddItemToLog(deckShuffledEventInfo.TimeStamp, informationMsg, sender.ToString());

        }

        private void onParticipantConnectedEvent(object sender, ParticipantEvent eventInfo)
        {
            string informationMsg = string.Format("{0} connected at position {1}.",
                eventInfo.Name,
                eventInfo.TablePosition);

            //add the information in the log window
            AddItemToLog(eventInfo.TimeStamp, informationMsg, sender.ToString());

            //restyle the button at table position
            switch(eventInfo.TablePosition)
            {
                case 1 :
                    buttonPlayer1.IsEnabled = false;
                    buttonPlayer1.Content = eventInfo.Name;
                    break;
                case 2:
                    buttonPlayer2.IsEnabled = false;
                    buttonPlayer2.Content = eventInfo.Name;
                    break;
                case 3:
                    buttonPlayer3.IsEnabled = false;
                    buttonPlayer3.Content = eventInfo.Name;
                    break;
                case 4:
                    buttonPlayer4.IsEnabled = false;
                    buttonPlayer4.Content = eventInfo.Name;
                    break;
                case 5:
                    buttonPlayer5.IsEnabled = false;
                    buttonPlayer5.Content = eventInfo.Name;
                    break;
                case 6:
                    buttonPlayer6.IsEnabled = false;
                    buttonPlayer6.Content = eventInfo.Name;
                    break;
                case 7: //dealer
                    buttonDealer.IsEnabled = false;
                    buttonDealer.Content = "Dealer";
                    break;
                default:
                    //do nothing;
                    break;
            }
        }

        private void onParticipantDisconnectedEvent(object sender, ParticipantEvent eventInfo)
        {
            string informationMsg = string.Format("{0} disconnected from position {1}",
                eventInfo.Name,
                eventInfo.TablePosition);

            //Add the information in the log window
            AddItemToLog(eventInfo.TimeStamp, informationMsg, sender.ToString());

            //restyle the button at table position
            switch(eventInfo.TablePosition)
            {
                case 1:
                    buttonPlayer1.IsEnabled = true;
                    buttonPlayer1.Content = "Connect Player";
                    buttonPlayer1.Background = Brushes.DarkOrange;
                    break;
                case 2:
                    buttonPlayer2.IsEnabled = true;
                    buttonPlayer2.Content = "Connect Player";
                    buttonPlayer2.Background = Brushes.DarkOrange;
                    break;
                case 3:
                    buttonPlayer3.IsEnabled = true;
                    buttonPlayer3.Content = "Connect Player";
                    buttonPlayer3.Background = Brushes.DarkOrange;
                    break;
                case 4:
                    buttonPlayer4.IsEnabled = true;
                    buttonPlayer4.Content = "Connect Player";
                    buttonPlayer4.Background = Brushes.DarkOrange;
                    break;
                case 5:
                    buttonPlayer5.IsEnabled = true;
                    buttonPlayer5.Content = "Connect Player";
                    buttonPlayer5.Background = Brushes.DarkOrange;
                    break;
                case 6:
                    buttonPlayer6.IsEnabled = true;
                    buttonPlayer6.Content = "Connect Player";
                    buttonPlayer6.Background = Brushes.DarkOrange;
                    break;
                default:
                    //do nothing
                    break;
            }
        }

        private void buttonDealer_Click(object sender, RoutedEventArgs e)
        {
            //Bring up a form in which we retreive the dealer rules
            using (var form = new DealerSetup())
            {
                var result = form.ShowDialog();

                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    //Values are preserved after closing the form
                    m_table.ConnectDealer(form.StandOn, form.DrawOnSoft);
                }
            }
        }

        private void ConfigureComputerPlayer(string playerName, int tablePosition)
        {
            using (var form = new ComputerPlayerSetup())
            {
                var result = form.ShowDialog();

                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    //Connect ComputerPlayer at position tablePosition
                    m_table.ConnectComputerPlayer(playerName,
                                                  tablePosition,
                                                  form.Rules);
                }
            }
        }

        private void buttonPlayer_Click(int tablePosition)
        {
            //Bring up a small form to decide whether it is a human player
            //or a computer player
            using (var form = new PlayerSetup())
            {
                var result = form.ShowDialog();

                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    if (form.HumanPlayer)
                    {
                        //Connect human player at position tablePosition
                        m_table.ConnectHumanPlayer(form.PlayerName, tablePosition);
                    }
                    else if(!form.HumanPlayer)//NOT HumanPlayer
                    {
                        ConfigureComputerPlayer(form.PlayerName, tablePosition);
                    }
                }
            }
        }

        private void buttonPlayer1_Click(object sender, RoutedEventArgs e)
        {
            buttonPlayer_Click(1);
        }

        private void buttonPlayer2_Click(object sender, RoutedEventArgs e)
        {
            buttonPlayer_Click(2);
        }

        private void buttonPlayer3_Click(object sender, RoutedEventArgs e)
        {
            buttonPlayer_Click(3);
        }

        private void buttonPlayer4_Click(object sender, RoutedEventArgs e)
        {
            buttonPlayer_Click(4);
        }

        private void buttonPlayer5_Click(object sender, RoutedEventArgs e)
        {
            buttonPlayer_Click(5);
        }

        private void buttonPlayer6_Click(object sender, RoutedEventArgs e)
        {
            buttonPlayer_Click(6);
        }
    }
}
