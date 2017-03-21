      string stringToConvert; 
      byte byteValue;
      
      stringToConvert = " 214 ";
      try {
         byteValue = Byte.Parse(stringToConvert, CultureInfo.InvariantCulture);
         Console.WriteLine("Converted '{0}' to {1}.", stringToConvert, byteValue);
      }
      catch (FormatException) {
         Console.WriteLine("Unable to parse '{0}'.", stringToConvert); }
      catch (OverflowException) {
         Console.WriteLine("'{0}' is greater than {1} or less than {2}.", 
                           stringToConvert, Byte.MaxValue, Byte.MinValue); }
      
      stringToConvert = " + 214 ";
      try {
         byteValue = Byte.Parse(stringToConvert, CultureInfo.InvariantCulture);
         Console.WriteLine("Converted '{0}' to {1}.", stringToConvert, byteValue);
      }
      catch (FormatException) {
         Console.WriteLine("Unable to parse '{0}'.", stringToConvert); }
      catch (OverflowException) {
         Console.WriteLine("'{0}' is greater than {1} or less than {2}.", 
                           stringToConvert, Byte.MaxValue, Byte.MinValue); }
      
      stringToConvert = " +214 ";
      try {
         byteValue = Byte.Parse(stringToConvert, CultureInfo.InvariantCulture);
         Console.WriteLine("Converted '{0}' to {1}.", stringToConvert, byteValue);
      }
      catch (FormatException) {
         Console.WriteLine("Unable to parse '{0}'.", stringToConvert); }
      catch (OverflowException) {
         Console.WriteLine("'{0}' is greater than {1} or less than {2}.", 
                           stringToConvert, Byte.MaxValue, Byte.MinValue); }
      // The example displays the following output to the console:
      //       Converted ' 214 ' to 214.
      //       Unable to parse ' + 214 '.
      //       Converted ' +214 ' to 214.