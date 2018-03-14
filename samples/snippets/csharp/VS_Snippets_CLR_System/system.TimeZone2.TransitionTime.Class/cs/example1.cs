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
      tte.GetTransitionTimes(2007);
   }

   // <Snippet5>
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
         int startYear = year;
         int endYear = startYear;

         if (adjustments.Length == 0)
         {
            Console.WriteLine("   No adjustment rules.");
         }   
         else
         {   
            TimeZoneInfo.AdjustmentRule adjustment = GetAdjustment(adjustments, year);
            if (adjustment == null)
            {
               Console.WriteLine("   No adjustment rules available for this year.");
               continue;
            }
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
               DisplayTransitionInfo(startTransition, startYear, "Begins on");

            // Determine if ending transition is fixed and display transition info for year
            endTransition = adjustment.DaylightTransitionEnd;
            
            // Does the transition back occur in an earlier month (i.e., 
            // the following year) than the transition to DST? If so, make
            // sure we have the right adjustment rule.
            if (endTransition.Month < startTransition.Month)
            {
               endTransition = GetAdjustment(adjustments, year + 1).DaylightTransitionEnd;
               endYear++;
            }
         
            if (endTransition.IsFixedDateRule)
               Console.WriteLine("   Ends on {0} {1} at {2:t}", 
                                 dateFormat.GetMonthName(endTransition.Month), 
                                 endTransition.Day, 
                                 endTransition.TimeOfDay);
            else
               DisplayTransitionInfo(endTransition, endYear, "Ends on");
         }      
      }   
   } 


   private static TimeZoneInfo.AdjustmentRule GetAdjustment(TimeZoneInfo.AdjustmentRule[] adjustments,
                                                     int year)
   {                                                  
      // Iterate adjustment rules for time zone
      foreach (TimeZoneInfo.AdjustmentRule adjustment in adjustments)
      {
         // Determine if this adjustment rule covers year desired
         if (adjustment.DateStart.Year <= year && adjustment.DateEnd.Year >= year)
            return adjustment;
      }   
      return null;
   }
   
   private void DisplayTransitionInfo(TimeZoneInfo.TransitionTime transition, int year, string label)
   {
      // For non-fixed date rules, get local calendar
      Calendar cal = CultureInfo.CurrentCulture.Calendar;
      // Get first day of week for transition
      // For example, the 3rd week starts no earlier than the 15th of the month
      int startOfWeek = transition.Week * 7 - 6;
      // What day of the week does the month start on?
      int firstDayOfWeek = (int) cal.GetDayOfWeek(new DateTime(year, transition.Month, 1)); 
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
   // </Snippet5>
}

