using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqFaroShuffle
{
    #region snippet2
    public enum Suit
    {
        Clubs,
        Diamonds,
        Hearts,
        Spades
    }
    #endregion

    #region snippet3
    public enum Rank
    {
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        Ace
    }
    #endregion

    public class Program
    {
        #region snippet4
        static IEnumerable<Suit> Suits() => (Enum.GetValues(typeof(Suit)) as IEnumerable<Suit>)!;
        #endregion

        #region snippet5
        static IEnumerable<Rank> Ranks() => (Enum.GetValues(typeof(Rank)) as IEnumerable<Rank>)!;
        #endregion

        #region snippet1
        public static void Main(string[] args)
        {
            IEnumerable<Suit>? suits = Suits();
            IEnumerable<Rank>? ranks = Ranks();

            if ((suits is null) || (ranks is null))
                return;

            var startingDeck = (from s in suits.LogQuery("Suit Generation")
                                from r in ranks.LogQuery("Value Generation")
                                select new { Suit = s, Rank = r })
                                .LogQuery("Starting Deck")
                                .ToArray();

            foreach (var c in startingDeck)
            {
                Console.WriteLine(c);
            }

            Console.WriteLine();

            var times = 0;
            var shuffle = startingDeck;

            do
            {
                /*
                shuffle = shuffle.Take(26)
                    .LogQuery("Top Half")
                    .InterleaveSequenceWith(shuffle.Skip(26).LogQuery("Bottom Half"))
                    .LogQuery("Shuffle")
                    .ToArray();
                */

                shuffle = shuffle.Skip(26)
                    .LogQuery("Bottom Half")
                    .InterleaveSequenceWith(shuffle.Take(26).LogQuery("Top Half"))
                    .LogQuery("Shuffle")
                    .ToArray();

                foreach (var c in shuffle)
                {
                    Console.WriteLine(c);
                }

                times++;
                Console.WriteLine(times);
            } while (!startingDeck.SequenceEquals(shuffle));

            Console.WriteLine(times);
        }
        #endregion
    }
}
