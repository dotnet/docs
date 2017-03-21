      int[] numbers = { Int32.MinValue, Int32.MaxValue};
      System.Globalization.NumberFormatInfo nfi = new System.Globalization.NumberFormatInfo();
      nfi.NegativeSign = "~";
      nfi.PositiveSign = "!";
      
      foreach (int number in numbers)
         Console.WriteLine("{0,-12}  -->  {1,12}", 
                           Convert.ToString(number, System.Globalization.CultureInfo.InvariantCulture), 
                           Convert.ToString(number, nfi));
      // The example displays the following output:
      //       -2147483648  -->  ~2147483648
      //       2147483647  -->  2147483647