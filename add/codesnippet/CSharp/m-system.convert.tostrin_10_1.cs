      ulong number = UInt64.MaxValue;
      System.Globalization.NumberFormatInfo nfi = new System.Globalization.NumberFormatInfo();
      nfi.NegativeSign = "~";
      nfi.PositiveSign = "!";
      
      Console.WriteLine("{0,-12}  -->  {1,12}",
                        Convert.ToString(number, System.Globalization.CultureInfo.InvariantCulture),
                        Convert.ToString(number, nfi));
      // The example displays the following output:
      //    18446744073709551615  -->  18446744073709551615