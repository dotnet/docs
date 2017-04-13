' Visual Basic .NET Document
Option Strict On
Option Infer On

' <Snippet1>
Imports System.Numerics

Module Example
   Public Sub Main()
      Dim number1 As New Complex(8.3, 17.5)
      Dim numbers() As Complex = { New Complex(1.4, 6.3), 
                                   New Complex(-2.7, 1.8), 
                                   New Complex(3.1, -2.1) }
      For Each number2 In numbers
         Console.WriteLine("{0} x {1} = {2}", number1, number2, 
                           Complex.Multiply(number1, number2))
      Next
   End Sub
End Module
' The example displays the following output:
'       (8.3, 17.5) x (1.4, 6.3) = (-98.63, 76.79)
'       (8.3, 17.5) x (-2.7, 1.8) = (-53.91, -32.31)
'       (8.3, 17.5) x (3.1, -2.1) = (62.48, 36.82)
' </Snippet1>
