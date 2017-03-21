      BigInteger bigNumber = BigInteger.Pow(2, 63) - BigInteger.One;
      ulong uNumber = Int64.MaxValue & 0x7FFFFFFFFFFFFFFF;
      if (uNumber != bigNumber)
      {
         // Do something...
      }