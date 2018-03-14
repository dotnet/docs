' Visual Basic .NET Document
Option Strict On

' <Snippet12>
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim pattern As String = "\b((\w+)\s?)+\."
      Dim input As String = "This is a sentence. This is another sentence."
      Dim match As Match = Regex.Match(input, pattern)
      If match.Success Then
         Console.WriteLine("Match: " + match.Value)
         Console.WriteLine("Group 2: " + match.Groups(2).Value)
      End If   
   End Sub
End Module
' The example displays the following output:
'       Match: This is a sentence.
'       Group 2: sentence
' </Snippet12>

