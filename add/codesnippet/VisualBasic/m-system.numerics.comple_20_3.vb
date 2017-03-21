      Dim c1 As New System.Numerics.Complex(3.33333, .142857)
      Dim c2 As New System.Numerics.Complex(10/3.0, 1.0/7)
      Dim difference As Double = .0001
      
      ' Compare the values
      Dim result As Boolean = (Math.Abs(c1.Real - c2.Real) <= c1.Real * difference) And
                              (Math.Abs(c1.Imaginary - c2.Imaginary) <= c1.Imaginary * difference)
      Console.WriteLine("{0} = {1}: {2}", c1, c2, result)       
      ' The example displays the following output:
      '    (3.33333, 0.142857) = (3.33333333333333, 0.142857142857143): True