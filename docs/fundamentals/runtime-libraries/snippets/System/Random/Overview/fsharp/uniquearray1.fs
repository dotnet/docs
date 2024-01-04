module UniqueArray1

// <Snippet11>
open System

type Suit =
    | Clubs
    | Diamonds
    | Hearts
    | Spades

type Face =
    | Ace | Two | Three
    | Four | Five | Six
    | Seven | Eight | Nine
    | Ten | Jack | Queen | King

type Card = { Face: Face; Suit: Suit }

let suits = [ Clubs; Diamonds; Hearts; Spades ]
let faces = [ Ace; Two; Three; Four; Five; Six; Seven; Eight; Nine; Ten; Jack; Queen; King ]

type Dealer() =
    let rnd = Random()
    let mutable pos = 0
    // Parallel array for sorting cards.
    let order = Array.init (suits.Length * faces.Length) (fun _ -> rnd.NextDouble() )
    // A deck of cards, without Jokers.
    let deck = [|
        for s in suits do
            for f in faces do
                { Face = f; Suit = s } |]
    // Shuffle the deck.
    do Array.Sort(order, deck)

    // Deal a number of cards from the deck, return None if failed
    member _.Deal(numberToDeal) : Card [] option = 
        if numberToDeal = 0 || pos = deck.Length then
            printfn "There are no cards left in the deck"
            None
        else 
            let cards = deck.[pos .. numberToDeal + pos - 1]
            if numberToDeal > deck.Length - pos then
                printfn "Can only deal the %i cards remaining on the deck." (deck.Length - pos)
            pos <- min (pos + numberToDeal) deck.Length
            Some cards

let showCards cards = 
    for card in cards do
        printfn $"{card.Face} of {card.Suit}"

let dealer = Dealer()

dealer.Deal 20
|> Option.iter showCards

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
