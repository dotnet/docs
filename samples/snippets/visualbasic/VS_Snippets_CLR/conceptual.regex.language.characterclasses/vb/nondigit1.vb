' Visual Basic .NET Document
Option Strict On

' <Snippet13>
Imports System.Text.RegularExpressions

Module Example
    Public Sub Main()
        Dim pattern As String = "^\D\d{1,5}\D*$"
        Dim inputs() As String = {"A1039C", "AA0001", "C18A", "Y938518"}

        For Each input As String In inputs
            If Regex.IsMatch(input, pattern) Then
                Console.WriteLine(input + ": matched")
            Else
                Console.WriteLine(input + ": match failed")
            End If
        Next
    End Sub
End Module
' The example displays the following output:
' </Snippet13>
