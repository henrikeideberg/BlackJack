using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    /// <summary>
    /// Evant class used when sending all hands to all subscribers (i.e. players).
    /// </summary>
    public class AllHandsEvent : EventArgs
    {
        Dictionary<int, List<Hand>> m_handRecord;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="handRecord"></param>
        public AllHandsEvent(Dictionary<int, List<Hand>> handRecord)
        {
            m_handRecord = handRecord;
        }

        /// <summary>
        /// Record with all the hands.
        /// </summary>
        public Dictionary<int, List<Hand>> HandRecord
        {
            get { return m_handRecord; }
        }
    }
}
