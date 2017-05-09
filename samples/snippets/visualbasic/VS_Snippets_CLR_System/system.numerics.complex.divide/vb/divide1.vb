' Visual Basic .NET Document
Option Strict On
Option Infer On

' <Snippet1>
Imports System.Numerics

Module Example
   Public Sub Main()
      Dim c1 As New Complex(1.2, 2.3)
      Dim values() As Complex = { New Complex(1.2, 2.3), 
                                  New Complex(0.5, 0.75), 
                                  New Complex(3.0, -5.0) }
      For Each c2 In values
         Console.WriteLine("{0} / {1} = {2:N2}", c1, c2, 
                           Complex.Divide(c1, c2))
      Next
   End Sub
End Module
' The example displays the following output:
'       (1.2, 2.3) / (1.2, 2.3) = (1.00, 0.00)
'       (1.2, 2.3) / (0.5, 0.75) = (2.86, 0.31)
'       (1.2, 2.3) / (3, -5) = (-0.23, 0.38)
' </Snippet1>
