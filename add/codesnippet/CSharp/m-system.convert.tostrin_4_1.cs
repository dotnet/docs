      // Create a NumberFormatInfo object and set several of its
      // properties that control default integer formatting.
      System.Globalization.NumberFormatInfo provider = new System.Globalization.NumberFormatInfo();
      provider.NegativeSign = "minus ";

      long[] values = { -200, 0, 1000 };
      
      foreach (long value in values)
         Console.WriteLine("{0,-6}  -->  {1,10}", 
                           value, Convert.ToString(value, provider));
      // The example displays the following output:
      //       -200    -->   minus 200
      //       0       -->           0
      //       1000    -->        1000