' Visual Basic .NET Document
Option Strict On

' <Snippet3>
Imports System.Text.RegularExpressions

Module modMain
    Public Sub Main()
        Dim pattern As String = "\b(\w+?)\s\1\b"
        Dim input As String = "This this is a nice day. What about this? This tastes good. I saw a a dog."
        For Each match As Match In Regex.Matches(input, pattern, RegexOptions.IgnoreCase)
            Console.WriteLine("{0} (duplicates '{1}') at position {2}", _
                              match.Value, match.Groups(1).Value, match.Index)
        Next
    End Sub
End Module
' The example displays the following output:
'       This this (duplicates 'This') at position 0
'       a a (duplicates 'a') at position 66
' </Snippet3>
