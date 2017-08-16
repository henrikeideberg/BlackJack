using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    /// <summary>
    /// Class used to evaluate player hand against
    /// a dealer hand.
    /// </summary>
    public class EvaluateWinningHand
    {
        private Hand m_dealerHand;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dealerHand"></param>
        public EvaluateWinningHand(Hand dealerHand)
        {
            m_dealerHand = dealerHand;
        }

        /// <summary>
        /// Method which returns true if player hand is better than
        /// dealer hand.
        /// </summary>
        /// <param name="playerHand"></param>
        /// <returns></returns>
        public bool IsHandBetterThanDealerHand(Hand playerHand)
        {
            int index = 0;

            //Get the dealer hand value
            index = m_dealerHand.GetHandValue().Count - 1;
            int dealerHandValue = 0;
            if(ListManager.CheckListElementAvailable(m_dealerHand.GetHandValue(), index))
            {
                dealerHandValue = m_dealerHand.GetHandValue().ElementAt(index);
            }
            
            //Get the best player hand value
            index = playerHand.GetHandValue().Count - 1;
            int playerHandValue = 0;
            if(ListManager.CheckListElementAvailable(playerHand.GetHandValue(), index))
            {
                playerHandValue = playerHand.GetHandValue().ElementAt(index);
            }

            //Evaluate hand
            if (playerHandValue > 21) { return false; }

            if (dealerHandValue > 21)
            {
                if(playerHandValue < 22) { return true; }
            }
            else
            {
                if(playerHand.BlackJack && !m_dealerHand.BlackJack) { return true; }
                if(m_dealerHand.BlackJack) { return false; }
                if(dealerHandValue > playerHandValue) { return false; }
                if (dealerHandValue == playerHandValue) { return false; }
            }
            return true;
        }
    }
}
