using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    /// <summary>
    /// Class that holds the rules for a black jack player.
    /// </summary>
    public class PlayerRules
    {
        private int standOn;
        private int nrOfGames;

        /// <summary>
        /// Property for standon - when to stop draw cards.
        /// </summary>
        public int StandOn
        {
            get { return standOn; }
            set { standOn = ((value > 0) && (value < 21)) ? value : 17; }
        }

        /// <summary>
        /// Property for number of games. 
        /// </summary>
        public int NrOFGames
        {
            get { return nrOfGames; }
            set { nrOfGames = ((value > 0) && (value < 51)) ? value : 50; }
        }
    }
}
