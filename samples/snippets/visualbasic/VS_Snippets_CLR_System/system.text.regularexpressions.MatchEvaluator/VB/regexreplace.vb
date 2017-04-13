' <Snippet1>
Imports System.Text.RegularExpressions

Module Module1
   Public Sub Main()
      Dim sInput, sRegex As String

      ' The string to search.
      sInput = "aabbccddeeffcccgghhcccciijjcccckkcc"

      ' A very simple regular expression.
      sRegex = "cc"

      Dim r As Regex = New Regex(sRegex)

      ' Assign the replace method to the MatchEvaluator delegate.
      Dim myEvaluator As MatchEvaluator = New MatchEvaluator(AddressOf ReplaceCC)

      ' Write out the original string.
      Console.WriteLine(sInput)
      ' Replace matched characters using the delegate method.
      sInput = r.Replace(sInput, myEvaluator)
      ' Write out the modified string.
      Console.WriteLine(sInput)
   End Sub

   Public Function ReplaceCC(ByVal m As Match) As String
      ' Replace each Regex match with the number of the match occurrence.
      static i as integer
   
      i = i + 1
      Return i.ToString() & i.ToString()
   End Function
End Module
' The example displays the following output:
'       aabbccddeeffcccgghhcccciijjcccckkcc
'       aabb11ddeeff22cgghh3344iijj5566kk77
' </Snippet1>
