' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Numerics

Module Example
   Public Sub Main()
      Dim values() As Complex = { New Complex(1, 1), 
                                  New Complex(-1, 1), 
                                  New Complex(10, -1),
                                  New Complex(3, 5) }
      For Each value As Complex In values         
         Dim r1 As Complex = Complex.Reciprocal(value)                   
         Console.WriteLine("{0:N0} x {1:N2} = {2:N2}", 
                           value, r1, value * r1)
      Next
   End Sub
End Module
' The example displays the following output:
'       (1, 1) x (0.50, -0.50) = (1.00, 0.00)
'       (-1, 1) x (-0.50, -0.50) = (1.00, 0.00)
'       (10, -1) x (0.10, 0.01) = (1.00, 0.00)
'       (3, 5) x (0.09, -0.15) = (1.00, 0.00)
' </Snippet1>
