' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Imports System.Text.RegularExpressions

Module Example
    Public Sub Main()
        Dim pattern As String = "\b[A-Z]+\b(?=\P{P})"
        Dim input As String = "If so, what comes next?"
        For Each match As Match In Regex.Matches(input, pattern, RegexOptions.IgnoreCase)
            Console.WriteLine(match.Value)
        Next
    End Sub
End Module
' The example displays the following output:
'       If
'       what
'       comes
' </Snippet2>
