' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Numerics

Module Example
   Public Sub Main()
      Dim values() As Complex = { New Complex(.5, 2), 
                                  New Complex(.5, -2),
                                  New Complex(-.5, 2),
                                  New Complex(-.3, -.8) }
      For Each value As Complex In values
         Console.WriteLine("Cos(ACos({0})) = {1}", value, 
                           Complex.Cos(Complex.Acos(value)))
      Next
   End Sub
End Module
' The example displays the following output:
'       Cos(ACos((0.5, 2))) = (0.5, 2)
'       Cos(ACos((0.5, -2))) = (0.5, -2)
'       Cos(ACos((-0.5, 2))) = (-0.5, 2)
'       Cos(ACos((-0.3, -0.8))) = (-0.3, -0.8)
' </Snippet1>
