using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    /// <summary>
    /// Abstract class that represents a black jack participant, e.g.
    /// dealer, human player or computer player.
    /// </summary>
    public abstract class Participant : IParticipant
    {
        private string m_name;
        private bool m_active;
        private int m_tablePosition;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="tablePosition"></param>
        public Participant(string name, int tablePosition)
        {
            m_name = name;
            m_active = true;
            m_tablePosition = tablePosition;
        }
        /// <summary>
        /// Name of participant.
        /// </summary>
        public string Name
        {
            get { return m_name; }
        }

        /// <summary>
        /// If participant still playing this game
        /// </summary>
        public bool Active
        {
            get { return m_active; }
            set { m_active = value; }
        }

        /// <summary>
        /// Table position of participant.
        /// </summary>
        public int TablePosition
        {
            get { return m_tablePosition; }
        }

        /// <summary>
        /// Method to provide the most basic implementation of
        /// participant-action.
        /// </summary>
        /// <param name="activeHand"></param>
        /// <returns></returns>
        public virtual ActionType GetAction(Hand activeHand)
        {
            return ActionType.Stop; //Set default action to Stop.
        }
    }
}
