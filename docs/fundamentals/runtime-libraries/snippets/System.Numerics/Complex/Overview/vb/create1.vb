' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Imports System.Numerics

Module Example
   Public Sub Run()
      ' Create a complex number by calling its class constructor.
      Dim c1 As New Complex(12, 6)
      Console.WriteLine(c1)
      
      ' Assign a Double to a complex number.
      Dim c2 As Complex = 3.14
      Console.WriteLine(c2)
      
      ' Cast a Decimal to a complex number.
      Dim c3 As Complex = CType(12.3d, Complex)
      Console.WriteLine(c3)
      
      ' Assign the return value of a method to a Complex variable.
      Dim c4 As Complex = Complex.Pow(Complex.One, -1)
      Console.WriteLine(c4)
      
      ' Assign the value returned by an operator to a Complex variable.
      Dim c5 As Complex = Complex.One + Complex.One
      Console.WriteLine(c5)

      ' Instantiate a complex number from its polar coordinates.
      Dim c6 As Complex = Complex.FromPolarCoordinates(10, .524)
      Console.WriteLine(c6)
   End Sub
End Module
' The example displays the following output:
'       (12, 6)
'       (3.14, 0)
'       (12.3000001907349, 0)
'       (1, 0)
'       (2, 0)
'       (8.65824721882145, 5.00347430269914)
' </Snippet2>
