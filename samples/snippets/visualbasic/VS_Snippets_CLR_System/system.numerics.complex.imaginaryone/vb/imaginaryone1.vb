' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Numerics

Module Example
   Public Sub Main()
      Dim value As Complex = Complex.ImaginaryOne
      Console.WriteLine(value.ToString())
      
      ' Instantiate a complex number with real part 0 and imaginary part 1.
      Dim value1 As New Complex(0, 1)
      Console.WriteLine(value.Equals(value1))
   End Sub
End Module
' The example displays the following output:
'       (0, 1)
'       True
' </Snippet1>
