   private void GetFixedTransitionTimes()
   {
      ReadOnlyCollection<TimeZoneInfo> timeZones = TimeZoneInfo.GetSystemTimeZones();
      DateTimeFormatInfo dateInfo = CultureInfo.CurrentCulture.DateTimeFormat;
      foreach (TimeZoneInfo zone in timeZones)
      {
         TimeZoneInfo.AdjustmentRule[] adjustmentRules = zone.GetAdjustmentRules();
         foreach (TimeZoneInfo.AdjustmentRule adjustmentRule in adjustmentRules)
         {
            TimeZoneInfo.TransitionTime daylightStart = adjustmentRule.DaylightTransitionStart;
            if (daylightStart.IsFixedDateRule)
               Console.WriteLine("For {0}, daylight savings time begins at {1:t} on {2} {3} from {4:d} to {5:d}.", 
                                 zone.StandardName, 
                                 daylightStart.TimeOfDay,  
                                 dateInfo.GetMonthName(daylightStart.Month), 
                                 daylightStart.Day, 
                                 adjustmentRule.DateStart, 
                                 adjustmentRule.DateEnd);
            TimeZoneInfo.TransitionTime daylightEnd = adjustmentRule.DaylightTransitionEnd;
            if (daylightEnd.IsFixedDateRule)
               Console.WriteLine("For {0}, daylight savings time ends at {1:t} on {2} {3} from {4:d} to {5:d}.", 
                                 zone.StandardName, 
                                 daylightEnd.TimeOfDay,  
                                 dateInfo.GetMonthName(daylightEnd.Month), 
                                 daylightEnd.Day, 
                                 adjustmentRule.DateStart, 
                                 adjustmentRule.DateEnd);
         }
      }   
   }