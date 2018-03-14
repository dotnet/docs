' Visual Basic .NET Document
Option Strict On
Option Infer On

' <Snippet1>
Imports System.Numerics

Module Example
   Public Sub Main()
      Dim values() As Complex = { Complex.One, 
                                  New Complex(-7.1, 2.5), 
                                  New Complex(1.3, -4.2), 
                                  New Complex(-3.3, -1.8) }
      For Each c1 In values
         Console.WriteLine("{0} --> {1}", c1, Complex.Negate(c1))
      Next                                    
   End Sub
End Module
' The example displays the following output:
'       (1, 0) --> (-1, 0)
'       (-7.1, 2.5) --> (7.1, -2.5)
'       (1.3, -4.2) --> (-1.3, 4.2)
'       (-3.3, -1.8) --> (3.3, 1.8)
' </Snippet1>
