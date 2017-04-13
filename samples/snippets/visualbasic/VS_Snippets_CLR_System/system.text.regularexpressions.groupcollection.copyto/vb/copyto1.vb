' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim pattern As String = "\b(\S+?)\b"
      Dim input As String = "This sentence is rather short but pointless."

      Dim matches As MatchCollection = Regex.Matches(input, pattern)
      Dim words(matches.Count * 2 - 1) As Object
      
      Dim index As Integer = 0
      For Each match As Match In matches
         match.Groups.CopyTo(words, index)
         index += 2
      Next
      ' Display captured groups.
      For ctr As Integer = 1 To words.GetUpperBound(0) Step 2
         Console.WriteLine(words(ctr))
      Next
   End Sub
End Module
' The example displays the following output:
'       This
'       sentence
'       is
'       rather
'       short
'       but
'       pointless
' </Snippet1>
