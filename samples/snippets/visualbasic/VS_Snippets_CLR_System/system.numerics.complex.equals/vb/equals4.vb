' Visual Basic .NET Document
Option Strict On

' <Snippet8>
Imports System.Numerics

Module Example
   Public Sub Main()
      Dim n1 As Single = 1.430718e-12
      Dim c1 As New Complex(1.430718e-12, 0)
      Console.WriteLine("{0} = {1}: {2}", c1, n1, c1.Equals(n1))
   End Sub
End Module
' The example displays the following output:
'       (1.430718E-12, 0) = 1.430718E-12: False
' </Snippet8>
