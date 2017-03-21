      string value;
      decimal number;
      NumberStyles style;
      CultureInfo provider;
      
      // Parse string using "." as the thousands separator 
      // and " " as the decimal separator. 
      value = "892 694,12";
      style = NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands;
      provider = new CultureInfo("fr-FR");

      number = Decimal.Parse(value, style, provider);  
      Console.WriteLine("'{0}' converted to {1}.", value, number);
      // Displays: 
      //    892 694,12' converted to 892694.12.

      try
      {
         number = Decimal.Parse(value, style, CultureInfo.InvariantCulture);  
         Console.WriteLine("'{0}' converted to {1}.", value, number);
      }   
      catch (FormatException)
      {
         Console.WriteLine("Unable to parse '{0}'.", value);
      }
      // Displays: 
      //    Unable to parse '892 694,12'.  
      
      // Parse string using "$" as the currency symbol for en-GB and  
      // en-us cultures.
      value = "$6,032.51";
      style = NumberStyles.Number | NumberStyles.AllowCurrencySymbol;
      provider = new CultureInfo("en-GB");

      try
      {
         number = Decimal.Parse(value, style, provider);  
         Console.WriteLine("'{0}' converted to {1}.", value, number);
      }   
      catch (FormatException)
      {
         Console.WriteLine("Unable to parse '{0}'.", value);
      }
      // Displays: 
      //    Unable to parse '$6,032.51'.

      provider = new CultureInfo("en-US");
      number = Decimal.Parse(value, style, provider);  
      Console.WriteLine("'{0}' converted to {1}.", value, number);
      // Displays: 
      //    '$6,032.51' converted to 6032.51.