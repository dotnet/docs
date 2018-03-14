' Visual Basic .NET Document
Option Strict On

' <Snippet6>
Imports System.Collections.Generic
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
       Dim matches As MatchCollection
       Dim results As New List(Of String)
       Dim matchposition As New List(Of Integer)
   
       ' Create a new Regex object and define the regular expression.
       Dim r As New Regex("abc")
       ' Use the Matches method to find all matches in the input string.
       matches = r.Matches("123abc4abcd")
       ' Enumerate the collection to retrieve all matches and positions.
       For Each match As Match In matches
          ' Add the match string to the string array.
           results.Add(match.Value)
           ' Record the character position where the match was found.
           matchposition.Add(match.Index)
       Next
       ' List the results.
       For ctr As Integer = 0 To results.Count - 1
         Console.WriteLine("'{0}' found at position {1}.", _
                           results(ctr), matchposition(ctr))  
       Next
   End Sub
End Module
' The example displays the following output:
'       'abc' found at position 3.
'       'abc' found at position 7.
' </Snippet6>

