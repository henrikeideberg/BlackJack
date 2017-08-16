using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlackJackUnitTestProject
{
    /// <summary>
    /// Summary description for TableUnitTest
    /// </summary>
    [TestClass]
    public class TableUnitTest
    {
        //Define test objects
        BlackJack.Table m_table;
        BlackJack.PlayerRules m_playerRules;
        BlackJack.TableRules m_tableRules;

        //Define test parameters used to verify behaviour
        bool m_shallDeckEventBeReceived;
        bool m_shallDeckShuffledBeReceived;
        bool m_shallParticipantConnectedBeReceived;
        bool m_shallUpdateCardsOnTableBeReceived;
        bool m_shallGameStartingEventBeReceived;
        bool m_shallGameCompleteEventBeReceived;
        int m_nrOfDecksToBeReceivedInDeckCreatedEvent;
        int m_participantTablePosition;
        int m_expectedGameId;
        string m_participantName;
        bool m_ReshuffleEventReceived;

        public TableUnitTest()
        {
            //Nothing in the constructor for now
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestInitialize]
        public void Setup()
        {
            //Init all test parameters
            m_shallDeckEventBeReceived = false;
            m_shallDeckShuffledBeReceived = false;
            m_shallParticipantConnectedBeReceived = false;
            m_shallUpdateCardsOnTableBeReceived = false;
            m_ReshuffleEventReceived = false;
            m_shallGameStartingEventBeReceived = false;
            m_shallGameCompleteEventBeReceived = false;
            m_nrOfDecksToBeReceivedInDeckCreatedEvent = 0;
            m_participantName = "";
            m_participantTablePosition = -1;
            m_expectedGameId = -1;

            //Create the table and subscribe to the events
            m_tableRules = new BlackJack.TableRules
            {
                NumberOfResplits = -1,
                NumberOfSplitsOnAces = 1,
                NumberOfCardsAfterSplitAces = 1,
                AllowDoubleOnSplitAces = false,
                AllowDoubleAfterSplit = true,
                AllowDoubleOnSoftHands = false,
                DoubleMin = 9,
                DoubleMax = 11,
                DealerWinsAtTie = false
            };
            m_table = new BlackJack.Table(m_tableRules);
            m_playerRules = new BlackJack.PlayerRules
            {
                StandOn = 15,
                NrOFGames = 50
            };

            m_table.DeckCreated += onDeckCreatedReceived;
            m_table.DeckShuffled += onDeckShuffledReceived;
            m_table.ParticipantConnected += onParticipantConnectedEvent;
            m_table.UpdateHands += onUpdateCardsOnTableEvent;
            m_table.GameStarting += onGameStartingEvent;
            m_table.GameComplete += onGameCompleteEvent;
        }

        [TestCleanup]
        public void CleanUp()
        {
            //Reset all test objects and parameters
            m_table = null;
            m_playerRules = null;
            m_tableRules = null;
            m_shallDeckEventBeReceived = false;
            m_shallDeckShuffledBeReceived = false;
            m_shallParticipantConnectedBeReceived = false;
            m_shallUpdateCardsOnTableBeReceived = false;
            m_ReshuffleEventReceived = false;
            m_shallGameStartingEventBeReceived = false;
            m_shallGameCompleteEventBeReceived = false;
            m_nrOfDecksToBeReceivedInDeckCreatedEvent = 0;
            m_participantName = "";
            m_participantTablePosition = -1;
            m_expectedGameId = -1;
        }

        [TestMethod]
        public void ConnectDeck()
        {
            //Prepare to receive event
            m_shallDeckEventBeReceived = true;
            m_nrOfDecksToBeReceivedInDeckCreatedEvent = 4;

            //Connect deck
            m_table.ConnectDeck(m_nrOfDecksToBeReceivedInDeckCreatedEvent);

            //Verification of the event/log information
            //is done in onDeckCreatedReceived

        }

        [TestMethod]
        public void NoReshuffle()
        {
            //Prepare to receive events
            m_shallDeckEventBeReceived = true;
            m_shallDeckShuffledBeReceived = false;
            m_nrOfDecksToBeReceivedInDeckCreatedEvent = 1;

            //Connect deck
            m_table.ConnectDeck(m_nrOfDecksToBeReceivedInDeckCreatedEvent);

            //Use reshuffle function
            m_table.ShuffleDeck();

            //Verify that no reshuffle happens
            //this happens automatically in onDeckShuffledReceived

            //Connect dealer
            m_shallParticipantConnectedBeReceived = true;
            m_participantTablePosition = 7;
            m_participantName = "Dealer";
            int standOn = 17;
            bool drawOnSoft = false;
            m_table.ConnectDealer(standOn, drawOnSoft);

            //Draw cards -1 to reshuffle threshold
            /* According to reshuffle algorithm/specifications the 
             * deck is reshuffled when there are less than nrOfPlayer*10
             * cards available in deck.
             * nrOfPlayers is in this case 2 => threshold = 20.
             * This deck has 1*52 = 104 cards.
             * I.e. draw 84 cards.*/

            //tbd - cannot find good deterministic way of drawing cards from table
        }

        [TestMethod]
        public void Reshuffle()
        {
            //Prepare to receive events
            m_shallDeckEventBeReceived = true;
            m_shallDeckShuffledBeReceived = true;
            m_nrOfDecksToBeReceivedInDeckCreatedEvent = 1;

            //Connect deck
            m_table.ConnectDeck(m_nrOfDecksToBeReceivedInDeckCreatedEvent);

            //Connect dealer
            m_shallParticipantConnectedBeReceived = true;
            m_participantTablePosition = 7;
            m_participantName = "Dealer";
            int standOn = 17;
            bool drawOnSoft = false;
            m_table.ConnectDealer(standOn, drawOnSoft);

            //Connect ComputerPlayer
            m_participantTablePosition = 1;
            m_participantName = "ComputerPlayer";
            m_shallUpdateCardsOnTableBeReceived = true;
            m_shallGameStartingEventBeReceived = true;
            m_shallGameCompleteEventBeReceived = true;
            m_table.ConnectComputerPlayer(m_participantName,
                                          m_participantTablePosition,
                                          m_playerRules);

            //ComputerPlayer and Dealer will play and trigger Reshuffeling

            //Receive reshuffle event handled in onDeckShuffledReceived

            //Verify that reshuffle event has been received
            Assert.IsTrue(m_ReshuffleEventReceived);

            //Verify we have played set number of games
            Assert.AreEqual(m_expectedGameId, m_playerRules.NrOFGames);
        }

        [TestMethod]
        public void ConnectDealer()
        {
            //Prepare to receive events
            m_participantName = "Dealer";
            m_participantTablePosition = 7;
            m_shallParticipantConnectedBeReceived = true;

            //Connect dealer with default atributes
            int standOn = 17;
            bool drawOnSoft = false;
            m_table.ConnectDealer(standOn, drawOnSoft);

            //Verify event is done in onParticipantConnectedEvent
        }

        [TestMethod]
        public void ConnectHumanPlayer()
        {
            //Prepare to receive events
            m_participantName = "HumanPlayer";
            m_participantTablePosition = 1;
            m_shallParticipantConnectedBeReceived = true;

            //Connect human player at position 1
            m_table.ConnectHumanPlayer(m_participantName, m_participantTablePosition);

            //Verify event is done in onParticipantConnectedEvent
        }

        [TestMethod]
        public void ConnectComputerPlayer()
        {
            //Prepare to receive events
            m_participantName = "ComputerPlayer";
            m_participantTablePosition = 3;
            m_shallParticipantConnectedBeReceived = true;

            //Connect ComputerPlayer
            m_playerRules.NrOFGames = 5;
            m_table.ConnectComputerPlayer(m_participantName,
                                          m_participantTablePosition,
                                          m_playerRules);

            //Verify event is done in onParticipantConnectedEvent
        }

        [TestMethod]
        public void DealInitialCards()
        {
            //Prepare to receive deck events
            m_shallDeckEventBeReceived = true;
            m_shallDeckShuffledBeReceived = false;
            m_nrOfDecksToBeReceivedInDeckCreatedEvent = 1;

            //Connect deck
            m_table.ConnectDeck(m_nrOfDecksToBeReceivedInDeckCreatedEvent);

            //Prepare to receive dealer events
            m_participantName = "Dealer";
            m_participantTablePosition = 7;
            m_shallParticipantConnectedBeReceived = true;

            //Connect dealer with default atributes
            int standOn = 17;
            bool drawOnSoft = false;
            m_table.ConnectDealer(standOn, drawOnSoft);

            //Verify event is done in onParticipantConnectedEvent

            //Prepare to receive player events
            m_participantName = "HumanPlayer";
            m_participantTablePosition = 1;

            //Prepare to receive CardUpdate and GameStartingEvent
            m_shallUpdateCardsOnTableBeReceived = true;
            m_shallGameStartingEventBeReceived = true;
            m_shallGameCompleteEventBeReceived = true;

            //Connect human player at position 1
            m_table.ConnectHumanPlayer(m_participantName, m_participantTablePosition);

            //Verify event is done in onParticipantConnectedEvent

            //Verify we have not yet played any games
            Assert.AreEqual(m_expectedGameId, -1);
        }

        /// <summary>
        /// Methid to verify the deckCreatedEvent (type: DeckCreatedEvent)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="deckCreatedEventInfo"></param>
        private void onDeckCreatedReceived(object sender, BlackJack.DeckCreatedEvent deckCreatedEventInfo)
        {
            Assert.IsTrue(m_shallDeckEventBeReceived);
            Assert.AreEqual(m_nrOfDecksToBeReceivedInDeckCreatedEvent, deckCreatedEventInfo.NumberOfDecks);
        }

        /// <summary>
        /// Method to verify the deckShuffledEvent (type: DeckShuffledEvent)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="deckShuffledEventInfo"></param>
        private void onDeckShuffledReceived(object sender, BlackJack.DeckShuffledEvent deckShuffledEventInfo)
        {
            Assert.IsTrue(m_shallDeckShuffledBeReceived);
            m_ReshuffleEventReceived = true;
        }

        /// <summary>
        /// Method to verify the ParticipantConnectedEvent.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="participantConnectedInfo"></param>
        private void onParticipantConnectedEvent(object sender,
                                                 BlackJack.ParticipantEvent participantConnectedInfo)
        {
            Assert.IsTrue(m_shallParticipantConnectedBeReceived);
            Assert.AreEqual(m_participantName, participantConnectedInfo.Name);
            Assert.AreEqual(m_participantTablePosition, participantConnectedInfo.TablePosition);
        }

        private void onUpdateCardsOnTableEvent(object sender,
                                               BlackJack.AllHandsEvent eventInfo)
        {
            Assert.IsTrue(m_shallUpdateCardsOnTableBeReceived);

            List<BlackJack.Hand> retreivedValueAtPosZero;
            List<BlackJack.Hand> retreivedValueAtPosOne;
            Assert.IsTrue(eventInfo.HandRecord.TryGetValue(1, out retreivedValueAtPosZero)); //Verify one player at pos is present
            Assert.IsTrue(eventInfo.HandRecord.TryGetValue(7, out retreivedValueAtPosOne)); //Verify dealer is present
            Assert.IsTrue(BlackJack.Convertions.ValidateString(retreivedValueAtPosZero[0].HandToString()));
            Assert.IsTrue(BlackJack.Convertions.ValidateString(retreivedValueAtPosOne[0].HandToString()));
        }

        private void onGameStartingEvent(object sender,
                                         BlackJack.GameStartStopEvent eventInfo)
        {
            Assert.IsTrue(m_shallGameStartingEventBeReceived);
        }

        private void onGameCompleteEvent(object sender,
                                         BlackJack.GameStartStopEvent eventInfo)
        {
            Assert.IsTrue(m_shallGameCompleteEventBeReceived);
            m_expectedGameId++;
        }
    }
}
