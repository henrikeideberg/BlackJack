using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    /// <summary>
    /// Class that is used by deck-events e.g. when deck is created or shuffled.
    /// </summary>
    public abstract class BasicEvent : EventArgs
    {
        private DateTime m_timestamp;

        /// <summary>
        /// Constructor
        /// </summary>
        public BasicEvent()
        {
            m_timestamp = DateTime.Now;
        }

        /// <summary>
        /// Time stamp
        /// </summary>
        public DateTime TimeStamp
        {
            get { return m_timestamp; }
        }
    }
}
