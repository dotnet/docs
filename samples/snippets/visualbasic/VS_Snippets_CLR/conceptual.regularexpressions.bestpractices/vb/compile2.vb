' Visual Basic .NET Document
Option Strict On

' <Snippet7>
Imports System.IO
Imports System.Text.RegularExpressions
Imports Utilities.RegularExpressions

Module Example
   Public Sub Main()
      Dim pattern As New SentencePattern()
      Dim inFile As New StreamReader(".\Dreiser_TheFinancier.txt")
      Dim input As String = inFile.ReadToEnd()
      inFile.Close()
      
      Dim matches As MatchCollection = pattern.Matches(input)
      Console.WriteLine("Found {0:N0} sentences.", matches.Count)      
   End Sub
End Module
' The example displays the following output:
'      Found 13,443 sentences.
' </Snippet7>

' This code is here so that Parsnip will compile the example.
Namespace Utilities.RegularExpressions 
   Public Class SentencePattern
      Public Function Matches(input As String) As MatchCollection
         return Nothing
      End Function
   End Class
End Namespace
