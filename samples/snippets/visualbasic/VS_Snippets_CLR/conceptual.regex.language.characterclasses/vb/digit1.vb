' Visual Basic .NET Document
Option Strict On

' <Snippet12>
Imports System.Text.RegularExpressions

Module Example
    Public Sub Main()
        Dim pattern As String = "^(\(?\d{3}\)?[\s-])?\d{3}-\d{4}$"
        Dim inputs() As String = {"111 111-1111", "222-2222", "222 333-444", _
                                   "(212) 111-1111", "111-AB1-1111", _
                                   "212-111-1111", "01 999-9999"}

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
'       111 111-1111: matched
'       222-2222: matched
'       222 333-444: match failed
'       (212) 111-1111: matched
'       111-AB1-1111: match failed
'       212-111-1111: matched
'       01 999-9999: match failed
' </Snippet12>
