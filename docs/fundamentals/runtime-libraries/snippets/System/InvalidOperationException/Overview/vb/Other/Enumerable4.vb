' Visual Basic .NET Document
Option Strict On

' <Snippet9>
Imports System.Linq

Module Example3
    Public Sub Main()
        Dim dbQueryResults() As Integer = {1, 2, 3, 4}

        Dim firstNum = dbQueryResults.FirstOrDefault(Function(n) n > 4)

        If firstNum = 0 Then
            Console.WriteLine("No value is greater than 4.")
        Else
            Console.WriteLine("The first value greater than 4 is {0}",
                           firstNum)
        End If
    End Sub
End Module
' The example displays the following output:
'       No value is greater than 4.
' </Snippet9>
