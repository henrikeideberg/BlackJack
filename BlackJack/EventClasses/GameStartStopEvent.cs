using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    /// <summary>
    /// Event used when informing table, dealer and players that a game has started or stopped/is finished.
    /// </summary>
    public class GameStartStopEvent : AllHandsEvent
    {
        private int m_gameId;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="handRecord"></param>
        /// <param name="gameId"></param>
        public GameStartStopEvent(Dictionary<int, List<Hand>> handRecord, int gameId) : base(handRecord)
        {
            m_gameId = gameId;
        }

        /// <summary>
        /// Game id
        /// </summary>
        public int GameId
        {
            get { return m_gameId; }
        }
    }
}
