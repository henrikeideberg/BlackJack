using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace BlackJackUnitTestProject
{
    [TestClass]
    public class EvaluateWinningHandUnitTest
    {
        private BlackJack.Hand m_playerHand;
        private BlackJack.Hand m_dealerHand;

        [TestInitialize]
        public void Setup()
        {
            m_playerHand = new BlackJack.Hand(0);
            m_dealerHand = new BlackJack.Hand(0);
        }

        [TestCleanup]
        public void CleanUp()
        {
            m_dealerHand = null;
            m_playerHand = null;
        }

        /* Test scenarios
         * Test_1: player hand is 22 => false
         * Test_2: dealer hand is 22 and player hand is 21 => true
         * Test_3: player and dealer hand is 17 => false
         * Test_4: player hand is BJ and dealer hand is 21 => true
         * Test_5: player hand is 21 and dealer hand is BJ => false
         * Test_6: player and dealer hand is BJ => false
         * Test_7: player and dealer hand is 21 => false
         * Test_8: player hand is 17 and dealer hand is BJ => false
         * Test_9: player hand is 17 and dealer hand is 18 => false
         * */

        [TestMethod]
        public void Test_9()
        {
            //Add card(s) to m_playerHand (17)
            m_playerHand.AddCardToHand(3);
            m_playerHand.AddCardToHand(8);
            m_playerHand.AddCardToHand(6);

            //Add card(s) to m_dealerHand (18)
            m_dealerHand.AddCardToHand(8);
            m_dealerHand.AddCardToHand(10);

            //Create instance of EvaluateWinningHand
            BlackJack.EvaluateWinningHand eval = new BlackJack.EvaluateWinningHand(m_dealerHand);

            Assert.IsFalse(eval.IsHandBetterThanDealerHand(m_playerHand));
        }

        [TestMethod]
        public void Test_8()
        {
            //Add card(s) to m_playerHand (17)
            m_playerHand.AddCardToHand(3);
            m_playerHand.AddCardToHand(8);
            m_playerHand.AddCardToHand(6);

            //Add card(s) to m_dealerHand (BJ)
            m_dealerHand.AddCardToHand(1);
            m_dealerHand.AddCardToHand(10);
            m_dealerHand.BlackJack = true;

            //Create instance of EvaluateWinningHand
            BlackJack.EvaluateWinningHand eval = new BlackJack.EvaluateWinningHand(m_dealerHand);

            Assert.IsFalse(eval.IsHandBetterThanDealerHand(m_playerHand));
        }

        [TestMethod]
        public void Test_7()
        {
            //Add card(s) to m_playerHand (21)
            m_playerHand.AddCardToHand(4);
            m_playerHand.AddCardToHand(7);
            m_playerHand.AddCardToHand(10);

            //Add card(s) to m_dealerHand (21)
            m_dealerHand.AddCardToHand(10);
            m_dealerHand.AddCardToHand(3);
            m_dealerHand.AddCardToHand(8);

            //Create instance of EvaluateWinningHand
            BlackJack.EvaluateWinningHand eval = new BlackJack.EvaluateWinningHand(m_dealerHand);

            Assert.IsFalse(eval.IsHandBetterThanDealerHand(m_playerHand));
        }

        [TestMethod]
        public void Test_6()
        {
            //Add card(s) to m_playerHand (BJ)
            m_playerHand.AddCardToHand(1);
            m_playerHand.AddCardToHand(10);
            m_playerHand.BlackJack = true;

            //Add card(s) to m_dealerHand (BJ)
            m_dealerHand.AddCardToHand(10);
            m_dealerHand.AddCardToHand(1);
            m_dealerHand.BlackJack = true;

            //Create instance of EvaluateWinningHand
            BlackJack.EvaluateWinningHand eval = new BlackJack.EvaluateWinningHand(m_dealerHand);

            Assert.IsFalse(eval.IsHandBetterThanDealerHand(m_playerHand));
        }

        [TestMethod]
        public void Test_5()
        {
            //Add card(s) to m_playerHand (21)
            m_playerHand.AddCardToHand(5);
            m_playerHand.AddCardToHand(10);
            m_playerHand.AddCardToHand(6);

            //Add card(s) to m_dealerHand (BJ)
            m_dealerHand.AddCardToHand(10);
            m_dealerHand.AddCardToHand(1);
            m_dealerHand.BlackJack = true;

            //Create instance of EvaluateWinningHand
            BlackJack.EvaluateWinningHand eval = new BlackJack.EvaluateWinningHand(m_dealerHand);

            Assert.IsFalse(eval.IsHandBetterThanDealerHand(m_playerHand));
        }

        [TestMethod]
        public void Test_4()
        {
            //Add card(s) to m_playerHand (BJ)
            m_playerHand.AddCardToHand(1);
            m_playerHand.AddCardToHand(10);
            m_playerHand.BlackJack = true;

            //Add card(s) to m_dealerHand (21)
            m_dealerHand.AddCardToHand(10);
            m_dealerHand.AddCardToHand(2);
            m_dealerHand.AddCardToHand(9);

            //Create instance of EvaluateWinningHand
            BlackJack.EvaluateWinningHand eval = new BlackJack.EvaluateWinningHand(m_dealerHand);

            Assert.IsTrue(eval.IsHandBetterThanDealerHand(m_playerHand));
        }

        [TestMethod]
        public void Test_3()
        {
            //Add card(s) to m_playerHand (17)
            m_playerHand.AddCardToHand(7);
            m_playerHand.AddCardToHand(10);

            //Add card(s) to m_dealerHand (17)
            m_dealerHand.AddCardToHand(10);
            m_dealerHand.AddCardToHand(7);

            //Create instance of EvaluateWinningHand
            BlackJack.EvaluateWinningHand eval = new BlackJack.EvaluateWinningHand(m_dealerHand);

            Assert.IsFalse(eval.IsHandBetterThanDealerHand(m_playerHand));
        }

        [TestMethod]
        public void Test_2()
        {
            //Add card(s) to m_playerHand (21)
            m_playerHand.AddCardToHand(7);
            m_playerHand.AddCardToHand(5);
            m_playerHand.AddCardToHand(9);

            //Add card(s) to m_dealerHand (22)
            m_dealerHand.AddCardToHand(10);
            m_dealerHand.AddCardToHand(2);
            m_dealerHand.AddCardToHand(10);

            //Create instance of EvaluateWinningHand
            BlackJack.EvaluateWinningHand eval = new BlackJack.EvaluateWinningHand(m_dealerHand);

            Assert.IsTrue(eval.IsHandBetterThanDealerHand(m_playerHand));
        }

        [TestMethod]
        public void Test_1()
        {
            //Add card(s) to m_playerHand (22)
            m_playerHand.AddCardToHand(7);
            m_playerHand.AddCardToHand(5);
            m_playerHand.AddCardToHand(10);

            //Add card(s) to m_dealerHand (17)
            m_dealerHand.AddCardToHand(10);
            m_dealerHand.AddCardToHand(7);

            //Create instance of EvaluateWinningHand
            BlackJack.EvaluateWinningHand eval = new BlackJack.EvaluateWinningHand(m_dealerHand);

            Assert.IsFalse(eval.IsHandBetterThanDealerHand(m_playerHand));
        }
    }
}
