' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim pattern As String = "\b\w+es\b"
      Dim rgx As New Regex(pattern)
      Dim sentence As String = "Who writes these notes?"
      
      For Each match As Match In rgx.Matches(sentence)
         Console.WriteLine("Found '{0}' at position {1}", match.Value, match.Index)
      Next
   End Sub
End Module
' The example displays the following output:
'       Found 'writes' at position 4
'       Found 'notes' at position 17
' </Snippet1>
