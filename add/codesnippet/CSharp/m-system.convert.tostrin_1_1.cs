      ushort number = UInt16.MaxValue;
      System.Globalization.NumberFormatInfo nfi = new System.Globalization.NumberFormatInfo();
      nfi.NegativeSign = "~";
      nfi.PositiveSign = "!";
      
      Console.WriteLine("{0,-6}  -->  {1,6}",
                        Convert.ToString(number, System.Globalization.CultureInfo.InvariantCulture),
                        Convert.ToString(number, nfi));
      // The example displays the following output:
      //       65535   -->   65535