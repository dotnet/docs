namespace LinqFaroShuffle
{
    #region snippet1
    public class PlayingCard
    {
        public Suit CardSuit { get; }
        public Rank CardRank { get; }

        public PlayingCard(Suit s, Rank r)
        {
            CardSuit = s;
            CardRank = r;
        }

        public override string ToString()
        {
            return $"{CardRank} of {CardSuit}";
        }
    }
    #endregion
}
