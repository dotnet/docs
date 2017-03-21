      Dim n1 As BigInteger = BigInteger.Pow(154382190, 3)
      Dim n2 As BigInteger = BigInteger.Multiply(1643590, 166935)
      Try
         Console.WriteLine("The greatest common divisor of {0} and {1} is {2}.", _
                           n1, n2, BigInteger.GreatestCommonDivisor(n1, n2))
      Catch e As ArgumentOutOfRangeException
         Console.WriteLine("Unable to calculate the greatest common divisor:")
         Console.WriteLine("   {0} is an invalid value for {1}", _
                           e.ActualValue, e.ParamName)
      End Try                           