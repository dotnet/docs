' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Imports System.Collections
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim words As String = "letter alphabetical missing lack release " + _
                            "penchant slack acryllic laundry cease"
      Dim pattern As String = "\w+"                            
      Dim evaluator As MatchEvaluator = AddressOf WordScrambler
      Console.WriteLine("Original words:")
      Console.WriteLine(words)
      Console.WriteLine("Scrambled words:")
      Console.WriteLine(Regex.Replace(words, pattern, evaluator))      
   End Sub
   
   Public Function WordScrambler(match As Match) As String
      Dim arraySize As Integer = match.Value.Length - 1
      ' Define two arrays equal to the number of letters in the match.
      Dim keys(arraySize) As Double
      Dim letters(arraySize) As Char
      
      ' Instantiate random number generator'
      Dim rnd As New Random()
      
      For ctr As Integer = 0 To match.Value.Length - 1
         ' Populate the array of keys with random numbers.
         keys(ctr) = rnd.NextDouble()
         ' Assign letter to array of letters.
         letters(ctr) = match.Value.Chars(ctr)
      Next         
      Array.Sort(keys, letters, 0, arraySize, Comparer.Default)      
      Return New String(letters)
   End Function
End Module
' The example displays output similar to the following:
'    Original words:
'    letter alphabetical missing lack release penchant slack acryllic laundry cease
'    
'    Scrambled words:
'    elrtte iaeabatlpchl igmnssi lcka aerslee hnpatnce ksacl lialcryc dylruna ecase
' </Snippet2>
