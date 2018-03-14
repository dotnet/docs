' Visual Basic .NET Document
Option Strict On
' <Snippet1>
Imports System.Numerics

Module Example
   Public Sub Main()
      Dim values() As Complex = { New Complex(1.53, 9.26), 
                                  New Complex(2.53, -8.12),
                                  New Complex(-2.81, 5.32),
                                  New Complex(-1.09, -3.43),
                                  New Complex(Double.MinValue/2, Double.MinValue/2) }
      For Each value As Complex In values
         Console.WriteLine("Exp(Log({0}) = {1}", value, 
                           Complex.Exp(Complex.Log(value)))
      Next                                  
   End Sub
End Module
' The example displays the following output:
'      Exp(Log((1.53, 9.26)) = (1.53, 9.26)
'      Exp(Log((2.53, -8.12)) = (2.53, -8.12)
'      Exp(Log((-2.81, 5.32)) = (-2.81, 5.32)
'      Exp(Log((-1.09, -3.43)) = (-1.09, -3.43)
'      Exp(Log((-8.98846567431158E+307, -8.98846567431158E+307)) = (-8.98846567431161E+307, -8.98846567431161E+307)
' </Snippet1>
