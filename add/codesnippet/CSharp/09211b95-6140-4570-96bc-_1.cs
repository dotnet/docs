      string dateString;
      DateTimeOffset parsedDate;

      dateString = "05/01/2008 6:00:00";
      // Assume time is local 
      if (DateTimeOffset.TryParse(dateString, null as IFormatProvider, 
                                  DateTimeStyles.AssumeLocal, 
                                  out parsedDate))
         Console.WriteLine("'{0}' was converted to to {1}.", 
                           dateString, parsedDate.ToString());
      else
         Console.WriteLine("Unable to parse '{0}'.", dateString);    
      
      // Assume time is UTC
      if (DateTimeOffset.TryParse(dateString, null as IFormatProvider, 
                                  DateTimeStyles.AssumeUniversal, 
                                  out parsedDate))
         Console.WriteLine("'{0}' was converted to to {1}.", 
                           dateString, parsedDate.ToString());
      else
         Console.WriteLine("Unable to parse '{0}'.", dateString);    

      // Parse and convert to UTC 
      dateString = "05/01/2008 6:00:00AM +5:00";
      if (DateTimeOffset.TryParse(dateString, null as IFormatProvider, 
                                 DateTimeStyles.AdjustToUniversal, 
                                 out parsedDate))
         Console.WriteLine("'{0}' was converted to to {1}.", 
                           dateString, parsedDate.ToString());
      else
         Console.WriteLine("Unable to parse '{0}'.", dateString);    
      // The example displays the following output to the console:
      //    '05/01/2008 6:00:00' was converted to to 5/1/2008 6:00:00 AM -07:00.
      //    '05/01/2008 6:00:00' was converted to to 5/1/2008 6:00:00 AM +00:00.
      //    '05/01/2008 6:00:00AM +5:00' was converted to to 5/1/2008 1:00:00 AM +00:00.      