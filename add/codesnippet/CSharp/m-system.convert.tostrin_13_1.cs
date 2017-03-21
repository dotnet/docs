      short[] numbers = { Int16.MinValue, Int16.MaxValue};
      System.Globalization.NumberFormatInfo nfi = new System.Globalization.NumberFormatInfo();
      nfi.NegativeSign = "~";
      nfi.PositiveSign = "!";
      
      foreach (short number in numbers)
         Console.WriteLine("{0,-8}  -->  {1,8}", 
                           Convert.ToString(number, System.Globalization.CultureInfo.InvariantCulture), 
                           Convert.ToString(number, nfi));
      // The example displays the following output:
      //       -32768    -->    ~32768
      //       32767     -->     32767