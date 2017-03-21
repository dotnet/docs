   private enum WeekOfMonth 
   {
      First = 1,
      Second = 2,
      Third = 3,
      Fourth = 4,
      Last = 5,
   }

   private static void ShowStartAndEndDates()
   {
      // Get all time zones from system
      ReadOnlyCollection<TimeZoneInfo> timeZones = TimeZoneInfo.GetSystemTimeZones();
      string[] monthNames = CultureInfo.CurrentCulture.DateTimeFormat.MonthNames;
      // Get each time zone
      foreach (TimeZoneInfo timeZone in timeZones)
      {
         TimeZoneInfo.AdjustmentRule[] adjustments = timeZone.GetAdjustmentRules();
         // Display message for time zones with no adjustments
         if (adjustments.Length == 0)
         {
            Console.WriteLine("{0} has no adjustment rules", timeZone.StandardName);
         }   
         else
         {
            // Handle time zones with 1 or 2+ adjustments differently
            bool showCount = false;
            int ctr = 0;
            string spacer = "";
            
            Console.WriteLine("{0} Adjustment rules", timeZone.StandardName);
            if (adjustments.Length > 1)
            {
               showCount = true;
               spacer = "   ";
            }   
            // Iterate adjustment rules
            foreach (TimeZoneInfo.AdjustmentRule adjustment in adjustments)
            {
               if (showCount)
               { 
                  Console.WriteLine("   Adjustment rule #{0}", ctr+1);
                  ctr++;
               }
               // Display general adjustment information
               Console.WriteLine("{0}   Start Date: {1:D}", spacer, adjustment.DateStart);
               Console.WriteLine("{0}   End Date: {1:D}", spacer, adjustment.DateEnd);
               Console.WriteLine("{0}   Time Change: {1}:{2:00} hours", spacer, 
                                 adjustment.DaylightDelta.Hours, adjustment.DaylightDelta.Minutes);
               // Get transition start information
               TimeZoneInfo.TransitionTime transitionStart = adjustment.DaylightTransitionStart;
               Console.Write("{0}   Annual Start: ", spacer);
               if (transitionStart.IsFixedDateRule)
               {
                  Console.WriteLine("On {0} {1} at {2:t}", 
                                    monthNames[transitionStart.Month - 1], 
                                    transitionStart.Day, 
                                    transitionStart.TimeOfDay);
               }
               else
               {
                  Console.WriteLine("The {0} {1} of {2} at {3:t}", 
                                    ((WeekOfMonth)transitionStart.Week).ToString(), 
                                    transitionStart.DayOfWeek.ToString(), 
                                    monthNames[transitionStart.Month - 1], 
                                    transitionStart.TimeOfDay);
               }
               // Get transition end information
               TimeZoneInfo.TransitionTime transitionEnd = adjustment.DaylightTransitionEnd;
               Console.Write("{0}   Annual End: ", spacer);
               if (transitionEnd.IsFixedDateRule)
               {
                  Console.WriteLine("On {0} {1} at {2:t}", 
                                    monthNames[transitionEnd.Month - 1], 
                                    transitionEnd.Day, 
                                    transitionEnd.TimeOfDay);
               }
               else
               {
                  Console.WriteLine("The {0} {1} of {2} at {3:t}", 
                                    ((WeekOfMonth)transitionEnd.Week).ToString(), 
                                    transitionEnd.DayOfWeek.ToString(), 
                                    monthNames[transitionEnd.Month - 1], 
                                    transitionEnd.TimeOfDay);
               }
            }
         }   
         Console.WriteLine();
      } 
   }