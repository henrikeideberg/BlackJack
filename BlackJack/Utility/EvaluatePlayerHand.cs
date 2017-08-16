using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    /// <summary>
    /// Utility class to evaluate a blackjack hand.
    /// </summary>
    public class EvaluatePlayerHand
    {
        /// <summary>
        /// Method to check if hand is BlackJack (A/10).
        /// </summary>
        /// <param name="hand"></param>
        /// <returns></returns>
        static Hand CheckIfBJ(Hand hand)
        {
            //Get the hand value
            int index = hand.GetHandValue().Count - 1;
            int handValue = 0;
            if (ListManager.CheckListElementAvailable(hand.GetHandValue(), index))
            {
                handValue = hand.GetHandValue().ElementAt(index);
            }

            if ((hand.NrOfCards == 2) && (handValue == 21))
            {
                hand.BlackJack = true;
                hand.InPlay = false;
            }
            return hand;
        }

        /// <summary>
        /// Method to check if hand is bust (i.e. > 21).
        /// </summary>
        /// <param name="hand"></param>
        /// <returns></returns>
        static Hand CheckIfBust(Hand hand)
        {
            //Get the hand value
            int indexOfSmallestValue = 0;
            int handValue = 99;
            if (ListManager.CheckListElementAvailable(hand.GetHandValue(), indexOfSmallestValue))
            {
                handValue = hand.GetHandValue().ElementAt(indexOfSmallestValue);
            }
            if(handValue > 21) { hand.InPlay = false; }
            return hand;
        }

        /// <summary>
        /// Method to check if split is allowed on hand.
        /// </summary>
        /// <param name="rules"></param>
        /// <param name="hand"></param>
        /// <returns></returns>
        public static bool IsSplitAllowed(TableRules rules, Hand hand)
        {
            //Split not yet implemented/suported
            return false;
        }

        /// <summary>
        /// Meyhod to investigate if double is allowed on hand.
        /// </summary>
        /// <param name="rules"></param>
        /// <param name="hand"></param>
        /// <returns></returns>
        public static bool IsDoubleAllowed(TableRules rules, Hand hand)
        {
            //Double not supported
            return false;
        }

        /// <summary>
        /// Declare delegate type for processing a hand
        /// </summary>
        /// <param name="hand"></param>
        private delegate Hand ProcessHandDelegate(Hand hand);

        /// <summary>
        /// Method to evaluate hand and set BlackJack and/or unset InPlay flag
        /// if hand has BJ or is to big.
        /// </summary>
        /// <param name="hand"></param>
        /// <returns></returns>
        public static Hand ProcessHand(Hand hand)
        {
            ProcessHandDelegate processBJ = new ProcessHandDelegate(CheckIfBJ);
            hand = processBJ(hand);

            ProcessHandDelegate processBust = new ProcessHandDelegate(CheckIfBust);
            hand = processBust(hand);

            return hand;
        }
    }
}
