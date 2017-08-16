using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    /// <summary>
    /// Interface IParticipant represents a black jack participant.
    /// </summary>
    public interface IParticipant
    {
        /// <summary>
        /// Name of Participant
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Whether of not the Participant is actively playing.
        /// Can be set if for example the player joins or leaves in middle of a game.
        /// </summary>
        bool Active { get; }

        /// <summary>
        /// Position of the participant at the table
        /// </summary>
        int TablePosition { get; }
    }
}
