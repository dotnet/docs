      // The statement
      //    BigInteger number = Int64.MinValue - Int64.MaxValue;
      // produces compiler error CS0220: The operation overflows at compile time in checked mode.
      // The alternative:
      BigInteger number = BigInteger.Subtract(Int64.MinValue, Int64.MaxValue);     