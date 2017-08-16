using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    /// <summary>
    /// Class Dealer which inherits the abstract class Participant.
    /// </summary>
    public class Dealer : Participant
    {
        private int m_standOn;      //At what handvalue dealer shall stand
        private bool m_drawOnSoft;  //Whether or not dealer should hit on soft hand

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="standOn"></param>
        /// <param name="hitOnSoft"></param>
        public Dealer(int standOn,
                      bool hitOnSoft) : base("Dealer", 7)//Dealer is always at position 7 (last position)
        {
            InitDealer(standOn, hitOnSoft);
        }

        /// <summary>
        /// Initialise the dealer specific attributes
        /// </summary>
        /// <param name="standOn"></param>
        /// <param name="drawOnSoft"></param>
        private void InitDealer(int standOn, bool drawOnSoft)
        {
            //standOn shall be in the range 1-21. If out of range set to default, 17
            m_standOn = ((standOn > 21) || (standOn < 1)) ? 17 : standOn; //m_standOn is default 17
            m_drawOnSoft = drawOnSoft;
        }

        /// <summary>
        /// Method to calculate next action for dealer.
        /// The next action is either Stop or Draw.
        /// </summary>
        /// <param name="activeHand"></param>
        /// <returns></returns>
        public override ActionType GetAction(Hand activeHand)
        {
            ActionType action = ActionType.Stop; //Set default action to Stop.

            if(activeHand.GetHandValue().Count() == 1) //only one value
            {
                if(ListManager.CheckListElementAvailable(activeHand.GetHandValue(), 0))
                {
                    if(activeHand.GetHandValue().ElementAt(0) < m_standOn)
                    {
                        //Set action to Draw in case hand value is less than threshold
                        action = ActionType.Draw;
                    }
                }
            }
            else//multiple values (ace(s) in hand)
            {
                int index = activeHand.GetHandValue().Count - 1;//Get index of biggets handvalue
                if (ListManager.CheckListElementAvailable(activeHand.GetHandValue(), index))
                {
                    if((activeHand.GetHandValue().ElementAt(index) == m_standOn) && m_drawOnSoft)
                    {
                        //Set action to Draw if draw on soft
                        action = ActionType.Draw;
                    }
                    if(activeHand.GetHandValue().ElementAt(index) < m_standOn)
                    {
                        //Set action to Draw if handvalue is less than threshold
                        action = ActionType.Draw;
                    }
                }
            }
            return action;
        }
    }
}
