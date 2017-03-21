      sbyte[] numbers = { SByte.MinValue, -12, 17, SByte.MaxValue};
      System.Globalization.NumberFormatInfo nfi = new System.Globalization.NumberFormatInfo();
      nfi.NegativeSign = "~";
      nfi.PositiveSign = "!";
      foreach (sbyte number in numbers)
         Console.WriteLine(Convert.ToString(number, nfi));
      // The example displays the following output:
      //       ~128
      //       ~12
      //       17
      //       127      