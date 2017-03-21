      System.Globalization.DateTimeFormatInfo dtfi; 
      
      dtfi = System.Globalization.DateTimeFormatInfo.InvariantInfo;
      Console.WriteLine(dtfi.IsReadOnly);               

      dtfi = new System.Globalization.DateTimeFormatInfo();
      Console.WriteLine(dtfi.IsReadOnly);               
      
      dtfi = System.Globalization.CultureInfo.InvariantCulture.DateTimeFormat;
      Console.WriteLine(dtfi.IsReadOnly);                
      // The example displays the following output:
      //       True
      //       False
      //       True      