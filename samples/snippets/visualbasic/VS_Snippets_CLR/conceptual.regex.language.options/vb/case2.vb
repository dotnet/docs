' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Imports System.Text.RegularExpressions

Module CaseExample
    Public Sub Main()
        Dim pattern As String = "\b(?i:t)he\w*\b"
        Dim input As String = "The man then told them about that event."
        For Each match As Match In Regex.Matches(input, pattern)
            Console.WriteLine("Found {0} at index {1}.", match.Value, match.Index)
        Next
        Console.WriteLine()
        pattern = "(?i)\bthe\w*\b"
        For Each match As Match In Regex.Matches(input, pattern)
            Console.WriteLine("Found {0} at index {1}.", match.Value, match.Index)
        Next
    End Sub
End Module

' The example displays the following output:
'       Found The at index 0.
'       Found then at index 8.
'       Found them at index 18.
'       
'       Found The at index 0.
'       Found then at index 8.
'       Found them at index 18.
' </Snippet2>
