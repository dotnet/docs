' Visual Basic .NET Document
Option Strict On

' <Snippet3>
Module Example13
    Public Sub Main()
        Dim value As Single = 0.2
        Dim result1 As Single = value * 10
        Dim result2 As Single
        For ctr As Integer = 1 To 10
            result2 += value
        Next
        Console.WriteLine(".2 * 10:           {0:R}", result1)
        Console.WriteLine(".2 Added 10 times: {0:R}", result2)
    End Sub
End Module
' The example displays the following output:
'       .2 * 10:           2
'       .2 Added 10 times: 2.00000024
' </Snippet3>

