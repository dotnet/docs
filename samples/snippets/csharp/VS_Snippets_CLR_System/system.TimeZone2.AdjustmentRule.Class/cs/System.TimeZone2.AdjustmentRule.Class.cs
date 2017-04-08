using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;

[assembly:CLSCompliant(true)]
namespace TimeZoneInfoCode
{
public class AdjustmentRuleTest
{
   private static void Main()
   {
      CreateCustomTimeZone();
      CompareRulesForEquality();
      ShowStartAndEndDates();
   }

   private static void CreateCustomTimeZone()
   {
      // <Snippet1>
      // Create alternate Central Standard Time to include historical time zone information
      //
      // Declare necessary TimeZoneInfo.AdjustmentRule objects for time zone
      TimeSpan delta = new TimeSpan(1, 0, 0);
      TimeZoneInfo.AdjustmentRule adjustment;
      List<TimeZoneInfo.AdjustmentRule> adjustmentList = new List<TimeZoneInfo.AdjustmentRule>();
      // Declare transition time variables to hold transition time information
      TimeZoneInfo.TransitionTime transitionRuleStart, transitionRuleEnd;

      // Define end rule (for 1976-2006)
      transitionRuleEnd = TimeZoneInfo.TransitionTime.CreateFloatingDateRule(new DateTime(1, 1, 1, 2, 0, 0), 10, 5, DayOfWeek.Sunday);
      // Define rule (1976-1986)
      transitionRuleStart = TimeZoneInfo.TransitionTime.CreateFloatingDateRule(new DateTime(1, 1, 1, 2, 0, 0), 04, 05, DayOfWeek.Sunday);
      adjustment = TimeZoneInfo.AdjustmentRule.CreateAdjustmentRule(new DateTime(1976, 1, 1), new DateTime(1986, 12, 31), delta, transitionRuleStart, transitionRuleEnd);
      adjustmentList.Add(adjustment);
      // Define rule (1987-2006)  
      transitionRuleStart = TimeZoneInfo.TransitionTime.CreateFloatingDateRule(new DateTime(1, 1, 1, 2, 0, 0), 04, 01, DayOfWeek.Sunday);
      adjustment = TimeZoneInfo.AdjustmentRule.CreateAdjustmentRule(new DateTime(1987, 1, 1), new DateTime(2006, 12, 31), delta, transitionRuleStart, transitionRuleEnd);
      adjustmentList.Add(adjustment);
      // Define rule (2007- )  
      transitionRuleStart = TimeZoneInfo.TransitionTime.CreateFloatingDateRule(new DateTime(1, 1, 1, 2, 0, 0), 03, 02, DayOfWeek.Sunday);
      transitionRuleEnd = TimeZoneInfo.TransitionTime.CreateFloatingDateRule(new DateTime(1, 1, 1, 2, 0, 0), 11, 01, DayOfWeek.Sunday);
      adjustment = TimeZoneInfo.AdjustmentRule.CreateAdjustmentRule(new DateTime(2007, 01, 01), DateTime.MaxValue.Date, delta, transitionRuleStart, transitionRuleEnd);
      adjustmentList.Add(adjustment);
                    
      // Create custom U.S. Central Standard Time zone         
      TimeZoneInfo.CreateCustomTimeZone("Central Standard Time", new TimeSpan(-6, 0, 0), 
                      "(GMT-06:00) Central Time (US Only)", "Central Standard Time", 
                      "Central Daylight Time", adjustmentList.ToArray());       
      // </Snippet1>   
   }

   private static void CompareRulesForEquality()
   {
      // <Snippet2>
      string timeZoneName = "";
      // Get CST, Canadian CST, and Mexican CST adjustment rules
      TimeZoneInfo.AdjustmentRule[] usCstAdjustments = null;
      TimeZoneInfo.AdjustmentRule[] canCstAdjustments = null;
      TimeZoneInfo.AdjustmentRule[] mexCstAdjustments = null;
      try
      {
         timeZoneName = "Central Standard Time";
         usCstAdjustments = TimeZoneInfo.FindSystemTimeZoneById(timeZoneName).GetAdjustmentRules();
      }
      catch (TimeZoneNotFoundException)
      {
         Console.WriteLine("The {0} time zone is not defined in the registry.", 
                           timeZoneName);
      }                           
      catch (InvalidTimeZoneException)
      {
         Console.WriteLine("Data for the {0} time zone is invalid.", 
                           timeZoneName);
      }
      try
      {
         timeZoneName = "Canada Central Standard Time";
         canCstAdjustments = TimeZoneInfo.FindSystemTimeZoneById(timeZoneName).GetAdjustmentRules();
      }
      catch (TimeZoneNotFoundException)
      {
         Console.WriteLine("The {0} time zone is not defined in the registry.", 
                           timeZoneName);
      }                           
      catch (InvalidTimeZoneException)
      {
         Console.WriteLine("Data for the {0} time zone is invalid.", 
                           timeZoneName);
      }
      try
      {
         timeZoneName = "Central Standard Time (Mexico)";
         mexCstAdjustments = TimeZoneInfo.FindSystemTimeZoneById(timeZoneName).GetAdjustmentRules();
      }   
      catch (TimeZoneNotFoundException)
      {
         Console.WriteLine("The {0} time zone is not defined in the registry.", 
                           timeZoneName);
      }                           
      catch (InvalidTimeZoneException)
      {
         Console.WriteLine("Data for the {0} time zone is invalid.", 
                           timeZoneName);
      }
      // Determine if CST and other time zones have the same rules
      foreach(TimeZoneInfo.AdjustmentRule rule in usCstAdjustments)
      {
         Console.WriteLine("Comparing Central Standard Time rule for {0:d} to {1:d} with:", 
                           rule.DateStart, rule.DateEnd);
         // Compare with Canada Central Standard Time
         if (canCstAdjustments.Length == 0)
         {
            Console.WriteLine("   Canada Central Standard Time has no adjustment rules.");
         }   
         else
         {
            foreach (TimeZoneInfo.AdjustmentRule canRule in canCstAdjustments)
            {
               Console.WriteLine("   Canadian CST for {0:d} to {1:d}: {2}", 
                                 canRule.DateStart, canRule.DateEnd, 
                                 rule.Equals(canRule) ? "Equal" : "Not Equal");
            }              
         }          
   
         // Compare with Mexico Central Standard Time
         if (mexCstAdjustments.Length == 0)
         {
            Console.WriteLine("   Mexican Central Standard Time has no adjustment rules.");
         }
         else
         {
            foreach (TimeZoneInfo.AdjustmentRule mexRule in mexCstAdjustments)
            {
               Console.WriteLine("   Mexican CST for {0:d} to {1:d}: {2}", 
                                 mexRule.DateStart, mexRule.DateEnd, 
                                 rule.Equals(mexRule) ? "Equal" : "Not Equal");
            }              
         }
      }   
      // This code displays the following output to the console:
      // 
      // Comparing Central Standard Time rule for 1/1/0001 to 12/31/9999 with:
      //    Canada Central Standard Time has no adjustment rules.
      //    Mexican CST for 1/1/0001 to 12/31/9999: Equal
      // </Snippet2>
   }

   // <Snippet3>   
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
   // </Snippet3>
}
} // end namespace
