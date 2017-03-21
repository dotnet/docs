      string stringToConvert = " 162";
      byte byteValue;
      try
      {
         byteValue = Byte.Parse(stringToConvert);
         Console.WriteLine("Converted '{0}' to {1}.", stringToConvert, byteValue);
      }   
      catch (FormatException)
      {
         Console.WriteLine("Unable to parse '{0}'.", stringToConvert);
      }
      catch (OverflowException)
      {
         Console.WriteLine("'{0}' is greater than {1} or less than {2}.", 
                           stringToConvert, Byte.MaxValue, Byte.MinValue);
      }  
      // The example displays the following output to the console:
      //       Converted ' 162' to 162.         