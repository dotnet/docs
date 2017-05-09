' Visual Basic .NET Document
Option Strict On

Module Example
   Public Sub Main()
      ' <Snippet6>
      Dim n1 As Double = 16.33
      Dim c1 As New System.Numerics.Complex(16.33, 0)
      Console.WriteLine(c1.Equals(n1))                ' Returns True.
      ' </Snippet6>
   End Sub
End Module

