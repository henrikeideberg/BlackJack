using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlackJackUnitTestProject
{
    [TestClass]
    public class DealerUnitTest
    {
        private BlackJack.Dealer m_dealer;
        private BlackJack.Hand m_hand;

        #region Test attributes
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
            m_hand = new BlackJack.Hand(1);
        }

        [TestCleanup]
        public void CleanUp()
        {
            m_dealer = null;
            m_hand = null;
        }

        [TestMethod]
        public void TestDealerOnStand()
        {
            //Create the dealer
            int standOn = 17;
            bool drawOnSoft = false;
            CreateDealer(standOn, drawOnSoft);

            //Add cards to hand
            m_hand.AddCardToHand(10);
            m_hand.AddCardToHand(7);

            //Verify that dealer stands when hand is 17 (standOn)
            Assert.AreEqual(BlackJack.ActionType.Stop, m_dealer.GetAction(m_hand));
        }

        [TestMethod]
        public void TestDealerGreaterThanStand()
        {
            //Create the dealer
            int standOn = 17;
            bool drawOnSoft = false;
            CreateDealer(standOn, drawOnSoft);

            //Add cards to hand
            m_hand.AddCardToHand(10);
            m_hand.AddCardToHand(9);

            //Verify that dealer stands when hand is 17 (standOn)
            Assert.AreEqual(BlackJack.ActionType.Stop, m_dealer.GetAction(m_hand));
        }

        [TestMethod]
        public void TestDealerDraw()
        {
            //Create the dealer
            int standOn = 17;
            bool drawOnSoft = false;
            CreateDealer(standOn, drawOnSoft);

            //Add cards to hand
            m_hand.AddCardToHand(5);
            m_hand.AddCardToHand(3);

            //Verify that dealer draws when hand is less than 17
            Assert.AreEqual(BlackJack.ActionType.Draw, m_dealer.GetAction(m_hand));
        }

        [TestMethod]
        public void TestDealerDrawAce()
        {
            //Create the dealer
            int standOn = 17;
            bool drawOnSoft = false;
            CreateDealer(standOn, drawOnSoft);

            //Add cards to hand
            m_hand.AddCardToHand(1);
            m_hand.AddCardToHand(4);

            //Verify that dealer draws when hand is less than 17
            Assert.AreEqual(BlackJack.ActionType.Draw, m_dealer.GetAction(m_hand));
        }

        [TestMethod]
        public void TestDealerDrawOnSoft()
        {
            //Create the dealer
            int standOn = 17;
            bool drawOnSoft = true;
            CreateDealer(standOn, drawOnSoft);

            //Add cards to hand
            m_hand.AddCardToHand(6);
            m_hand.AddCardToHand(1);

            //Verify that dealer draws when hand soft 17
            Assert.AreEqual(BlackJack.ActionType.Draw, m_dealer.GetAction(m_hand));
        }

        [TestMethod]
        public void TestDealerStandOnSoft()
        {
            //Create the dealer
            int standOn = 17;
            bool drawOnSoft = false;
            CreateDealer(standOn, drawOnSoft);

            //Add cards to hand
            m_hand.AddCardToHand(6);
            m_hand.AddCardToHand(1);

            //Verify that dealer stops when hand is soft 17
            Assert.AreEqual(BlackJack.ActionType.Stop, m_dealer.GetAction(m_hand));
        }

        [TestMethod]
        public void TestDealerNegativeInit()
        {
            //Create the dealer
            int standOn = 0;
            bool drawOnSoft = false;
            CreateDealer(standOn, drawOnSoft);

            //Add cards to hand
            m_hand.AddCardToHand(1);
            m_hand.AddCardToHand(1);
            m_hand.AddCardToHand(5);

            //Verify that dealer stops when hand is soft 17
            Assert.AreEqual(BlackJack.ActionType.Stop, m_dealer.GetAction(m_hand));
        }

        [TestMethod]
        public void TestDealerToBigInit()
        {
            //Create the dealer
            int standOn = 22;
            bool drawOnSoft = false;
            CreateDealer(standOn, drawOnSoft);

            //Add cards to hand
            m_hand.AddCardToHand(1);
            m_hand.AddCardToHand(1);
            m_hand.AddCardToHand(4);

            //Verify that dealer stops when hand is soft 16
            Assert.AreEqual(BlackJack.ActionType.Draw, m_dealer.GetAction(m_hand));
        }

        /// <summary>
        /// Wrapper method to create a dealer.
        /// </summary>
        /// <param name="standOn"></param>
        /// <param name="drawOnSoft"></param>
        private void CreateDealer(int standOn, bool drawOnSoft)
        {
            m_dealer = new BlackJack.Dealer(standOn, drawOnSoft);
        }
    }
}
