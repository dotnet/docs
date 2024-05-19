' Visual Basic .NET Document
Option Strict On

' <Snippet11>
' A class that represents an individual card in a playing deck.
Public Class Card
   Public Suit As Suit
   Public FaceValue As FaceValue
   
   Public Overrides Function ToString() As String
      Return String.Format("{0:F} of {1:F}", Me.FaceValue, Me.Suit)
   End Function
End Class

Public Enum Suit As Integer
   Hearts = 0
   Diamonds = 1
   Spades = 2
   Clubs = 3
End Enum

Public Enum FaceValue As Integer
   Ace = 1
   Two = 2
   Three = 3
   Four = 4
   Five = 5
   Six = 6
   Seven = 7
   Eight = 8
   Nine = 9
   Ten = 10
   Jack = 11
   Queen = 12
   King = 13
End Enum

Public Class Dealer
   Dim rnd As Random
   ' A deck of cards, without Jokers.
   Dim deck(51) As Card
   ' Parallel array for sorting cards.
   Dim order(51) As Double
   ' A pointer to the next card to deal.
   Dim ptr As Integer = 0
   ' A flag to indicate the deck is used.
   Dim mustReshuffle As Boolean
   
   Public Sub New()
      rnd = New Random()
      ' Initialize the deck.
      Dim deckCtr As Integer = 0
      For Each Suit In [Enum].GetValues(GetType(Suit))
         For Each faceValue In [Enum].GetValues(GetType(FaceValue))
            Dim card As New Card()
            card.Suit = CType(Suit, Suit)
            card.FaceValue = CType(faceValue, FaceValue)
            deck(deckCtr) = card  
            deckCtr += 1
         Next
      Next
      For ctr As Integer = 0 To order.Length - 1
         order(ctr) = rnd.NextDouble()   
      Next   
      Array.Sort(order, deck)
   End Sub

   Public Function Deal(numberToDeal As Integer) As Card()
      If mustReshuffle Then
         Console.WriteLine("There are no cards left in the deck")
         Return Nothing
      End If
      
      Dim cardsDealt(numberToDeal - 1) As Card
      For ctr As Integer = 0 To numberToDeal - 1
         cardsDealt(ctr) = deck(ptr)
         ptr += 1
         If ptr = deck.Length Then 
            mustReshuffle = True
         End If
         If mustReshuffle And ctr < numberToDeal - 1
            Console.WriteLine("Can only deal the {0} cards remaining on the deck.", 
                              ctr + 1)
            Return cardsDealt
         End If
      Next
      Return cardsDealt
   End Function
End Class

Public Module Example
   Public Sub Main()
      Dim dealer As New Dealer()
      ShowCards(dealer.Deal(20))
   End Sub
   
   Private Sub ShowCards(cards() As Card)
      For Each card In cards
         If card IsNot Nothing Then _
            Console.WriteLine("{0} of {1}", card.FaceValue, card.Suit)
      Next
   End Sub
End Module
' The example displays output like the following:
'       Six of Diamonds
'       King of Clubs
'       Eight of Clubs
'       Seven of Clubs
'       Queen of Clubs
'       King of Hearts
'       Three of Spades
'       Ace of Clubs
'       Four of Hearts
'       Three of Diamonds
'       Nine of Diamonds
'       Two of Hearts
'       Ace of Hearts
'       Three of Hearts
'       Four of Spades
'       Eight of Hearts
'       Queen of Diamonds
'       Two of Clubs
'       Four of Diamonds
'       Jack of Hearts
' </Snippet11>
