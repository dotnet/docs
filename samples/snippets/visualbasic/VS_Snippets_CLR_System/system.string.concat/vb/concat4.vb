' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Collections

Module Example
   Public Sub Main()
      Const WORD_SIZE As Integer = 4
      
      ' Define some 4-letter words to be scrambled.
      Dim words() As String = { "home", "food", "game", "rest" }
      ' Define two arrays equal to the number of letters in each word.
      Dim keys(WORD_SIZE) As Double
      Dim letters(WORD_SIZE) As String
      ' Initialize the random number generator.
      Dim rnd As New Random()
      
      ' Scramble each word.
      For Each word As String In words
         For ctr As Integer = 0 To word.Length - 1
            ' Populate the array of keys with random numbers.
            keys(ctr) = rnd.NextDouble()
            ' Assign a letter to the array of letters.
            letters(ctr) = word.Chars(ctr)
         Next   
         ' Sort the array. 
         Array.Sort(keys, letters, 0, WORD_SIZE, Comparer.Default)      
         ' Display the scrambled word.
         Dim scrambledWord As String = String.Concat(letters(0), letters(1), _
                                                     letters(2), letters(3))
         Console.WriteLine("{0} --> {1}", word, scrambledWord)
      Next 
   End Sub
End Module 
' The example displays output like the following:
'       home --> mheo
'       food --> oodf
'       game --> aemg
'       rest --> trse
' </Snippet1>
