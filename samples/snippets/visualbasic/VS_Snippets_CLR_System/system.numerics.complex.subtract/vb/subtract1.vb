' Visual Basic .NET Document
Option Strict On
Option Infer On

' <Snippet1>
Imports System.Numerics

Module Example
   Public Sub Main()
      Dim c1 As New Complex(4.93, 6.87)
      Dim values() As Complex = { New Complex(12.5, 9.6), 
                                  New Complex(4.3, -8.1), 
                                  New Complex(-1.9, 7.4), 
                                  New Complex(-5.3, -6.6) }

      For Each c2 In values
         Console.WriteLine("{0} - {1} = {2}", c1, c2, 
                           Complex.Subtract(c1, c2))
      Next
   End Sub
End Module
' The example displays the following output:
'       (4.93, 6.87) - (12.5, 9.6) = (-7.57, -2.73)
'       (4.93, 6.87) - (4.3, -8.1) = (0.63, 14.97)
'       (4.93, 6.87) - (-1.9, 7.4) = (6.83, -0.53)
'       (4.93, 6.87) - (-5.3, -6.6) = (10.23, 13.47)
' </Snippet1>

