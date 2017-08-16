using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    /// <summary>
    /// Event used by the HumanPlayer to inform table what action the player wants to do,
    /// e.g. Draw.
    /// </summary>
    public class HumanPlayerActionEvent
    {
        private ActionType m_action;
        private int m_handId;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="action"></param>
        /// <param name="handId"></param>
        public HumanPlayerActionEvent(ActionType action, int handId)
        {
            m_action = action;
            m_handId = handId;
        }

        /// <summary>
        /// Action taken by the human player.
        /// </summary>
        public ActionType HumanPlayerAction
        {
            get { return m_action; }
        }

        /// <summary>
        /// Hand id to identify the hand for which the action applies.
        /// </summary>
        public int HandId
        {
            get { return m_handId; }
        }
    }
}
