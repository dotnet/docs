' Visual Basic .NET Document
Option Strict On

Module Example
   Public Sub Main()
      ' <Snippet2>
      Dim c1 As New System.Numerics.Complex(6.7, -1.3)
      Dim c2 As New System.Numerics.Complex(1.4, 3.8)
      Dim result As System.Numerics.Complex = c1 - c2
      Console.WriteLine("{0} - {1} = {2}", c1, c2, result)
      ' The example displays the following output:
      '       (6.7, -1.3) - (1.4, 3.8) = (5.3, -5.1)      
      ' </Snippet2>
   End Sub
End Module

