using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlackJackUnitTestProject
{
    [TestClass]
    public class DeckUnitTest
    {
        BlackJack.Deck m_deck;
        BlackJack.Deck m_deckCompare;

        [TestInitialize]
        public void Setup()
        {
            //nothing for now
        }

        [TestCleanup]
        public void CleanUp()
        {
            m_deck = null;
            m_deckCompare = null;
        }

        [TestMethod]
        public void CreateDeck_1Deck()
        {
            //Create BJ deck with one deck
            m_deck = new BlackJack.Deck(1);

            //Verify that we have all cards
            ValidateCardsInDeck(1);
        }

        [TestMethod]
        public void CreateDeck_2Deck()
        {
            //Create BJ deck with two decks
            m_deck = new BlackJack.Deck(2);

            //Verify that we have all cards
            ValidateCardsInDeck(2);
        }

        [TestMethod]
        public void CreateDeck_4Deck()
        {
            //Create BJ deck with four decks
            m_deck = new BlackJack.Deck(4);

            //Verify that we have all cards
            ValidateCardsInDeck(4);
        }

        [TestMethod]
        public void CreateDeck_6Deck()
        {
            //Create BJ deck with six decks
            m_deck = new BlackJack.Deck(6);

            //Verify that we have all cards
            ValidateCardsInDeck(6);
        }

        [TestMethod]
        public void CreateDeck_8Deck()
        {
            //Create BJ deck with eight decks
            m_deck = new BlackJack.Deck(8);

            //Verify that we have all cards
            ValidateCardsInDeck(8);
        }

        [TestMethod]
        public void CreateDeck_3Deck()
        {
            //Create BJ deck with eight decks.
            //Three is an invlaid number,
            //hence default value eight will be used.
            m_deck = new BlackJack.Deck(3);

            //Verify that we have all cards
            ValidateCardsInDeck(8);
        }

        [TestMethod]
        public void VerifyInitialShuffle()
        {
            //Create two decks and verify they are not same.
            m_deck = new BlackJack.Deck(1);
            m_deckCompare = new BlackJack.Deck(1);
            Assert.AreNotEqual(m_deck, m_deckCompare);

            //Draw cards from both decks and
            //compare the cards. This is to verify
            //that the shuffle is random.
            int equal = 0;
            int notEqual = 0;
            for (int i = 0; i < 52; i++)
            {
                if (m_deck.Draw() == m_deckCompare.Draw()) { equal++; }
                else { notEqual++; }
            }

            //Verify that there are more than 0 non-equal cards
            Assert.AreNotEqual(equal, 52);
            Assert.AreNotEqual(notEqual, 0);
        }

        [TestMethod]
        public void VerifyReShuffle()
        {
            //Verify that Reshuffle operation works.
            //After a reshuffle operation the decks
            //shall have all cards.
            m_deck = new BlackJack.Deck(1);
            DrawCards(22);
            m_deck.Reshuffle();
            Assert.AreEqual(m_deck.GetSizeOfDeck(), 52);
        }

        [TestMethod]
        public void VerifyGetDeck()
        {
            //Verify that it is posible to get correct
            //amount of cards in deck from GetSizeOfDeck
            //method.
            m_deck = new BlackJack.Deck(1);
            Assert.AreEqual(m_deck.GetSizeOfDeck(), 52);
            DrawCards(9);
            Assert.AreEqual(m_deck.GetSizeOfDeck(), 43); 
        }

        /// <summary>
        /// Draw int nrOfCards from m_deck.
        /// </summary>
        /// <param name="nrOfCards"></param>
        private void DrawCards(int nrOfCards)
        {
            for(int i=0; i<nrOfCards; i++)
            {
                int card = m_deck.Draw();
            }
        }

        /// <summary>
        /// Method to check that created deck
        /// has correct number of cards.
        /// </summary>
        /// <param name="nrOfDecks"></param>
        private void ValidateCardsInDeck(int nrOfDecks)
        {
            int receivedAces, receivedTwos, receivedThrees,
                receivedFours, receivedFives, receivedSixes,
                receivedSevens, receivedEights, receivedNines,
                receivedTens;

            int expectedAces, expectedTwos, expectedThrees,
                expectedFours, expectedFives, expectedSixes,
                expectedSevens, expectedEights, expectedNines,
                expectedTens;

            receivedAces = receivedTwos = receivedThrees =
            receivedFours = receivedFives = receivedSixes =
            receivedSevens = receivedEights = receivedNines =
            receivedTens = 0;

            expectedAces = expectedTwos = expectedThrees =
            expectedFours = expectedFives = expectedSixes =
            expectedSevens = expectedEights = expectedNines = 4*nrOfDecks;
            expectedTens = 16*nrOfDecks;

            for (int i = 1; i <= 52*nrOfDecks; i++)
            {
                int card = m_deck.Draw();

                switch (card)
                {
                    case 1:
                        receivedAces++;
                        break;
                    case 2:
                        receivedTwos++;
                        break;
                    case 3:
                        receivedThrees++;
                        break;
                    case 4:
                        receivedFours++;
                        break;
                    case 5:
                        receivedFives++;
                        break;
                    case 6:
                        receivedSixes++;
                        break;
                    case 7:
                        receivedSevens++;
                        break;
                    case 8:
                        receivedEights++;
                        break;
                    case 9:
                        receivedNines++;
                        break;
                    case 10:
                        receivedTens++;
                        break;
                    default:
                        Assert.IsTrue(false);
                        break;
                }
            }

            //Verify that all cards are there
            Assert.AreEqual(expectedAces, receivedAces);
            Assert.AreEqual(expectedTwos, receivedTwos);
            Assert.AreEqual(expectedThrees, receivedThrees);
            Assert.AreEqual(expectedFours, receivedFours);
            Assert.AreEqual(expectedFives, receivedFives);
            Assert.AreEqual(expectedSixes, receivedSixes);
            Assert.AreEqual(expectedSevens, receivedSevens);
            Assert.AreEqual(expectedEights, receivedEights);
            Assert.AreEqual(expectedNines, receivedNines);
            Assert.AreEqual(expectedTens, receivedTens);
        }
    }
}
