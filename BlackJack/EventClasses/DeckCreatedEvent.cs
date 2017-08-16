using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    /// <summary>
    /// Class which contains defines the event when
    /// a black jack deck is created. When en event is
    /// fired, the class is sent with the event notifier.
    /// </summary>
    public class DeckCreatedEvent : BasicEvent
    {
        private int m_nrOfDecks;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="nrOfDecks"></param>
        public DeckCreatedEvent(int nrOfDecks) : base()
        {
            m_nrOfDecks = nrOfDecks;
        }

        /// <summary>
        /// How many decks in the black jack deck.
        /// </summary>
        public int NumberOfDecks
        {
            get { return m_nrOfDecks; }
        }
    }
}
