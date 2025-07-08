' Visual Basic .NET Document
Option Strict On

Imports System.Numerics

Module Example3
    Public Sub Run()
        ' <Snippet5>
        Dim value As New Complex(Double.MinValue / 2, Double.MinValue / 2)
        Dim value2 As Complex = Complex.Exp(Complex.Log(value))
        Console.WriteLine("{0} {3}{1} {3}Equal: {2}", value, value2,
                                                      value = value2,
                                                      vbCrLf)
        ' The example displays the following output:
        '    (-8.98846567431158E+307, -8.98846567431158E+307)
        '    (-8.98846567431161E+307, -8.98846567431161E+307)
        '    Equal: False
        ' </Snippet5>

        Console.WriteLine()
        ShowPlatform()
    End Sub


    Private Sub ShowPlatform()
        ' <Snippet6>
        Dim minusOne As New Complex(-1, 0)
        Console.WriteLine(Complex.Sqrt(minusOne))
        ' The example displays the following output:
        '    (6.12303176911189E-17, 1) on 32-bit systems.
        '    (6.12323399573677E-17,1) on IA64 systems.
        ' </Snippet6>
    End Sub
End Module

