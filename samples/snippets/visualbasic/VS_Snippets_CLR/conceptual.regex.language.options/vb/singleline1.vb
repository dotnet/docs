' Visual Basic .NET Document
Option Strict On

' <Snippet5>
Imports System.Text.RegularExpressions

Module SingleLineExample
    Public Sub Main()
        Dim pattern As String = "(?s)^.+"
        Dim input As String = "This is one line and" + vbCrLf + "this is the second."

        For Each match As Match In Regex.Matches(input, pattern)
            Console.WriteLine(Regex.Escape(match.Value))
        Next
    End Sub
End Module
' The example displays the following output:
'       This\ is\ one\ line\ and\r\nthis\ is\ the\ second\.
' </Snippet5>
