      BigInteger n1 = BigInteger.Pow(154382190, 3);
      BigInteger n2 = BigInteger.Multiply(1643590, 166935);
      try
      {
         Console.WriteLine("The greatest common divisor of {0} and {1} is {2}.", 
                           n1, n2, BigInteger.GreatestCommonDivisor(n1, n2));
      }
      catch (ArgumentOutOfRangeException e)
      {
         Console.WriteLine("Unable to calculate the greatest common divisor:");
         Console.WriteLine("   {0} is an invalid value for {1}", 
                           e.ActualValue, e.ParamName);
      }