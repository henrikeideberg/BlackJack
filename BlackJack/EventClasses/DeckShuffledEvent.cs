using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    /// <summary>
    /// Event telling that deck has been shuffled
    /// </summary>
    public class DeckShuffledEvent : BasicEvent
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public DeckShuffledEvent() : base()
        {
            //Rely on base constructor
        }
    }
}
