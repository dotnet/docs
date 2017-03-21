      // Local time changes on 3/11/2007 at 2:00 AM
      DateTimeOffset originalTime, localTime;
      
      originalTime = new DateTimeOffset(2007, 3, 11, 3, 0, 0, 
                                        new TimeSpan(-6, 0, 0));
      localTime = originalTime.ToLocalTime();
      Console.WriteLine("Converted {0} to {1}.", originalTime.ToString(), 
                                                 localTime.ToString());   

      originalTime = new DateTimeOffset(2007, 3, 11, 4, 0, 0, 
                                        new TimeSpan(-6, 0, 0));
      localTime = originalTime.ToLocalTime();
      Console.WriteLine("Converted {0} to {1}.", originalTime.ToString(), 
                                                 localTime.ToString());    

      // Define a summer UTC time
      originalTime = new DateTimeOffset(2007, 6, 15, 8, 0, 0, 
                                        TimeSpan.Zero);
      localTime = originalTime.ToLocalTime();
      Console.WriteLine("Converted {0} to {1}.", originalTime.ToString(),
                                                 localTime.ToString());    

      // Define a winter time
      originalTime = new DateTimeOffset(2007, 11, 30, 14, 0, 0, 
                                        new TimeSpan(3, 0, 0));
      localTime = originalTime.ToLocalTime();
      Console.WriteLine("Converted {0} to {1}.", originalTime.ToString(), 
                                                 localTime.ToString());
      // The example produces the following output:
      //    Converted 3/11/2007 3:00:00 AM -06:00 to 3/11/2007 1:00:00 AM -08:00.
      //    Converted 3/11/2007 4:00:00 AM -06:00 to 3/11/2007 3:00:00 AM -07:00.
      //    Converted 6/15/2007 8:00:00 AM +00:00 to 6/15/2007 1:00:00 AM -07:00.
      //    Converted 11/30/2007 2:00:00 PM +03:00 to 11/30/2007 3:00:00 AM -08:00.                                                           