using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlackJackUnitTestProject
{
    /// <summary>
    /// Summary description for HumanPlayerUnitTest
    /// </summary>
    [TestClass]
    public class HumanPlayerUnitTest
    {
        BlackJack.TableRules m_tableRules;
        BlackJack.HumanPlayer m_humanPlayer;
        BlackJack.Hand m_hand;
        BlackJack.Table m_table;

        public HumanPlayerUnitTest()
        {
            //
            // TODO: Add constructor logic here
            //
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
            m_humanPlayer = new BlackJack.HumanPlayer(m_table, "name", 1);
            m_hand = new BlackJack.Hand(1);
        }

        [TestCleanup]
        public void CleanUp()
        {
            m_humanPlayer = null;
            m_hand = null;
            m_tableRules = null;
        }

        [TestMethod]
        public void TestDefaultStop()
        {
            //By default the human player will send 'Stop'. Verify this
            m_hand.AddCardToHand(10);
            m_hand.AddCardToHand(9);

            Assert.AreEqual(BlackJack.ActionType.Stop, m_humanPlayer.GetAction(m_hand));
        }

        //Following are not tested
        // - Draw
        // - Split
        // - Double
        // as they require user interaction / or simulated windows/wpf behaviour
        // and I do not know how to do that yet.
    }
}
