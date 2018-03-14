' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim pattern As String = "\b\w+es\b"
      Dim sentence As String = "Who writes these notes?"
      For Each match As Match In Regex.Matches(sentence, pattern)
         Console.WriteLine("Found '{0}' at position {1}", match.Value, match.Index)
      Next
   End Sub
End Module
' The example displays the following output:
'       Found 'writes' at position 4
'       Found 'notes' at position 17
' </Snippet2>
