namespace BlackJack
{
    /// <summary>
    /// enum to describe the different actions a black jack 
    /// participant can take.
    /// </summary>
    public enum ActionType
    {
        /// <summary>
        /// To double the stake on a hand
        /// </summary>
        Double,
        /// <summary>
        /// To draw a card from the deck
        /// </summary>
        Draw,
        /// <summary>
        /// To split the hand in two.
        /// </summary>
        Split,
        /// <summary>
        /// Stop (no more cards will be dealt to the hand)
        /// </summary>
        Stop
    }
}
