' Visual Basic .NET Document
Option Strict On

Imports System.Text.RegularExpressions

Module Example
    Public Sub Main()
        Dim ctr As Integer = 3
        For Each match AS Match in Regex.Matches("string", "(.)+")
            ' <Snippet13>
            Dim group As Group = match.Groups(ctr)
            ' </Snippet13>
        Next
    End Sub
End Module
