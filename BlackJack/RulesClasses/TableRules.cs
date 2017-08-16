using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    /// <summary>
    /// Class that holds the table-rules for the BlackJack game.
    /// </summary>
    public class TableRules
    {
        /// <summary>
        /// Number of resplits
        ///   Default: No limit (-1)
        /// </summary>
        public int NumberOfResplits
        { get; set; }

        /// <summary>
        /// Number of splits on aces
        ///   Default: 1
        /// </summary>
        public int NumberOfSplitsOnAces
        { get; set; }

        /// <summary>
        /// How many cards are allowed after player split aces.
        ///   Default: 1
        /// </summary>
        public int NumberOfCardsAfterSplitAces
        { get; set; }

        /// <summary>
        /// Allow double after aces have been spli
        ///   Defaul: false
        /// </summary>
        public bool AllowDoubleOnSplitAces
        { get; set; }

        /// <summary>
        /// Allow double after 'normal' split
        ///   Default: true
        /// </summary>
        public bool AllowDoubleAfterSplit
        { get; set; }

        /// <summary>
        /// Allow double on soft hands.
        ///   Default: false
        /// </summary>
        public bool AllowDoubleOnSoftHands
        { get; set; }

        /// <summary>
        /// Minimum hand value allowed to double on
        ///   Default: 9
        /// </summary>
        public int DoubleMin
        { get; set; }

        /// <summary>
        /// Maximum hand value allowed to double on
        ///   Default: 11
        /// </summary>
        public int DoubleMax
        { get; set; }

        /// <summary>
        /// Dealer wins at tie
        ///   Default: false
        /// </summary>
        public bool DealerWinsAtTie
        { get; set;  }
    }
}
