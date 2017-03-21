   private enum WeekOfMonth
   {
      First = 1,
      Second = 2,
      Third = 3,
      Fourth = 4,
      Last = 5,
   }

   public void GetAllTransitionTimes()
   {
      ReadOnlyCollection<TimeZoneInfo> timeZones = TimeZoneInfo.GetSystemTimeZones();
      DateTimeFormatInfo dateInfo = CultureInfo.CurrentCulture.DateTimeFormat;
      
      foreach (TimeZoneInfo zone in timeZones)
      {
         Console.WriteLine("{0} transition time information:", zone.StandardName);
         TimeZoneInfo.AdjustmentRule[] adjustmentRules= zone.GetAdjustmentRules();
         
         // Indicate that time zone has no adjustment rules
         if (adjustmentRules.Length == 0)
         { 
            Console.WriteLine("   No adjustment rules defined.");
         }   
         else
         {
            // Iterate adjustment rules       
            foreach (TimeZoneInfo.AdjustmentRule adjustmentRule in adjustmentRules)
            {
               Console.WriteLine("   Adjustment rule from {0:d} to {1:d}:", 
                                 adjustmentRule.DateStart, 
                                 adjustmentRule.DateEnd);                                 
               
               // Get start of transition
               TimeZoneInfo.TransitionTime daylightStart = adjustmentRule.DaylightTransitionStart;
               // Display information on fixed date rule
               if (! daylightStart.IsFixedDateRule)
                  Console.WriteLine("      Begins at {0:t} on the {1} {2} of {3}.", 
                                 daylightStart.TimeOfDay, 
                                 ((WeekOfMonth)daylightStart.Week).ToString(),  
                                 daylightStart.DayOfWeek.ToString(), 
                                 dateInfo.GetMonthName(daylightStart.Month));
               // Display information on floating date rule 
               else
                  Console.WriteLine("      Begins at {0:t} on the {1} {2} of {3}.", 
                                    daylightStart.TimeOfDay, 
                                    ((WeekOfMonth)daylightStart.Week).ToString(),  
                                    daylightStart.DayOfWeek.ToString(), 
                                    dateInfo.GetMonthName(daylightStart.Month));
               
               // Get end of transition
               TimeZoneInfo.TransitionTime daylightEnd = adjustmentRule.DaylightTransitionEnd;
               // Display information on fixed date rule
               if (! daylightEnd.IsFixedDateRule)
                  Console.WriteLine("      Ends at {0:t} on the {1} {2} of {3}.", 
                                 daylightEnd.TimeOfDay, 
                                 ((WeekOfMonth)daylightEnd.Week).ToString(),  
                                 daylightEnd.DayOfWeek.ToString(), 
                                 dateInfo.GetMonthName(daylightEnd.Month));
               // Display information on floating date rule
               else
                  Console.WriteLine("      Ends at {0:t} on the {1} {2} of {3}.", 
                                    daylightStart.TimeOfDay, 
                                    ((WeekOfMonth)daylightStart.Week).ToString(),  
                                    daylightStart.DayOfWeek.ToString(), 
                                    dateInfo.GetMonthName(daylightStart.Month));
            }
         }   
      }   
   }   