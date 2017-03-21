      decimal[] decimalValues = { -1790.533m, -15.1514m, 18903.79m, 9180098.003m };
      foreach (decimal decimalValue in decimalValues)
      {
         BigInteger number = new BigInteger(decimalValue);
         Console.WriteLine("Instantiated BigInteger value {0} from the Decimal value {1}.",
                           number, decimalValue);
      }                 
      // The example displays the following output:
      //    Instantiated BigInteger value -1790 from the Decimal value -1790.533.
      //    Instantiated BigInteger value -15 from the Decimal value -15.1514.
      //    Instantiated BigInteger value 18903 from the Decimal value 18903.79.
      //    Instantiated BigInteger value 9180098 from the Decimal value 9180098.003.