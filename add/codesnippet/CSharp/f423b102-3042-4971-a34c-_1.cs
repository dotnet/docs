      string dateString, format;  
      DateTimeOffset result;
      IFormatProvider provider = CultureInfo.InvariantCulture;
      
      // Parse date-only value with invariant culture and assume time is UTC.
      dateString = "06/15/2008";
      format = "d";
      if (DateTimeOffset.TryParseExact(dateString, format, provider, 
                                       DateTimeStyles.AssumeUniversal, 
                                       out result))
         Console.WriteLine("'{0}' converts to {1}.", dateString, result.ToString());
      else
         Console.WriteLine("'{0}' is not in the correct format.", dateString);
      
      // Parse date-only value with leading white space.
      // Should return False because only trailing whitespace is  
      // specified in method call.
      dateString = " 06/15/2008";
      if (DateTimeOffset.TryParseExact(dateString, format, provider, 
                                       DateTimeStyles.AllowTrailingWhite, 
                                       out result))
         Console.WriteLine("'{0}' converts to {1}.", dateString, result.ToString());
      else
         Console.WriteLine("'{0}' is not in the correct format.", dateString);

      // Parse date and time value, and allow all white space.
      dateString = " 06/15/   2008  15:15    -05:00";
      format = "MM/dd/yyyy H:mm zzz";
      if (DateTimeOffset.TryParseExact(dateString, format, provider, 
                                       DateTimeStyles.AllowWhiteSpaces, 
                                       out result))
         Console.WriteLine("'{0}' converts to {1}.", dateString, result.ToString());
      else
         Console.WriteLine("'{0}' is not in the correct format.", dateString);
      
      // Parse date and time and convert to UTC.
      dateString = "  06/15/2008 15:15:30 -05:00";   
      format = "MM/dd/yyyy H:mm:ss zzz";       
      if (DateTimeOffset.TryParseExact(dateString, format, provider, 
                                      DateTimeStyles.AllowWhiteSpaces | 
                                      DateTimeStyles.AdjustToUniversal, 
                                      out result))
         Console.WriteLine("'{0}' converts to {1}.", dateString, result.ToString());
      else
         Console.WriteLine("'{0}' is not in the correct format.", dateString);
      // The example displays the following output:
      //    '06/15/2008' converts to 6/15/2008 12:00:00 AM +00:00.
      //    ' 06/15/2008' is not in the correct format.
      //    ' 06/15/   2008  15:15    -05:00' converts to 6/15/2008 3:15:00 PM -05:00.
      //    '  06/15/2008 15:15:30 -05:00' converts to 6/15/2008 8:15:30 PM +00:00.