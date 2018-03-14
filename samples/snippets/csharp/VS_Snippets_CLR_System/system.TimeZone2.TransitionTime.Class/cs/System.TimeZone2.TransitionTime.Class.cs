using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;

[assembly:CLSCompliant(true)]
public class TransitionTimeExamples
{
   public static void Main()
   {
      TransitionTimeExamples tte = new TransitionTimeExamples();
           
      Console.WriteLine("***CompareForEquality()");
      tte.CompareForEquality();
      Console.WriteLine();
      Console.WriteLine("***CompareTransitionTimesForEquality()");
      tte.CompareTransitionTimesForEquality();
      Console.WriteLine();
      Console.WriteLine("***CreateTransitionRules()");
      tte.CreateTransitionRules();
      Console.WriteLine();
      Console.WriteLine("***GetFixedTransitionTimes()");
      tte.GetFixedTransitionTimes();
      Console.WriteLine();
      Console.WriteLine("***GetFloatingTransitionTimes()");
      tte.GetFloatingTransitionTimes();
      Console.WriteLine();
      Console.WriteLine("***GetTransitionTimes(2006)"); 
      tte.GetTransitionTimes(2006);
      AdditionalExamples ae = new AdditionalExamples();
      Console.WriteLine();
      Console.WriteLine("***GetAllTransitionTimes()");
      ae.GetAllTransitionTimes();
   }   

   private void CompareForEquality()
   {
      // <Snippet1>
      TimeZoneInfo.TransitionTime tt1 = TimeZoneInfo.TransitionTime.CreateFixedDateRule(new DateTime(1, 1, 1, 02, 00, 00), 11, 03);
      TimeZoneInfo.TransitionTime tt2 = TimeZoneInfo.TransitionTime.CreateFixedDateRule(new DateTime(1, 1, 1, 02, 00, 00), 11, 03);
      TimeZoneInfo.TransitionTime tt3 = TimeZoneInfo.TransitionTime.CreateFloatingDateRule(new DateTime(1, 1, 1, 02, 00, 00), 10, 05, DayOfWeek.Sunday);
      TimeZoneInfo tz = TimeZoneInfo.Local;
      Console.WriteLine(tt1.Equals(tz));         // Returns False (overload with argument of type Object)
      Console.WriteLine(tt1.Equals(tt1));        // Returns True (an object always equals itself)
      Console.WriteLine(tt1.Equals(tt2));        // Returns True (identical property values)
      Console.WriteLine(tt1.Equals(tt3));        // Returns False (different property values)
      // </Snippet1>
     
   }

   private void CompareTransitionTimesForEquality()
   {
      // <Snippet7>
      TimeZoneInfo.TransitionTime tt1 = TimeZoneInfo.TransitionTime.CreateFixedDateRule(new DateTime(1, 1, 1, 02, 00, 00), 11, 03);
      TimeZoneInfo.TransitionTime tt2 = TimeZoneInfo.TransitionTime.CreateFixedDateRule(new DateTime(1, 1, 1, 02, 00, 00), 11, 03);
      TimeZoneInfo.TransitionTime tt3 = TimeZoneInfo.TransitionTime.CreateFloatingDateRule(new DateTime(1, 1, 1, 02, 00, 00), 10, 05, DayOfWeek.Sunday);
      Console.WriteLine(tt1.Equals(tt1));        // Returns True (an object always equals itself)
      Console.WriteLine(tt1.Equals(tt2));        // Returns True (identical property values)
      Console.WriteLine(tt1.Equals(tt3));        // Returns False (different property values)
      // </Snippet7>
     
   }

   private void CreateTransitionRules()
   {
      // <Snippet2>
      // Declare necessary TimeZoneInfo.AdjustmentRule objects for time zone
      TimeZoneInfo imaginaryTZ;
      TimeSpan delta = new TimeSpan(1, 0, 0);
      TimeZoneInfo.AdjustmentRule adjustment;
      List<TimeZoneInfo.AdjustmentRule> adjustmentList = new List<TimeZoneInfo.AdjustmentRule>();
      // Declare transition time variables to hold transition time information
      TimeZoneInfo.TransitionTime transitionRuleStart, transitionRuleEnd;
                            
      // Define a fictitious new time zone consisting of fixed and floating adjustment rules 
      // Define fixed rule (for 1900-1955)
      transitionRuleStart = TimeZoneInfo.TransitionTime.CreateFixedDateRule(new DateTime(1, 1, 1, 2, 0, 0), 3, 15);
      transitionRuleEnd = TimeZoneInfo.TransitionTime.CreateFixedDateRule(new DateTime(1, 1, 1, 3, 0, 0), 11, 15);
      adjustment = TimeZoneInfo.AdjustmentRule.CreateAdjustmentRule(new DateTime(1900, 1, 1), new DateTime(1955, 12, 31), 
                   delta, transitionRuleStart, transitionRuleEnd);
      adjustmentList.Add(adjustment);
      // Define floating rule (for 1956- )
      transitionRuleStart = TimeZoneInfo.TransitionTime.CreateFloatingDateRule(new DateTime(1, 1, 1, 2, 0, 0), 3, 5, DayOfWeek.Sunday);
      transitionRuleEnd = TimeZoneInfo.TransitionTime.CreateFloatingDateRule(new DateTime(1, 1, 1, 3, 0, 0), 10, 4, DayOfWeek.Sunday); 
      adjustment = TimeZoneInfo.AdjustmentRule.CreateAdjustmentRule(new DateTime(1956, 1, 1), DateTime.MaxValue.Date, delta, transitionRuleStart, transitionRuleEnd);
      adjustmentList.Add(adjustment); 

      // Create fictitious time zone   
      imaginaryTZ = TimeZoneInfo.CreateCustomTimeZone("Fictitious Standard Time", new TimeSpan(-9, 0, 0), 
                      "(GMT-09:00) Fictitious Time", "Fictitious Standard Time", 
                      "Fictitious Daylight Time", adjustmentList.ToArray());
      // </Snippet2> 
   }

   // <Snippet3>
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
   // </Snippet3>
   
   // <Snippet4>
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
   // </Snippet4>

   private void GetTransitionTimes(int year)
   {
      // Instantiate DateTimeFormatInfo object for month names
      DateTimeFormatInfo dateFormat = CultureInfo.CurrentCulture.DateTimeFormat;

      // Get and iterate time zones on local computer
      ReadOnlyCollection<TimeZoneInfo> timeZones = TimeZoneInfo.GetSystemTimeZones();
      foreach (TimeZoneInfo timeZone in timeZones)
      {
         Console.WriteLine("{0}:", timeZone.StandardName);
         TimeZoneInfo.AdjustmentRule[] adjustments = timeZone.GetAdjustmentRules();
         if (adjustments.Length == 0)
         {
            Console.WriteLine("   No adjustment rules.");
         }   
         else
         {   
            // Iterate adjustment rules for time zone
            foreach (TimeZoneInfo.AdjustmentRule adjustment in adjustments)
            {
               // Determine if this adjustment rule covers year desired
               if (adjustment.DateStart.Year <= year && adjustment.DateEnd.Year >= year)
               {
                  TimeZoneInfo.TransitionTime startTransition, endTransition;
                  // Determine if starting transition is fixed 
                  startTransition = adjustment.DaylightTransitionStart;
                  // Determine if starting transition is fixed and display transition info for year
                  if (startTransition.IsFixedDateRule)
                     Console.WriteLine("   Begins on {0} {1} at {2:t}", 
                                       dateFormat.GetMonthName(startTransition.Month), 
                                       startTransition.Day, 
                                       startTransition.TimeOfDay);
                  else
                     DisplayTransitionInfo(startTransition, year, "Begins on");

                  // Determine if ending transition is fixed and display transition info for year
                  endTransition = adjustment.DaylightTransitionEnd;
                  if (endTransition.IsFixedDateRule)
                     Console.WriteLine("   Ends on {0} {1} at {2:t}", 
                                       dateFormat.GetMonthName(endTransition.Month), 
                                       endTransition.Day, 
                                       endTransition.TimeOfDay);
                  else
                     DisplayTransitionInfo(endTransition, year, "Ends on");
                     
                  break;
               }
            }
         }   
      } 
   }
   
   private void DisplayTransitionInfo(TimeZoneInfo.TransitionTime transition, int year, string label)
   {
      // For non-fixed date rules, get local calendar
      Calendar cal = CultureInfo.CurrentCulture.Calendar;
      // Get first day of week for transition
      // For example, the 3rd week starts no earlier than the 15th of the month
      int startOfWeek = transition.Week * 7 - 6;
      // What day of the week does the month start on?
      int firstDayOfWeek = (int) cal.GetDayOfWeek(new DateTime(year, transition.Month, startOfWeek)); 
      // Determine how much start date has to be adjusted
      int transitionDay; 
      int changeDayOfWeek = (int) transition.DayOfWeek;

      if (firstDayOfWeek <= changeDayOfWeek)
         transitionDay = startOfWeek + (changeDayOfWeek - firstDayOfWeek);
      else     
         transitionDay = startOfWeek + (7 - firstDayOfWeek + changeDayOfWeek);

      // Adjust for months with no fifth week
      if (transitionDay > cal.GetDaysInMonth(year, transition.Month))  
         transitionDay -= 7;

      Console.WriteLine("   {0} {1}, {2:d} at {3:t}", 
                        label, 
                        transition.DayOfWeek, 
                        new DateTime(year, transition.Month, transitionDay), 
                        transition.TimeOfDay);   
   }   
}

public class AdditionalExamples
{
   // <Snippet6>
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
   // </Snippet6>
}
