using LinqFaroShuffle;

// <snippet4>
IEnumerable<Suit> suits() => (Enum.GetValues(typeof(Suit)) as IEnumerable<Suit>)!;
// </snippet4>

// <snippet5>
IEnumerable<Rank> ranks() => (Enum.GetValues(typeof(Rank)) as IEnumerable<Rank>)!;
// </snippet5>

// <snippet1>
var startingDeck = (from s in suits().LogQuery("Suit Generation")
                    from r in ranks().LogQuery("Value Generation")
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
// </snippet1>

// <snippet2>
public enum Suit
{
    Clubs,
    Diamonds,
    Hearts,
    Spades
}
// </snippet2>

// <snippet3>
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
// </snippet3>
