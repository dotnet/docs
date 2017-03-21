      string value;
      System.Globalization.NumberStyles style;
      System.Globalization.CultureInfo culture;
      float number;
      
      // Parse currency value using en-GB culture.
      value = "�1,097.63";
      style = System.Globalization.NumberStyles.Number | 
              System.Globalization.NumberStyles.AllowCurrencySymbol;
      culture = System.Globalization.CultureInfo.CreateSpecificCulture("en-GB");
      if (Single.TryParse(value, style, culture, out number))
         Console.WriteLine("Converted '{0}' to {1}.", value, number);
      else
         Console.WriteLine("Unable to convert '{0}'.", value);
      
      value = "1345,978";
      style = System.Globalization.NumberStyles.AllowDecimalPoint;
      culture = System.Globalization.CultureInfo.CreateSpecificCulture("fr-FR");
      if (Single.TryParse(value, style, culture, out number))
         Console.WriteLine("Converted '{0}' to {1}.", value, number);
      else
         Console.WriteLine("Unable to convert '{0}'.", value);
      
      value = "1.345,978";
      style = System.Globalization.NumberStyles.AllowDecimalPoint | 
              System.Globalization.NumberStyles.AllowThousands;
      culture = System.Globalization.CultureInfo.CreateSpecificCulture("es-ES");
      if (Single.TryParse(value, style, culture, out number))
         Console.WriteLine("Converted '{0}' to {1}.", value, number);
      else
         Console.WriteLine("Unable to convert '{0}'.", value);
      
      value = "1 345,978";
      if (Single.TryParse(value, style, culture, out number))
         Console.WriteLine("Converted '{0}' to {1}.", value, number);
      else
         Console.WriteLine("Unable to convert '{0}'.", value);
      // The example displays the following output:
      //       Converted '�1,097.63' to 1097.63.
      //       Converted '1345,978' to 1345.978.
      //       Converted '1.345,978' to 1345.978.
      //       Unable to convert '1 345,978'.