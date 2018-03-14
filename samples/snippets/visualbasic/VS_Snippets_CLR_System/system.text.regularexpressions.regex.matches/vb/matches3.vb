' Visual Basic .NET Document
Option Strict On

' <Snippet3>
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim pattern As String = "\b\w+es\b"
      Dim rgx As New Regex(pattern)
      Dim sentence As String = "Who writes these notes and uses our paper?"
      
      ' Get the first match.
      Dim match As Match = rgx.Match(sentence)
      If match.Success Then
         Console.WriteLine("Found first 'es' in '{0}' at position {1}", _
                           match.Value, match.Index)
         ' Get any additional matches.
         For Each match In rgx.Matches(sentence, match.Index + match.Length)
            Console.WriteLine("Also found '{0}' at position {1}", _
                              match.Value, match.Index)
         Next
      End If   
   End Sub
End Module
' The example displays the following output:
'       Found first 'es' in 'writes' at position 4
'       Also found 'notes' at position 17
'       Also found 'uses' at position 27
' </Snippet3>
