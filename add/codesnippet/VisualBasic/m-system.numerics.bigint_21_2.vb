      Dim number As BigInteger = BigInteger.Parse("~6354129876", New BigIntegerFormatProvider)
      ' Display value using same formatting information
      Console.WriteLine(number.ToString(New BigIntegerFormatProvider))
      ' Display value using formatting of current culture
      Console.WriteLine(number)