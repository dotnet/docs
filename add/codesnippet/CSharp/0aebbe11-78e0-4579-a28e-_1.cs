      // The statement
      //    BigInteger number = Int64.MaxValue * 3;
      // produces compiler error CS0220: The operation overflows at compile time in checked mode.
      // The alternative:
      BigInteger number = BigInteger.Multiply(Int64.MaxValue, 3);