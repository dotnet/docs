      uint number = UInt32.MaxValue;
      System.Globalization.NumberFormatInfo nfi = new System.Globalization.NumberFormatInfo();
      nfi.NegativeSign = "~";
      nfi.PositiveSign = "!";
      
      Console.WriteLine("{0,-8}  -->  {1,8}",
                        Convert.ToString(number, System.Globalization.CultureInfo.InvariantCulture),
                        Convert.ToString(number, nfi));
      // The example displays the following output:
      //       4294967295  -->  4294967295