using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlackJackUnitTestProject
{
    [TestClass]
    public class PlayerRulesUnitTest
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
        public void VerifyConstructor()
        {
            Assert.AreEqual(17, m_playerRules.StandOn);
            Assert.AreEqual(50, m_playerRules.NrOFGames);
        }

        [TestMethod]
        public void VerifyDefaultValues()
        {
            m_playerRules.StandOn = 21;
            Assert.AreEqual(17, m_playerRules.StandOn);
            m_playerRules.StandOn = 0;
            Assert.AreEqual(17, m_playerRules.StandOn);

            m_playerRules.NrOFGames = 51;
            Assert.AreEqual(50, m_playerRules.NrOFGames);
            m_playerRules.NrOFGames = 0;
            Assert.AreEqual(50, m_playerRules.NrOFGames);
        }
    }
}
