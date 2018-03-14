' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim pattern As String = "\b(?<FirstWord>\w+)\s?((\w+)\s)*(?<LastWord>\w+)?(?<Punctuation>\p{Po})"
      Dim input As String = "The cow jumped over the moon."
      Dim rgx As New Regex(pattern)
      Dim match As Match = rgx.Match(input)
      If match.Success Then ShowMatches(rgx, match)
   End Sub
   
   Private Sub ShowMatches(r As Regex, m As Match)
      Dim names() As String = r.GetGroupNames()
      Console.WriteLine("Named Groups:")
      For Each name In names
         Dim grp As Group = m.Groups.Item(name)
         Console.WriteLine("   {0}: '{1}'", name, grp.Value)
      Next
   End Sub
End Module
' The example displays the following output:
'       Named Groups:
'          0: 'The cow jumped over the moon.'
'          1: 'the '
'          2: 'the'
'          FirstWord: 'The'
'          LastWord: 'moon'
'          Punctuation: '.'
' </Snippet1>
