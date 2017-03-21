      // The statement
      //    BigInteger number = -Int64.MinValue;
      // produces compiler error CS0220: The operation overflows at compile time in checked mode.
      // The alternative:
      BigInteger number = BigInteger.Negate(Int64.MinValue);     