' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim pattern As String = "\ba\w*\b"
      Dim input As String = "An extraordinary day dawns with each new day."
      Dim m As Match = Regex.Match(input, pattern, RegexOptions.IgnoreCase)
      If m.Success Then
         Console.WriteLine("Found '{0}' at position {1}.", m.Value, m.Index)
      End If
   End Sub
End Module
' The example displays the following output:
'       Found 'An' at position 0.
' </Snippet2>

