' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Text.RegularExpressions

Module Example
    Public Sub Main()
        Dim values() As String = {"111-22-3333", "111-2-3333"}
        Dim pattern As String = "^\d{3}-\d{2}-\d{4}$"
        For Each value As String In values
            If Regex.IsMatch(value, pattern) Then
                Console.WriteLine("{0} is a valid SSN.", value)
            Else
                Console.WriteLine("{0}: Invalid", value)
            End If
        Next
    End Sub
End Module
' The example displays the following output:
'       111-22-3333 is a valid SSN.
'       111-2-3333: Invalid
' </Snippet1>
