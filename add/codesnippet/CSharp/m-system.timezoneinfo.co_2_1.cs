      DateTime timeUtc = DateTime.UtcNow;
      try
      {
         TimeZoneInfo cstZone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
         DateTime cstTime = TimeZoneInfo.ConvertTimeFromUtc(timeUtc, cstZone);
         Console.WriteLine("The date and time are {0} {1}.", 
                           cstTime, 
                           cstZone.IsDaylightSavingTime(cstTime) ?
                                   cstZone.DaylightName : cstZone.StandardName);
      }
      catch (TimeZoneNotFoundException)
      {
         Console.WriteLine("The registry does not define the Central Standard Time zone.");
      }                           
      catch (InvalidTimeZoneException)
      {
         Console.WriteLine("Registry data on the Central Standard Time zone has been corrupted.");
      }