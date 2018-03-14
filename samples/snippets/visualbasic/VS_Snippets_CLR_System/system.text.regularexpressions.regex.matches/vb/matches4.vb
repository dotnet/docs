' Visual Basic .NET Document
Option Strict On

' <Snippet4>
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim pattern As String = "\b\w+es\b"
      Dim sentence As String = "NOTES: Any notes or comments are optional."
      
      ' Call Matches method without specifying any options.
      For Each match As Match In Regex.Matches(sentence, pattern)
         Console.WriteLine("Found '{0}' at position {1}", match.Value, match.Index)
      Next
      Console.WriteLine()
      
      ' Call Matches method for case-insensitive matching.
      For Each match As Match In Regex.Matches(sentence, pattern, RegexOptions.IgnoreCase)
         Console.WriteLine("Found '{0}' at position {1}", match.Value, match.Index)
      Next
   End Sub
End Module
' The example displays the following output:
'       Found 'notes' at position 11
'       
'       Found 'NOTES' at position 0
'       Found 'notes' at position 11
' </Snippet4>
