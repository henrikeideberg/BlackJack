using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    /// <summary>
    /// Class that represents a black jack hand
    /// </summary>
    public class Hand
    {
        private int m_handId;
        private List<int> m_listOfCards;
        private int m_numberOfSplits;
        private bool m_splitAces;
        private bool m_isDoubled;
        private bool m_blackJack;
        private bool m_inPlay;
        private bool m_winningHand;
        private bool m_dealerHand;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="handId"></param>
        public Hand(int handId)
        {
            m_listOfCards = new List<int>();
            m_handId = handId;
            m_numberOfSplits = 0;
            m_splitAces = false;
            m_isDoubled = false;
            m_blackJack = false;
            m_inPlay = true;
            m_winningHand = false;
            m_dealerHand = false;
        }

        /// <summary>
        /// Number of cards in hand
        /// </summary>
        public int NrOfCards
        {
            get { return m_listOfCards.Count; }
        }

        /// <summary>
        /// Hand id
        /// </summary>
        public int HandId
        {
            get { return m_handId; }
        }

        /// <summary>
        /// Number of splits done by hand
        /// </summary>
        public int NumberOfSplits
        {
            set { m_numberOfSplits = value; }
            get { return m_numberOfSplits; }
        }

        /// <summary>
        /// If hand contains split aces.
        /// </summary>
        public bool SplitAces
        {
            set { m_splitAces = value; }
            get { return m_splitAces; }
        }

        /// <summary>
        /// If hand is doubled.
        /// </summary>
        public bool IsDoubled
        {
            set { m_isDoubled = value; }
            get { return m_isDoubled; }
        }

        /// <summary>
        /// If hand has black jack.
        /// </summary>
        public bool BlackJack
        {
            set { m_blackJack = value; }
            get { return m_blackJack; }
        }

        /// <summary>
        /// If hand is still in play
        /// </summary>
        public bool InPlay
        {
            set { m_inPlay = value; }
            get { return m_inPlay; }
        }

        /// <summary>
        /// If this is a winning hand (evaluated at end of game)
        /// </summary>
        public bool WinningHand
        {
            set { m_winningHand = value; }
            get { return m_winningHand; }
        }

        /// <summary>
        /// If this is the hand of the dealer
        /// </summary>
        public bool DealerHand
        {
            set { m_dealerHand = value; }
            get { return m_dealerHand; }
        }

        /// <summary>
        /// Method to calculate and get the handvalue.
        /// Ace is represented with one ini this deck.
        /// Value greater than 21 is not included, unless it is
        /// the only available value (the 'basic' value).
        /// </summary>
        /// <returns></returns>
        public List<int> GetHandValue()
        {
            List<int> handValue = new List<int>();
            int sum = 0;
            int nrOfAces = 0;

            for (int i = 0; i < m_listOfCards.Count; i++)
            {
                //Ace is represented by one in the deck
                sum = sum + m_listOfCards.ElementAt(i);

                //Count the number of aces/ones
                if(m_listOfCards.ElementAt(i) == 1)
                {
                    nrOfAces++;
                }
            }

            //Add the 'basic' value to the handValue list
            handValue.Add(sum);

            //For each ace, add ten
            for(int i = 0; i < nrOfAces; i++)
            {
                sum = sum + 10;
                if (sum < 22) { handValue.Add(sum); } //only add valid sums
            }

            return handValue;
        }

        /// <summary>
        /// Method to add card to hand.
        /// </summary>
        /// <param name="card"></param>
        public void AddCardToHand(int card)
        {
            m_listOfCards.Add(card);
        }

        /// <summary>
        /// Method to return the hand (the cards) as a string.
        /// </summary>
        /// <returns></returns>
        public string HandToString()
        {
            string hand = "";
            if(ListManager.CheckListElementAvailable(m_listOfCards, 0))
            {
                hand = Convertions.ConvertOneToAce(m_listOfCards.ElementAt(0).ToString());

                for (int i = 1; i < m_listOfCards.Count; i++)
                {
                    hand = hand + "/" + Convertions.ConvertOneToAce(m_listOfCards.ElementAt(i).ToString());
                }
            }
            return hand;
        }

        /// <summary>
        /// Method to return the hand value as a string.
        /// </summary>
        /// <returns></returns>
        public string HandValueToString()
        {
            string handValue = "";
            if(ListManager.CheckListElementAvailable(GetHandValue(), 0))
            {
                handValue = GetHandValue().ElementAt(0).ToString();
                
                for(int i = 1; i < GetHandValue().Count(); i++)
                {
                    handValue = handValue + "/" + GetHandValue().ElementAt(i).ToString();
                }
            }
            return handValue;
        }

        /// <summary>
        /// Method to output the hand in string format. Used by the
        /// log and the text exporting functionality
        /// </summary>
        /// <returns></returns>
        public string LogString()
        {
            return HandId.ToString() + "; " +
                   HandToString() + "; " +
                   HandValueToString() + "; " +
                   NumberOfSplits.ToString() + "; " +
                   SplitAces.ToString() + "; " +
                   IsDoubled.ToString() + "; " +
                   BlackJack.ToString() + "; " +
                   WinningHand.ToString() + "; " +
                   DealerHand.ToString();
        }
    }
}
