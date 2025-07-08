' Visual Basic .NET Document
Option Strict On

' <Snippet3>
Imports System.Numerics

Module Example4
    Public Sub Run()
        Dim c1 As Complex = New Complex(Double.MaxValue / 2, Double.MaxValue / 2)

        Dim c2 As Complex = c1 / Complex.Zero
        Console.WriteLine(c2.ToString())
        c2 = c2 * New Complex(1.5, 1.5)
        Console.WriteLine(c2.ToString())
        Console.WriteLine()

        Dim c3 As Complex = c1 * New Complex(2.5, 3.5)
        Console.WriteLine(c3.ToString())
        c3 = c3 + New Complex(Double.MinValue / 2, Double.MaxValue / 2)
        Console.WriteLine(c3)
    End Sub
End Module
' The example displays the following output:
'       (NaN, NaN)
'       (NaN, NaN)
'
'       (NaN, Infinity)
'       (NaN, Infinity)
' </Snippet3>
