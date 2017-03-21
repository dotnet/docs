      long[] numbers = { ((long) Int32.MinValue) * 2, ((long) Int32.MaxValue) * 2};
      System.Globalization.NumberFormatInfo nfi = new System.Globalization.NumberFormatInfo();
      nfi.NegativeSign = "~";
      nfi.PositiveSign = "!";
      
      foreach (long number in numbers)
         Console.WriteLine("{0,-12}  -->  {1,12}", 
                           Convert.ToString(number, System.Globalization.CultureInfo.InvariantCulture), 
                           Convert.ToString(number, nfi));
      // The example displays the following output:
      //       -4294967296  -->  ~4294967296
      //       4294967294  -->  4294967294