   private void ShowPossibleUtcTimes(DateTime ambiguousTime, TimeZoneInfo timeZone)
   {
      // Determine if time is ambiguous in target time zone
      if (! timeZone.IsAmbiguousTime(ambiguousTime))
      {
         Console.WriteLine("{0} is not ambiguous in time zone {1}.", 
                           ambiguousTime, 
                           timeZone.DisplayName);
      }
      else
      {
         // Display time and its time zone (local, UTC, or indicated by timeZone argument)
         string originalTimeZoneName; 
         if (ambiguousTime.Kind == DateTimeKind.Utc)
            originalTimeZoneName = "UTC";
         else if (ambiguousTime.Kind == DateTimeKind.Local)
            originalTimeZoneName = "local time";
         else
            originalTimeZoneName = timeZone.DisplayName;

         Console.WriteLine("{0} {1} maps to the following possible times:", 
                           ambiguousTime, originalTimeZoneName);
         // Get ambiguous offsets 
         TimeSpan[] offsets = timeZone.GetAmbiguousTimeOffsets(ambiguousTime);
         // Handle times not in time zone of timeZone argument
         // Local time where timeZone is not local zone
         if ((ambiguousTime.Kind == DateTimeKind.Local) && ! timeZone.Equals(TimeZoneInfo.Local)) 
            ambiguousTime = TimeZoneInfo.ConvertTime(ambiguousTime, TimeZoneInfo.Local, timeZone);
         // UTC time where timeZone is not UTC zone   
         else if ((ambiguousTime.Kind == DateTimeKind.Utc) && ! timeZone.Equals(TimeZoneInfo.Utc))
            ambiguousTime = TimeZoneInfo.ConvertTime(ambiguousTime, TimeZoneInfo.Utc, timeZone);

         // Display each offset and its mapping to UTC
         foreach (TimeSpan offset in offsets)
         {
            if (offset.Equals(timeZone.BaseUtcOffset))
               Console.WriteLine("If {0} is {1}, {2} UTC", ambiguousTime, timeZone.StandardName, ambiguousTime - offset);
            else
               Console.WriteLine("If {0} is {1}, {2} UTC", ambiguousTime, timeZone.DaylightName, ambiguousTime - offset);
         }
      }            
   }