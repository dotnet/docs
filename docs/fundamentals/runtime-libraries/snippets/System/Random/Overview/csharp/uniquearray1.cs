// <Snippet11>
using System;

// A class that represents an individual card in a playing deck.
public class Card
{
    public Suit Suit;
    public FaceValue FaceValue;

    public override String ToString()
    {
        return String.Format("{0:F} of {1:F}", this.FaceValue, this.Suit);
    }
}

public enum Suit { Hearts, Diamonds, Spades, Clubs };

public enum FaceValue
{
    Ace = 1, Two, Three, Four, Five, Six,
    Seven, Eight, Nine, Ten, Jack, Queen,
    King
};

public class Dealer
{
    Random rnd;
    // A deck of cards, without Jokers.
    Card[] deck = new Card[52];
    // Parallel array for sorting cards.
    Double[] order = new Double[52];
    // A pointer to the next card to deal.
    int ptr = 0;
    // A flag to indicate the deck is used.
    bool mustReshuffle = false;

    public Dealer()
    {
        rnd = new Random();
        // Initialize the deck.
        int deckCtr = 0;
        foreach (var suit in Enum.GetValues(typeof(Suit)))
        {
            foreach (var faceValue in Enum.GetValues(typeof(FaceValue)))
            {
                Card card = new Card();
                card.Suit = (Suit)suit;
                card.FaceValue = (FaceValue)faceValue;
                deck[deckCtr] = card;
                deckCtr++;
            }
        }

        for (int ctr = 0; ctr < order.Length; ctr++)
            order[ctr] = rnd.NextDouble();

        Array.Sort(order, deck);
    }

    public Card[] Deal(int numberToDeal)
    {
        if (mustReshuffle)
        {
            Console.WriteLine("There are no cards left in the deck");
            return null;
        }

        Card[] cardsDealt = new Card[numberToDeal];
        for (int ctr = 0; ctr < numberToDeal; ctr++)
        {
            cardsDealt[ctr] = deck[ptr];
            ptr++;
            if (ptr == deck.Length)
                mustReshuffle = true;

            if (mustReshuffle & ctr < numberToDeal - 1)
            {
                Console.WriteLine($"Can only deal the {ctr + 1} cards remaining on the deck.");
                return cardsDealt;
            }
        }
        return cardsDealt;
    }
}

public class Example17
{
    public static void Main()
    {
        Dealer dealer = new Dealer();
        ShowCards(dealer.Deal(20));
    }

    private static void ShowCards(Card[] cards)
    {
        foreach (var card in cards)
            if (card != null)
                Console.WriteLine($"{card.FaceValue} of {card.Suit}");
    }
}
// The example displays output like the following:
//       Six of Diamonds
//       King of Clubs
//       Eight of Clubs
//       Seven of Clubs
//       Queen of Clubs
//       King of Hearts
//       Three of Spades
//       Ace of Clubs
//       Four of Hearts
//       Three of Diamonds
//       Nine of Diamonds
//       Two of Hearts
//       Ace of Hearts
//       Three of Hearts
//       Four of Spades
//       Eight of Hearts
//       Queen of Diamonds
//       Two of Clubs
//       Four of Diamonds
//       Jack of Hearts
// </Snippet11>
