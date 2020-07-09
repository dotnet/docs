' Visual Basic .NET Document
Option Strict On

' <Snippet11>
Imports System.Text.RegularExpressions

Module Example
    Public Sub Main()
        Dim pattern As String = "^[0-9A-Z][-.\w]*(?<=[0-9A-Z])\$$"
        Dim partNos() As String = {"A1C$", "A4", "A4$", "A1603D$",
                                    "A1603D#"}

        For Each input As String In partNos
            Dim match As Match = Regex.Match(input, pattern)
            If match.Success Then
                Console.WriteLine(match.Value)
            Else
                Console.WriteLine("Match not found.")
            End If
        Next
    End Sub
End Module
' The example displays the following output:
'       A1C$
'       Match not found.
'       A4$
'       A1603D$
'       Match not found.
' </Snippet11>
