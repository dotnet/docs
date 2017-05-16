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
        static IEnumerable<Suit> Suits()
        {
            yield return Suit.Clubs;
            yield return Suit.Diamonds;
            yield return Suit.Hearts;
            yield return Suit.Spades;
        }
        #endregion

        #region snippet5
        static IEnumerable<Rank> Ranks()
        {
            yield return Rank.Two;
            yield return Rank.Three;
            yield return Rank.Four;
            yield return Rank.Five;
            yield return Rank.Six;
            yield return Rank.Seven;
            yield return Rank.Eight;
            yield return Rank.Nine;
            yield return Rank.Ten;
            yield return Rank.Jack;
            yield return Rank.Queen;
            yield return Rank.King;
            yield return Rank.Ace;
        }
        #endregion

        #region snippet1
        public static void Main(string[] args)
        {
            var startingDeck = (from s in Suits().LogQuery("Suit Generation")
                                from r in Ranks().LogQuery("Value Generation")
                                select new PlayingCard(s, r))
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
