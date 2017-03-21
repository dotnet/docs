      BigInteger number = BigInteger.Parse("~6354129876", new BigIntegerFormatProvider());
      // Display value using same formatting information
      Console.WriteLine(number.ToString(new BigIntegerFormatProvider()));
      // Display value using formatting of current culture
      Console.WriteLine(number);