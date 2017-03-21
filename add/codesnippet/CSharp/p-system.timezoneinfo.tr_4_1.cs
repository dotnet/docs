   private enum WeekOfMonth
   {
      First = 1,
      Second = 2,
      Third = 3,
      Fourth = 4,
      Last = 5
   }
   
   private void GetFloatingTransitionTimes()
   {
      ReadOnlyCollection<TimeZoneInfo> timeZones = TimeZoneInfo.GetSystemTimeZones();
      foreach (TimeZoneInfo zone in timeZones)
      {
         TimeZoneInfo.AdjustmentRule[] adjustmentRules = zone.GetAdjustmentRules();
         DateTimeFormatInfo dateInfo = CultureInfo.CurrentCulture.DateTimeFormat;
         foreach (TimeZoneInfo.AdjustmentRule adjustmentRule in adjustmentRules)
         {
            TimeZoneInfo.TransitionTime daylightStart = adjustmentRule.DaylightTransitionStart;
            if (! daylightStart.IsFixedDateRule)
               Console.WriteLine("{0}, {1:d}-{2:d}: Begins at {3:t} on the {4} {5} of {6}.", 
                                 zone.StandardName, 
                                 adjustmentRule.DateStart, 
                                 adjustmentRule.DateEnd,                                 
                                 daylightStart.TimeOfDay, 
                                 ((WeekOfMonth)daylightStart.Week).ToString(),  
                                 daylightStart.DayOfWeek.ToString(),
                                 dateInfo.GetMonthName(daylightStart.Month));

            TimeZoneInfo.TransitionTime daylightEnd = adjustmentRule.DaylightTransitionEnd;
            if (! daylightEnd.IsFixedDateRule)
               Console.WriteLine("{0}, {1:d}-{2:d}: Ends at {3:t} on the {4} {5} of {6}.", 
                                 zone.StandardName, 
                                 adjustmentRule.DateStart, 
                                 adjustmentRule.DateEnd,                                 
                                 daylightEnd.TimeOfDay, 
                                 ((WeekOfMonth)daylightEnd.Week).ToString(),  
                                 daylightEnd.DayOfWeek.ToString(), 
                                 dateInfo.GetMonthName(daylightEnd.Month));
         }
      }   
   }