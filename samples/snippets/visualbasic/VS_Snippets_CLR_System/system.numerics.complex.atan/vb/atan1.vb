' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Numerics

Module Example
   Public Sub Main()
      Dim values() As Complex = { New Complex(2.5, 1.5), 
                                  New Complex(2.5, -1.5), 
                                  New Complex(-2.5, 1.5), 
                                  New Complex(-2.5, -1.5) }
      For Each value As Complex In values
         Console.WriteLine("Tan(Atan({0})) = {1}", 
                            value, Complex.Tan(Complex.Atan(value)))
      Next                               
   End Sub
End Module
' The example displays the following example:
'       Tan(Atan((2.5, 1.5))) = (2.5, 1.5)
'       Tan(Atan((2.5, -1.5))) = (2.5, -1.5)
'       Tan(Atan((-2.5, 1.5))) = (-2.5, 1.5)
'       Tan(Atan((-2.5, -1.5))) = (-2.5, -1.5)
' </Snippet1>
