      NumberFormatInfo fmt = new NumberFormatInfo();
      fmt.NegativeSign = "~";
      
      BigInteger number = BigInteger.Parse("~6354129876", fmt);
      // Display value using same formatting information
      Console.WriteLine(number.ToString(fmt));
      // Display value using formatting of current culture
      Console.WriteLine(number);