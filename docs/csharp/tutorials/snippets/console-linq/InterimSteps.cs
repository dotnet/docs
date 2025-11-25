namespace UnusedCode;

using LinqFaroShuffle;
internal class InterimSteps
{
    // <StepOne>
    static IEnumerable<string> Suits()
    {
        yield return "clubs";
        yield return "diamonds";
        yield return "hearts";
        yield return "spades";
    }

    static IEnumerable<string> Ranks()
    {
        yield return "two";
        yield return "three";
        yield return "four";
        yield return "five";
        yield return "six";
        yield return "seven";
        yield return "eight";
        yield return "nine";
        yield return "ten";
        yield return "jack";
        yield return "queen";
        yield return "king";
        yield return "ace";
    }
    // </StepOne>

    private static void InitialMain()
    {
        // <StepTwo>
        var startingDeck = from s in Suits()
                           from r in Ranks()
                           select  (Suit: s, Rank: r);
        
        // Display each card that we've generated and placed in startingDeck in the console
        foreach (var card in startingDeck)
        {
            Console.WriteLine(card);
        }
        // </StepTwo>

        // <StepThree>
        var top = startingDeck.Take(26);
        var bottom = startingDeck.Skip(26);
        // </StepThree>

    }

    private void StartShuffling()
    {
        // <StepThree>
        var startingDeck = from s in Suits()
                           from r in Ranks()
                           select (Suit: s, Rank: r);

        // Display each card that we've generated and placed in startingDeck in the console
        foreach (var card in startingDeck)
        {
            Console.WriteLine(card);
        }

        var top = startingDeck.Take(26);
        var bottom = startingDeck.Skip(26);
        // </StepThree>

        // <StepFive>
        var shuffledDeck = top.InterleaveSequenceWith(bottom);

        foreach (var c in shuffledDeck)
        {
            Console.WriteLine(c);
        }
        // </StepFive>
    }

    private void CompareSequences()
    {
        // <StepSix>
        var startingDeck = from s in Suits()
                           from r in Ranks()
                           select (Suit: s, Rank: r);

        // Display each card that we've generated and placed in startingDeck in the console
        foreach (var card in startingDeck)
        {
            Console.WriteLine(card);
        }

        var top = startingDeck.Take(26);
        var bottom = startingDeck.Skip(26);

        var shuffledDeck = top.InterleaveSequenceWith(bottom);

        var times = 0;
        // We can re-use the shuffle variable from earlier, or you can make a new one
        shuffledDeck = startingDeck;
        do
        {
            shuffledDeck = shuffledDeck.Take(26).InterleaveSequenceWith(shuffledDeck.Skip(26));

            foreach (var card in shuffledDeck)
            {
                Console.WriteLine(card);
            }
            Console.WriteLine();
            times++;

        } while (!startingDeck.SequenceEquals(shuffledDeck));

        Console.WriteLine(times);
        // </StepSix>
    }

    private void AddLogging()
    {
        // <StepSeven>
        var startingDeck = (from s in Suits().LogQuery("Suit Generation")
                            from r in Ranks().LogQuery("Rank Generation")
                            select (Suit: s, Rank: r)).LogQuery("Starting Deck");

        foreach (var c in startingDeck)
        {
            Console.WriteLine(c);
        }

        Console.WriteLine();
        var times = 0;
        var shuffle = startingDeck;

        do
        {
            // Out shuffle
            /*
            shuffle = shuffle.Take(26)
                .LogQuery("Top Half")
                .InterleaveSequenceWith(shuffle.Skip(26)
                .LogQuery("Bottom Half"))
                .LogQuery("Shuffle");
            */

            // In shuffle
            shuffle = shuffle.Skip(26).LogQuery("Bottom Half")
                    .InterleaveSequenceWith(shuffle.Take(26).LogQuery("Top Half"))
                    .LogQuery("Shuffle");

            foreach (var c in shuffle)
            {
                Console.WriteLine(c);
            }

            times++;
            Console.WriteLine(times);
        } while (!startingDeck.SequenceEquals(shuffle));

        Console.WriteLine(times);
        // </StepSeven>
    }
}

// <StepFour>
public static class CardExtensions
{
    extension<T>(IEnumerable<T> sequence)
    {
        public IEnumerable<T> InterleaveSequenceWith(IEnumerable<T> second)
        {
            // Your implementation goes here
            return default;
        }
    }
}
// </StepFour>


