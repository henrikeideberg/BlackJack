using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlackJackUnitTestProject
{
    /// <summary>
    /// Summary description for EvaluatePlayerHandUnitTest
    /// </summary>
    [TestClass]
    public class EvaluatePlayerHandUnitTest
    {
        BlackJack.Hand m_hand;

        public EvaluatePlayerHandUnitTest()
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
            m_hand = new BlackJack.Hand(0);
        }

        [TestCleanup]
        public void CleanUp()
        {
            m_hand = null;
        }

        /* Test scenarios
         * CheckIfBJ_21: hand is 21 (three cards) => false
         * CheckIfBJ_BJ: hand is 21 (two cards) => true
         * CheckIfBJ_20: hand is 20 (two cards) => false
         * CheckIfBust_21: hand is 21 (three cards) => false
         * CheckIfBust_BJ: hand is 21 (two cards) => false
         * CheckIfBust_AA: hand is 12/22 (A/A) => false
         * CheckIfBust_22: hand is 22 (three cards) => true
         * */

        [TestMethod]
        public void CheckIfBust_22()
        {
            m_hand.AddCardToHand(6);
            m_hand.AddCardToHand(6);

            //Evaluate hand and assert it is still in play
            m_hand = BlackJack.EvaluatePlayerHand.ProcessHand(m_hand);
            Assert.IsTrue(m_hand.InPlay);

            m_hand.AddCardToHand(10);

            //Evaluate hand and assert it is no longer in play
            m_hand = BlackJack.EvaluatePlayerHand.ProcessHand(m_hand);
            Assert.IsFalse(m_hand.InPlay);
        }

        [TestMethod]
        public void CheckIfBust_AA()
        {
            m_hand.AddCardToHand(1);
            m_hand.AddCardToHand(1);

            //Evaluate hand and assert it is still in play
            m_hand = BlackJack.EvaluatePlayerHand.ProcessHand(m_hand);
            Assert.IsTrue(m_hand.InPlay);
        }

        [TestMethod]
        public void CheckIfBust_BJ()
        {
            m_hand.AddCardToHand(1);
            m_hand.AddCardToHand(10);

            //Evaluate hand and assert it is BJ and no longer in play
            m_hand = BlackJack.EvaluatePlayerHand.ProcessHand(m_hand);
            Assert.IsFalse(m_hand.InPlay);
            Assert.IsTrue(m_hand.BlackJack);
        }

        [TestMethod]
        public void CheckIfBust_21()
        {
            m_hand.AddCardToHand(5);
            m_hand.AddCardToHand(10);

            //Evaluate hand and assert it is still in play
            m_hand = BlackJack.EvaluatePlayerHand.ProcessHand(m_hand);
            Assert.IsTrue(m_hand.InPlay);

            m_hand.AddCardToHand(6);

            //Evaluate hand and assert it is still in play
            m_hand = BlackJack.EvaluatePlayerHand.ProcessHand(m_hand);
            Assert.IsTrue(m_hand.InPlay);
        }

        [TestMethod]
        public void CheckIfBJ_20()
        {
            m_hand.AddCardToHand(10);
            m_hand.AddCardToHand(10);

            //Evaluate hand and assert it is still in play and no BJ
            m_hand = BlackJack.EvaluatePlayerHand.ProcessHand(m_hand);
            Assert.IsTrue(m_hand.InPlay);
            Assert.IsFalse(m_hand.BlackJack);
        }

        [TestMethod]
        public void CheckIfBJ_BJ()
        {
            m_hand.AddCardToHand(1);
            m_hand.AddCardToHand(10);

            //Evaluate hand and assert it is still in play and no BJ
            m_hand = BlackJack.EvaluatePlayerHand.ProcessHand(m_hand);
            Assert.IsFalse(m_hand.InPlay);
            Assert.IsTrue(m_hand.BlackJack);
        }

        [TestMethod]
        public void CheckIfBJ_21()
        {
            m_hand.AddCardToHand(4);
            m_hand.AddCardToHand(7);

            //Evaluate hand and assert it is still in play and no BJ
            m_hand = BlackJack.EvaluatePlayerHand.ProcessHand(m_hand);
            Assert.IsTrue(m_hand.InPlay);
            Assert.IsFalse(m_hand.BlackJack);

            m_hand.AddCardToHand(10);

            //Evaluate hand and assert it is still in play and no BJ
            m_hand = BlackJack.EvaluatePlayerHand.ProcessHand(m_hand);
            Assert.IsTrue(m_hand.InPlay);
            Assert.IsFalse(m_hand.BlackJack);
        }
    }
}
