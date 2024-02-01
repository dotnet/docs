' Visual Basic .NET Document
Option Strict On

' <Snippet21>
Imports System.Collections.Generic

Module Example5
    Public Sub Main()
        Dim rnd As New Random()
        Dim numbers(3) As Integer
        Dim total As Integer = 0
        For ctr = 0 To 2
            Dim number As Integer = rnd.Next(1001)
            numbers(ctr) = number
            total += number
        Next
        numbers(3) = total
        Console.WriteLine("{0} + {1} + {2} = {3}", numbers)
    End Sub
End Module
' </Snippet21>
