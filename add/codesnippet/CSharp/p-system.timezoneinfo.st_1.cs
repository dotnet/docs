   private void DisplayDateWithTimeZoneName(DateTime date1, TimeZoneInfo timeZone)
   {
      Console.WriteLine("The time is {0:t} on {0:d} {1}", 
                        date1, 
                        timeZone.IsDaylightSavingTime(date1) ?
                            timeZone.DaylightName : timeZone.StandardName);   
   }
   // The example displays output similar to the following:
   //    The time is 1:00 AM on 4/2/2006 Pacific Standard Time   