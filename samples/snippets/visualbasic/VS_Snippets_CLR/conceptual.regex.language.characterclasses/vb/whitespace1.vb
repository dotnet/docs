' Visual Basic .NET Document
Option Strict On

' <Snippet10>
Imports System.Text.RegularExpressions

Module Example
    Public Sub Main()
        Dim pattern As String = "\b\w+(e)?s(\s|$)"
        Dim input As String = "matches stores stops leave leaves"
        For Each match As Match In Regex.Matches(input, pattern)
            Console.WriteLine(match.Value)
        Next
    End Sub
End Module
' The example displays the following output:
'       matches
'       stores
'       stops
'       leaves
' </Snippet10>
