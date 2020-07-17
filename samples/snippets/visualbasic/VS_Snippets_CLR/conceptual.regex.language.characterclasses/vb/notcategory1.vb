' Visual Basic .NET Document
Option Strict On

' <Snippet7>
Imports System.Text.RegularExpressions

Module Example
    Public Sub Main()
        Dim pattern As String = "(\P{Sc})+"

        Dim values() As String = {"$164,091.78", "£1,073,142.68", "73¢", "€120"}
        For Each value As String In values
            Console.WriteLine(Regex.Match(value, pattern).Value)
        Next
    End Sub
End Module
' The example displays the following output:
'       164,091.78
'       1,073,142.68
'       73
'       120
' </Snippet7>
