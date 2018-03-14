' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Numerics

Module Example
   Public Sub Main()
      Dim values() As Complex = { New Complex(2.3, 1.4),
                                  New Complex(-2.3, 1.4), 
                                  New Complex(-2.3, -1.4),
                                  New Complex(2.3, -1.4) }
      For Each value As Complex In values
         Console.WriteLine("Sin(Asin({0})) = {1}", 
                            value, Complex.Sin(Complex.Asin(value)))
      Next                      
   End Sub
End Module
' The example displays the following output:
'       Sin(Asin((2.3, 1.4))) = (2.3, 1.4)
'       Sin(Asin((-2.3, 1.4))) = (-2.3, 1.4)
'       Sin(Asin((-2.3, -1.4))) = (-2.3, -1.4)
'       Sin(Asin((2.3, -1.4))) = (2.3, -1.4)
' </Snippet1>
