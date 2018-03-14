' Visual Basic .NET Document
Option Strict On

Imports System.Numerics

Module modMain
   Public Sub Main()
      ExplicitFromDecimal()
      Console.WriteLine()
      ExplicitFromDouble()
      Console.WriteLine()
      ExplicitFromSingle()
      Console.WriteLine()
      DoublePrecision()
      Console.WriteLine()
      SinglePrecision()
   End Sub

   Private Sub ExplicitfromDecimal()
      ' <Snippet1>
      ' Explicit Decimal to BigInteger conversion
      Dim decimals() As Decimal = { Decimal.MinValue, -15632.991d, 9029321.12d, 
                                    Decimal.MaxValue }
      Dim number As BigInteger 
      
      Console.WriteLine("{0,35} {1,35}", "Decimal", "BigInteger")
      Console.WriteLine()
      For Each value As Decimal In decimals
         number = CType(value, BigInteger)
         Console.WriteLine("{0,35} {1,35}",
                           value, number)
      Next
      ' The example displays the following output:
      '
      '                          Decimal                          BigInteger
      '    
      '    -79228162514264337593543950335      -79228162514264337593543950335
      '                       -15632.991                              -15632
      '                       9029321.12                             9029321
      '    79228162514264337593543950335       79228162514264337593543950335
      ' </Snippet1>
   End Sub
   
   Private Sub ExplicitFromDouble()
      ' <Snippet2>
      Dim doubles() As Double = { Double.MinValue, -1.430955172e03, 2.410970032e05, 
                                  Double.MaxValue, Double.PositiveInfinity, 
                                  Double.NegativeInfinity, Double.NaN }
      Dim number As BigInteger
      
      Console.WriteLine("{0,37} {1,37}", "Double", "BigInteger")
      Console.WriteLine()
      For Each value As Double In doubles
         Try
            number = CType(value, BigInteger)
            Console.WriteLine("{0,37} {1,37}", value, number)
         Catch e As OverflowException
            Console.WriteLine("{0,37} {1,37}", value, "OverflowException")
         End Try      
      Next
      ' The example displays the following output:
      '                                Double                            BigInteger
      ' 
      '                -1.79769313486232E+308  -1.7976931348623157081452742373E+308
      '                          -1430.955172                                 -1430
      '                           241097.0032                                241097
      '                 1.79769313486232E+308   1.7976931348623157081452742373E+308
      '                              Infinity                     OverflowException
      '                             -Infinity                     OverflowException
      '                                   NaN                     OverflowException      
      ' </Snippet2>
   End Sub
   
   Private Sub ExplicitFromSingle()
      ' <Snippet3>
      Dim singles() As Single = { Single.MinValue, -1.430955172e03, 2.410970032e05, 
                                  Single.MaxValue, Single.PositiveInfinity, 
                                  Single.NegativeInfinity, Single.NaN }
      Dim number As BigInteger
      
      Console.WriteLine("{0,37} {1,37}", "Single", "BigInteger")
      Console.WriteLine()
      For Each value As Single In singles
         Try
            number = CType(value, BigInteger)
            Console.WriteLine("{0,37} {1,37}", value, number)
         Catch e As OverflowException
            Console.WriteLine("{0,37} {1,37}", value, "OverflowException")
         End Try
      Next     
      ' The example displays the following output:
      '           Single                            BigInteger
      ' 
      '    -3.402823E+38   -3.4028234663852885981170418348E+38
      '        -1430.955                                 -1430
      '           241097                                241097
      '     3.402823E+38    3.4028234663852885981170418348E+38
      '         Infinity                     OverflowException
      '        -Infinity                     OverflowException
      '              NaN                     OverflowException      
      ' </Snippet3>
   End Sub
   
   Private Sub DoublePrecision()
      Console.WriteLine(Double.MaxValue)
      ' <Snippet4>
      ' Increase a BigInteger so it exceeds Double.MaxValue.
      Dim number1 As BigInteger = CType(Double.MaxValue, BigInteger)
      Dim number2 As BigInteger = number1
      number2 = number2 + 9.999e291
      ' Compare the BigInteger values for equality.
      Console.WriteLine("BigIntegers equal: {0}", number2.Equals(number1))
      
      ' Convert the BigInteger to a Double.
      Dim dbl As Double = CType(number2, Double)
      
      ' Display the two values.
      Console.WriteLine("BigInteger: {0}", number2)
      Console.WriteLine("Double:     {0}", dbl)      
      ' The example displays the following output:
      '       BigIntegers equal: False
      '       BigInteger: 1.7976931348623158081352742373E+308
      '       Double:     1.79769313486232E+308      
      ' </Snippet4>
   End Sub   
   
   Private Sub SinglePrecision()
      Console.WriteLine(Single.MaxValue)
      ' <Snippet5>
      ' Increase a BigInteger so it exceeds Single.MaxValue.
      Dim number1 As BigInteger = CType(Single.MaxValue, BigInteger)
      Dim number2 As BigInteger = number1
      number2 = number2 + 9.999e30
      ' Compare the BigInteger values for equality.
      Console.WriteLine("BigIntegers equal: {0}", number2.Equals(number1))
      
      ' Convert the BigInteger to a Single.
      Dim sng As Single = CType(number2, Single)
      
      ' Display the two values.
      Console.WriteLine("BigInteger: {0}", number2)
      Console.WriteLine("Single:     {0}", sng)      
      ' The example displays the following output:
      '       BigIntegers equal: False
      '       BigInteger: 3.4028235663752885981170396038E+38
      '       Single:     3.402823E+38
      ' </Snippet5>
   End Sub
End Module

