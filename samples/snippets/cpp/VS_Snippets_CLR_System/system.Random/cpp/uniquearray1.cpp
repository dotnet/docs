// <Snippet11>
using namespace System;

public enum class Suit { Hearts, Diamonds, Spades, Clubs };

public enum class FaceValue  { Ace = 1, Two, Three, Four, Five, Six,
                               Seven, Eight, Nine, Ten, Jack, Queen,
                               King };

// A class that represents an individual card in a playing deck.
ref class Card
{
public:
   Suit Suit;
   FaceValue FaceValue;
   
   String^ ToString() override
   {
      return String::Format("{0:F} of {1:F}", this->FaceValue, this->Suit);
   }
};

ref class Dealer
{
private:
   Random^ rnd;
   // A deck of cards, without Jokers.
   array<Card^>^ deck = gcnew array<Card^>(52);
   // Parallel array for sorting cards.
   array<Double>^ order = gcnew array<Double>(52);
   // A pointer to the next card to deal.
   int ptr = 0;
   // A flag to indicate the deck is used.
   bool mustReshuffle = false;
   
public:
   Dealer()
   {
      rnd = gcnew Random();
      // Initialize the deck.
      int deckCtr = 0;
      for each (auto suit in Enum::GetValues(Suit::typeid)) {
         for each (FaceValue faceValue in Enum::GetValues(FaceValue::typeid)) {
            Card^ card = gcnew Card();
            card->Suit = (Suit) suit;
            card->FaceValue = (FaceValue) faceValue;
            deck[deckCtr] = card;  
            deckCtr++;
         }
      }
      
      for (int ctr = 0; ctr < order->Length; ctr++)
         order[ctr] = rnd->NextDouble();

      Array::Sort(order, deck);
   }

   array<Card^>^ Deal(int numberToDeal)
   {
      if (mustReshuffle) {
         Console::WriteLine("There are no cards left in the deck");
         return nullptr;
      }
      
      array<Card^>^ cardsDealt = gcnew array<Card^>(numberToDeal);
      for (int ctr = 0; ctr < numberToDeal; ctr++) {
         cardsDealt[ctr] = deck[ptr];
         ptr++;
         if (ptr == deck->Length)
            mustReshuffle = true;

         if (mustReshuffle & ctr < numberToDeal - 1) {
            Console::WriteLine("Can only deal the {0} cards remaining on the deck.",
                               ctr + 1);
            return cardsDealt;
         }
      }
      return cardsDealt;
   }
};

void ShowCards(array<Card^>^ cards)
{
   for each (Card^ card in cards)
      if (card != nullptr)
         Console::WriteLine("{0} of {1}", card->FaceValue, card->Suit);
};

void main()
{
   Dealer^ dealer = gcnew Dealer();
   ShowCards(dealer->Deal(20));
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
