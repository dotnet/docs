' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Numerics

Module Example
   Public Sub Main()
      Dim value As Complex = Complex.Zero
      Console.WriteLine(value.ToString())
      
      ' Instantiate a complex number with real part 1 and imaginary part 0.
      Dim value1 As New Complex(0, 0)
      Console.WriteLine(value.Equals(value1))
   End Sub
End Module
' The example displays the following output:
'       (0, 0)
'       True
' </Snippet1>
