      string value;
      NumberStyles style;
      CultureInfo culture;
      decimal number;
      
      // Parse currency value using en-GB culture.
      value = "£1,097.63";
      style = NumberStyles.Number | NumberStyles.AllowCurrencySymbol;
      culture = CultureInfo.CreateSpecificCulture("en-GB");
      if (Decimal.TryParse(value, style, culture, out number))
         Console.WriteLine("Converted '{0}' to {1}.", value, number);
      else
         Console.WriteLine("Unable to convert '{0}'.", value);
      // Displays: 
      //       Converted '£1,097.63' to 1097.63.
      
      value = "1345,978";
      style = NumberStyles.AllowDecimalPoint;
      culture = CultureInfo.CreateSpecificCulture("fr-FR");
      if (Decimal.TryParse(value, style, culture, out number))
         Console.WriteLine("Converted '{0}' to {1}.", value, number);
      else
         Console.WriteLine("Unable to convert '{0}'.", value);
      // Displays:
      //       Converted '1345,978' to 1345.978.

      value = "1.345,978";
      style = NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands;
      culture = CultureInfo.CreateSpecificCulture("es-ES");
      if (Decimal.TryParse(value, style, culture, out number))
         Console.WriteLine("Converted '{0}' to {1}.", value, number);
      else
         Console.WriteLine("Unable to convert '{0}'.", value);
      // Displays: 
      //       Converted '1.345,978' to 1345.978.
      
      value = "1 345,978";
      if (Decimal.TryParse(value, style, culture, out number))
         Console.WriteLine("Converted '{0}' to {1}.", value, number);
      else
         Console.WriteLine("Unable to convert '{0}'.", value);
      // Displays:
      //       Unable to convert '1 345,978'.