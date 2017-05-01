' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Numerics

Module Example
   Public Sub Main()
      Dim complex1 As New Complex(2.0, 3.0)
      Console.WriteLine("|{0}| = {1:N2}", complex1, Complex.Abs(complex1))
      Console.WriteLine("Equal to Magnitude: {0}", 
                        Complex.Abs(complex1).Equals(complex1.Magnitude)) 
   End Sub
End Module
' The example displays the following output:
'       |(2, 3)| = 3.61
'       Equal to Magnitude: True
' </Snippet1>
