      string dateString, format;  
      DateTimeOffset result;
      CultureInfo provider = CultureInfo.InvariantCulture;
      
      // Parse date-only value with invariant culture and assume time is UTC.
      dateString = "06/15/2008";
      format = "d";
      try
      {
         result = DateTimeOffset.ParseExact(dateString, format, provider, 
                                            DateTimeStyles.AssumeUniversal);
         Console.WriteLine("'{0}' converts to {1}.", dateString, result.ToString());
      }
      catch (FormatException)
      {
         Console.WriteLine("'{0}' is not in the correct format.", dateString);
      } 
      
      // Parse date-only value with leading white space.
      // Should throw a FormatException because only trailing whitespace is  
      // specified in method call.
      dateString = " 06/15/2008";
      try
      {
         result = DateTimeOffset.ParseExact(dateString, format, provider, 
                                            DateTimeStyles.AllowTrailingWhite);
         Console.WriteLine("'{0}' converts to {1}.", dateString, result.ToString());
      }   
      catch (FormatException)
      {
         Console.WriteLine("'{0}' is not in the correct format.", dateString);
      } 

      // Parse date and time value, and allow all white space.
      dateString = " 06/15/   2008  15:15    -05:00";
      format = "MM/dd/yyyy H:mm zzz";
      try
      {
         result = DateTimeOffset.ParseExact(dateString, format, provider, 
                                            DateTimeStyles.AllowWhiteSpaces);
         Console.WriteLine("'{0}' converts to {1}.", dateString, result.ToString());
      }   
      catch (FormatException)
      {
         Console.WriteLine("'{0}' is not in the correct format.", dateString);
      } 
      
      // Parse date and time and convert to UTC.
      dateString = "  06/15/2008 15:15:30 -05:00";
      format = "MM/dd/yyyy H:mm:ss zzz"; 
      try
      {
         result = DateTimeOffset.ParseExact(dateString, format, provider, 
                                            DateTimeStyles.AllowWhiteSpaces |
                                            DateTimeStyles.AdjustToUniversal);
         Console.WriteLine("'{0}' converts to {1}.", dateString, result.ToString());
      }
      catch (FormatException)
      {
         Console.WriteLine("'{0}' is not in the correct format.", dateString);
      } 
      // The example displays the following output:
      //    '06/15/2008' converts to 6/15/2008 12:00:00 AM +00:00.
      //    ' 06/15/2008' is not in the correct format.
      //    ' 06/15/   2008  15:15    -05:00' converts to 6/15/2008 3:15:00 PM -05:00.
      //    '  06/15/2008 15:15:30 -05:00' converts to 6/15/2008 8:15:30 PM +00:00.