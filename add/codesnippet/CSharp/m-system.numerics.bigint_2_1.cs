      // Create a BigInteger from a large double value.
      double doubleValue = -6e20;
      BigInteger bigIntValue = new BigInteger(doubleValue);
      Console.WriteLine("Original Double value: {0:N0}", doubleValue);
      Console.WriteLine("Original BigInteger value: {0:N0}", bigIntValue);
      // Increment and then display both values.
      doubleValue++;
      bigIntValue += BigInteger.One;
      Console.WriteLine("Incremented Double value: {0:N0}", doubleValue);
      Console.WriteLine("Incremented BigInteger value: {0:N0}", bigIntValue);
      // The example displays the following output:
      //    Original Double value: -600,000,000,000,000,000,000
      //    Original BigInteger value: -600,000,000,000,000,000,000
      //    Incremented Double value: -600,000,000,000,000,000,000
      //    Incremented BigInteger value: -599,999,999,999,999,999,999