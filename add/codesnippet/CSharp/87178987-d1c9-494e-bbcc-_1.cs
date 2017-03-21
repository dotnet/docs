      // The statement:
      //    BigInteger number = Int64.MaxValue + Int32.MaxValue;
      // produces compiler error CS0220: The operation overflows at compile time in checked mode.
      // The alternative:
      BigInteger number = BigInteger.Add(Int64.MaxValue, Int32.MaxValue);