' Visual Basic .NET Document
Option Strict On

' <Snippet15>
Imports System.Text.RegularExpressions

Module Example
    Public Sub Main()
        Dim inputs() As String = {"123", "13579753", "3557798", "335599901"}
        Dim pattern As String = "^[0-9-[2468]]+$"

        For Each input As String In inputs
            Dim match As Match = Regex.Match(input, pattern)
            If match.Success Then Console.WriteLine(match.Value)
        Next
    End Sub
End Module
' The example displays the following output:
'       13579753
'       335599901
' </Snippet15>
