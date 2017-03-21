      DateTime unclearDate = new DateTime(2007, 11, 4, 1, 30, 0);
      // Test if time is ambiguous.
      Console.WriteLine("In the {0}, {1} is {2}ambiguous.", 
                        TimeZoneInfo.Local.DisplayName, 
                        unclearDate, 
                        TimeZoneInfo.Local.IsAmbiguousTime(unclearDate) ? "" : "not ");
      // Test if time is DST.
      Console.WriteLine("In the {0}, {1} is {2}daylight saving time.", 
                        TimeZoneInfo.Local.DisplayName, 
                        unclearDate, 
                        TimeZoneInfo.Local.IsDaylightSavingTime(unclearDate) ? "" : "not ");
      Console.WriteLine();    
      // Report time as DST if it is either ambiguous or DST.
      if (TimeZoneInfo.Local.IsAmbiguousTime(unclearDate) || 
          TimeZoneInfo.Local.IsDaylightSavingTime(unclearDate))
          Console.WriteLine("{0} may be daylight saving time in {1}.", 
                            unclearDate, TimeZoneInfo.Local.DisplayName);  
      // The example displays the following output:
      //    In the (GMT-08:00) Pacific Time (US & Canada), 11/4/2007 1:30:00 AM is ambiguous.
      //    In the (GMT-08:00) Pacific Time (US & Canada), 11/4/2007 1:30:00 AM is not daylight saving time.
      //    
      //    11/4/2007 1:30:00 AM may be daylight saving time in (GMT-08:00) Pacific Time (US & Canada).