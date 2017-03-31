' Visual Basic .NET Document
Option Strict On

Module Example
   Public Sub Main()
      TestForEquality()
      Console.WriteLine()
      TestForApproximateEquality()
   End Sub
   
   Private Sub TestForEquality()      
      ' <Snippet4>
      Dim c1 As New System.Numerics.Complex(3.33333, .142857)
      Dim c2 As New System.Numerics.Complex(10/3, 1/7)
      Console.WriteLine("{0} = {1}: {2}", c1, c2, c1.Equals(c2))       
      ' The example displays the following output:
      '    (3.33333, 0.142857) = (3.33333333333333, 0.142857142857143): False
      ' </Snippet4>
   End Sub
   
   Private Sub TestForApproximateEquality()
      ' <Snippet5>
      Dim c1 As New System.Numerics.Complex(3.33333, .142857)
      Dim c2 As New System.Numerics.Complex(10/3.0, 1.0/7)
      Dim difference As Double = .0001
      
      ' Compare the values
      Dim result As Boolean = (Math.Abs(c1.Real - c2.Real) <= c1.Real * difference) And
                              (Math.Abs(c1.Imaginary - c2.Imaginary) <= c1.Imaginary * difference)
      Console.WriteLine("{0} = {1}: {2}", c1, c2, result)       
      ' The example displays the following output:
      '    (3.33333, 0.142857) = (3.33333333333333, 0.142857142857143): True
      ' </Snippet5>
   End Sub
End Module
