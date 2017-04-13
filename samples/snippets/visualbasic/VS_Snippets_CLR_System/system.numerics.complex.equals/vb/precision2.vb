' Visual Basic .NET Document
Option Strict On

' <Snippet7>
Imports System.Numerics

Module Example
   Public Sub Main()
      Dim n1 As Single = 1.430718e-12
      Dim c1 As New Complex(1.430718e-12, 0)
      Dim difference As Double = .0001
      
      ' Compare the values
      Dim result As Boolean = (Math.Abs(c1.Real - n1) <= c1.Real * difference) And
                              c1.Imaginary = 0
      Console.WriteLine("{0} = {1}: {2}", c1, n1, result)       
   End Sub
End Module
' The example displays the following output:
'       (1.430718E-12, 0) = 1.430718E-12: True
' </Snippet7>
