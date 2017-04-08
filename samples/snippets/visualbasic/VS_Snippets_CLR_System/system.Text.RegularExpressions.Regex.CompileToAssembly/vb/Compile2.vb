' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Imports Utilities.RegularExpressions

Module CompiledRegexUsage
   Public Sub Main()
      Dim text As String = "The the quick brown fox  fox jumped over the lazy dog dog."
      Dim duplicateRegex As New DuplicatedString()
      If duplicateRegex.Matches(text).Count > 0 Then
         Console.WriteLine("There are {0} duplicate words in {2}   '{1}'", _
            duplicateRegex.Matches(text).Count, text, vbCrLf)
      Else
         Console.WriteLine("There are no duplicate words in {1}   '{0}'", _
                           text, vbCrLf)
      End If
   End Sub
End Module
' The example displays the following output to the console:
'    There are 3 duplicate words in
'       'The the quick brown fox  fox jumped over the lazy dog dog.'
' </Snippet2>

