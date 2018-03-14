' Visual Basic .NET Document
Option Strict On

Imports System.Text.RegularExpressions

<Assembly: CLSCompliant(True)>
Module Example
   Public Sub Main()
      NoMatch()
      Console.WriteLine("-----")
   End Sub
   
   Private Sub NoMatch()   
      ' <Snippet1>
      ' Search for a pattern that is not found in the input string.
      Dim pattern As String = "dog"
      Dim input As String = "The cat saw the other cats playing in the back yard."
      Dim match As Match = Regex.Match(input, pattern)
      If match.Success Then
         ' Report position as a one-based integer.
         Console.WriteLine("'{0}' was found at position {1} in '{2}'.", _ 
                           match.Value, match.Index + 1, input)
      Else
         Console.WriteLine("The pattern '{0}' was not found in '{1}'.", _
                           pattern, input)
      End If
      ' </Snippet1>
   End Sub
End Module

