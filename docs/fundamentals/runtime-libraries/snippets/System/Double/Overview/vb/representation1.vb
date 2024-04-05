' Visual Basic .NET Document
Option Strict On

' <Snippet3>
Module Example14
    Public Sub Main()
        Dim value As Double = 0.1
        Dim result1 As Double = value * 10
        Dim result2 As Double
        For ctr As Integer = 1 To 10
            result2 += value
        Next
        Console.WriteLine(".1 * 10:           {0:R}", result1)
        Console.WriteLine(".1 Added 10 times: {0:R}", result2)
    End Sub
End Module
' The example displays the following output:
'       .1 * 10:           1
'       .1 Added 10 times: 0.99999999999999989
' </Snippet3>

