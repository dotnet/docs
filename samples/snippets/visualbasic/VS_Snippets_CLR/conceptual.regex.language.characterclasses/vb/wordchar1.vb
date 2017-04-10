' Visual Basic .NET Document
Option Strict On

' <Snippet8>
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim pattern As String = "(\w)\1"
      Dim words() As String = { "trellis", "seer", "latter", "summer", _
                                "hoarse", "lesser", "aardvark", "stunned" }
      For Each word As String In words
         Dim match As Match = Regex.Match(word, pattern)
         If match.Success Then
            Console.WriteLine("'{0}' found in '{1}' at position {2}.", _
                              match.Value, word, match.Index)
         Else
            Console.WriteLine("No double characters in '{0}'.", word)
         End If
      Next                                                  
   End Sub
End Module
' The example displays the following output:
'       'll' found in 'trellis' at position 3.
'       'ee' found in 'seer' at position 1.
'       'tt' found in 'latter' at position 2.
'       'mm' found in 'summer' at position 2.
'       No double characters in 'hoarse'.
'       'ss' found in 'lesser' at position 2.
'       'aa' found in 'aardvark' at position 0.
'       'nn' found in 'stunned' at position 3.
' </Snippet8>
