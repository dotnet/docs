' <Snippet1>
Option Strict On

Imports System.Text.RegularExpressions

Module TestMatches
   Public Sub Main()
      Dim pattern As String = "\b[hH]\w*\b"
      Dim sentence As String
      sentence = "Half-way down a by-street of one of our New England towns, stands a rusty wooden " & _
                 "house, with seven acutely peaked gables, facing towards various points of the compass, " & _ 
                 "and a huge, clustered chimney in the midst."
      Dim matches As MatchCollection = Regex.Matches(sentence, pattern)
      For ctr As Integer = 0 To Matches.Count - 1
         Console.WriteLine(matches.Item(ctr).Value)
      Next           
   End Sub
End Module
' </Snippet1>
