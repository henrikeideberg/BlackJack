using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlackJackUnitTestProject
{
    [TestClass]
    public class ComputerPlayerUnitTest
    {
        BlackJack.TableRules m_tableRules;
        BlackJack.PlayerRules m_playerRules;
        BlackJack.ComputerPlayer m_computerPlayer;
        BlackJack.Table m_table;
        BlackJack.Hand m_hand;

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
            m_playerRules = new BlackJack.PlayerRules
            {
                StandOn = 17,
                NrOFGames = 50
            };
            m_computerPlayer = new BlackJack.ComputerPlayer(m_table,
                                                            m_playerRules,
                                                            "DarthVader",
                                                            5);
            m_hand = new BlackJack.Hand(1);
        }

        [TestCleanup]
        public void CleanUp()
        {
            m_table = null;
            m_playerRules = null;
            m_computerPlayer = null;
            m_tableRules = null;
        }

        [TestMethod]
        public void Draw_NoAce()
        {
            //Add cards to hand so that sum is less than StandOn
            m_hand.AddCardToHand(6);
            m_hand.AddCardToHand(10); 

            Assert.AreEqual(BlackJack.ActionType.Draw, m_computerPlayer.GetAction(m_hand));
        }

        [TestMethod]
        public void Draw_Aces()
        {
            //Add cards to hand so that sum is less than StandOn
            m_hand.AddCardToHand(1);
            m_hand.AddCardToHand(1);
            m_hand.AddCardToHand(10);

            Assert.AreEqual(BlackJack.ActionType.Draw, m_computerPlayer.GetAction(m_hand));
        }

        [TestMethod]
        public void Stop_Ace()
        {
            //Add cards to hand so that sum is equal StandOn
            m_hand.AddCardToHand(1);
            m_hand.AddCardToHand(6);

            Assert.AreEqual(BlackJack.ActionType.Stop, m_computerPlayer.GetAction(m_hand));
        }

        [TestMethod]
        public void Stop_NoAce()
        {
            //Add cards to hand so that sum is equal StandOn
            m_hand.AddCardToHand(9);
            m_hand.AddCardToHand(8);

            Assert.AreEqual(BlackJack.ActionType.Stop, m_computerPlayer.GetAction(m_hand));
        }
    }
}
