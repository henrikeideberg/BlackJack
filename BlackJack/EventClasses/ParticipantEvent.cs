using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    /// <summary>
    /// Class used when sending Participant events,
    /// e.g. connect and disconnet of player.
    /// </summary>
    public class ParticipantEvent : BasicEvent
    {
        private int m_tablePosition;
        private string m_name;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="tablePosition"></param>
        /// <param name="name"></param>
        public ParticipantEvent(int tablePosition, string name) : base()
        {
            m_tablePosition = tablePosition;
            m_name = name;
        }

        /// <summary>
        /// Table position of the participant.
        /// </summary>
        public int TablePosition
        {
            get { return m_tablePosition; }
        }

        /// <summary>
        /// Name of the participant.
        /// </summary>
        public string Name
        {
            get { return m_name; }
        }
    }
}
