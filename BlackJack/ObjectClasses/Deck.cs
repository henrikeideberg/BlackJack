using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    /// <summary>
    /// Class which holds the functionality of a Black Jack deck
    /// </summary>
    public class Deck
    {
        private int m_nrOfDecks = 8;
        private List<int> m_listOfCards;

        /// <summary>
        /// Constructor which creates a black jack deck for
        /// int nrOfDecks.
        /// </summary>
        /// <param name="nrOfDecks"></param>
        public Deck(int nrOfDecks)
        {
            VerifyAndSetNrOfDecks(nrOfDecks);

            CreateShuffledBlackJackDeck();
        }

        /// <summary>
        /// Property for m_nrOfDecks
        /// </summary>
        public int NrOfDecks
        {
            get { return m_nrOfDecks; }
        }

        /// <summary>
        /// Method which sets the number of 'normal' decks
        /// that shall be used in the black jack deck.
        /// </summary>
        /// <param name="input"></param>
        private void VerifyAndSetNrOfDecks(int input)
        {
            m_nrOfDecks = input;
            //Allowed nr of decks are 1, 2, 4, 6 or 8
            if (!(input == 1 ||
                  input == 2 ||
                  input == 4 ||
                  input == 6 ||
                  input == 8 )) { m_nrOfDecks = 8; }
        }

        /// <summary>
        /// Method to create and shuffle a black jack deck
        /// </summary>
        private void CreateShuffledBlackJackDeck()
        {
            m_listOfCards = null;

            //Create and shuffle the deck/list of cards
            m_listOfCards = ListManager.Shuffle(CreateDeck());
        }

        /// <summary>
        /// Method to create a non shuffled deck/list of cards
        /// </summary>
        /// <returns></returns>
        private List<int> CreateDeck()
        {
            //In one deck we have
            //4 aces (represented as one), 4 twos, 4 threes, ..., 4 eights and 4 niness
            //16 10s

            List<int> nonShuffledDeck = new List<int>();

            for (int i = 1; i <= m_nrOfDecks; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    //Add the numbers 1-9 for each color
                    for (int k = 1; k < 10; k++)
                    {
                        nonShuffledDeck.Add(k);
                    }

                    //Add four 10s (four 10s for each color)
                    for (int l = 0; l < 4; l++)
                    {
                        nonShuffledDeck.Add(10);
                    }
                }
            }

            return nonShuffledDeck;
        }

        /// <summary>
        /// Method to draw a card from the deck/list of cards.
        /// The drawn card is removed.
        /// </summary>
        /// <returns>Drawn card (integer)</returns>
        public int Draw()
        {
            int card;

            //Only draw card if there are cards in deck
            if (m_listOfCards.Count <= 0)
            {
                Reshuffle();                
            }

            card = m_listOfCards.ElementAt(0);
            m_listOfCards.RemoveAt(0);
            return card;
        }

        /// <summary>
        /// Method to reshuffle the deck.
        /// </summary>
        public void Reshuffle()
        {
            CreateShuffledBlackJackDeck();
        }

        /// <summary>
        /// Method which returns the size of the deck, i.e.
        /// how many cards are available in the deck.
        /// </summary>
        /// <returns>Size of deck (type: int)</returns>
        public int GetSizeOfDeck()
        {
            return m_listOfCards.Count;
        }
    }
}
