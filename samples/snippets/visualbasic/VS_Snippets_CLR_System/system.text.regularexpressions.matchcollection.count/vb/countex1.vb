' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim pattern As String = "\d+"
      Dim inputs() As String = { "This sentence contains no numbers.",
                                 "123 What do I see?",
                                 "2468 369 48 5" }
      For Each inputStr In inputs
         Dim matches As MatchCollection = Regex.Matches(inputStr, pattern)
         Console.WriteLine("Input: {0}", inputStr)
         If matches.Count = 0
            Console.WriteLine("   No matches")
         Else
            For Each m As Match In matches
               Console.WriteLine("   {0} at index {1}", m.Value, m.Index)
            Next
         End If
         Console.WriteLine()
      Next
   End Sub
End Module
' The example displays the following output:
'       Input: This sentence contains no numbers.
'       No matches
'
'       Input: 123 What do I see?
'       123 at index 0
'
'       Input: 2468 369 48 5
'       2468 at index 0
'       369 at index 5
'       48 at index 9
'       5 at index 12
' </Snippet1>
