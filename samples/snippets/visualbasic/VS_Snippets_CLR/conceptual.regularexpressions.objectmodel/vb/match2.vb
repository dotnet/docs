' Visual Basic .NET Document
Option Strict On

' <Snippet7>
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim pattern As String = "abc"
      Dim input As String = "abc123abc456abc789"
      For Each match As Match In Regex.Matches(input, pattern)
         Console.WriteLine("{0} found at position {1}.", _
                           match.Value, match.Index)
      Next                     
   End Sub
End Module
' The example displays the following output:
'       abc found at position 0.
'       abc found at position 6.
'       abc found at position 12.
' </Snippet7>
