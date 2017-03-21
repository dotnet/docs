      string stringToConvert;
      short number;
      
      stringToConvert = " 214 ";
      try
      {
         number = Int16.Parse(stringToConvert, CultureInfo.InvariantCulture);
         Console.WriteLine("Converted '{0}' to {1}.", stringToConvert, number);
      }
      catch (FormatException)
      {
         Console.WriteLine("Unable to parse '{0}'.", stringToConvert);
      }
      catch (OverflowException)
      {
         Console.WriteLine("'{0'} is out of range of the Int16 data type.", 
                           stringToConvert);
      }
      
      stringToConvert = " + 214";                     
      try
      {
         number = Int16.Parse(stringToConvert, CultureInfo.InvariantCulture);
         Console.WriteLine("Converted '{0}' to {1}.", stringToConvert, number);
      }
      catch (FormatException)
      {
         Console.WriteLine("Unable to parse '{0}'.", stringToConvert);
      }
      catch (OverflowException)
      {
         Console.WriteLine("'{0'} is out of range of the Int16 data type.", 
                           stringToConvert);
      }
      
      stringToConvert = " +214 "; 
      try
      {
         number = Int16.Parse(stringToConvert, CultureInfo.InvariantCulture);
         Console.WriteLine("Converted '{0}' to {1}.", stringToConvert, number);
      }
      catch (FormatException)
      {
         Console.WriteLine("Unable to parse '{0}'.", stringToConvert);
      }
      catch (OverflowException)
      {
         Console.WriteLine("'{0'} is out of range of the Int16 data type.", 
                           stringToConvert);
      }
      // The example displays the following output to the console:
      //       Converted ' 214 ' to 214.
      //       Unable to parse ' + 214'.
      //       Converted ' +214 ' to 214.