' Visual Basic .NET Document
Option Strict On

' <Snippet3>
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim pattern As String = "\b[A-Z]\w*\b"
      Dim input As String = "A city Albany Zulu maritime Marseilles"
      For Each match As Match In Regex.Matches(input, pattern)
         Console.WriteLine(match.Value)
      Next
   End Sub
End Module
' </Snippet3>


