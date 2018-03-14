
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

[assembly:CLSCompliant(true)]

namespace TimeZoneExamples
{
   public class TZClass
   {
      public static void Main()
      {
         TZClass tz = new TZClass();
         if(MessageBox.Show("Display time zone offset?", "Offset", MessageBoxButtons.YesNo) == DialogResult.Yes)
            tz.ShowTimezoneOffset();

         if(MessageBox.Show("Display time zone names?", "Names", MessageBoxButtons.YesNo) == DialogResult.Yes)
            tz.ShowTimeZoneNames();

         if(MessageBox.Show("Display universal time zone names?", "Universal Time Zone Names", MessageBoxButtons.YesNo) == DialogResult.Yes)
            tz.ShowUniversalTimeZoneNames(); 

         if(MessageBox.Show("Show time zones without daylight savings time", "Zones Supporting DST", MessageBoxButtons.YesNo) == DialogResult.Yes)
            tz.ShowNoDSTZones();

         if(MessageBox.Show("List all time zone IDs?", "IDs", MessageBoxButtons.YesNo) == DialogResult.Yes)
            tz.ShowTimeZoneIDs();  
             
         if(MessageBox.Show("Test Time Zones for Equality?", "TimeZoneInfo.Equals", MessageBoxButtons.YesNo) == DialogResult.Yes)
            tz.TestForEquality();  
             
         if(MessageBox.Show("Show ambiguous times in Pacific Time Zone for 2007?", "TimeZoneInfo.IsAmbiguousTime", MessageBoxButtons.YesNo) == DialogResult.Yes)
            tz.ShowAmbiguousTimes();
            
         if(MessageBox.Show("Show invalid times in Pacific Time Zone for 2007?", "TimeZoneInfo.IsInvalidTime", MessageBoxButtons.YesNo) == DialogResult.Yes)
            tz.ShowInvalidTimes();
      }

      private void ShowTimezoneOffset()
      {
         // <Snippet1>
         TimeZoneInfo localZone = TimeZoneInfo.Local;
         Console.WriteLine("The {0} time zone is {1}:{2} {3} than Coordinated Universal Time.",  
                           localZone.DisplayName, 
                           Math.Abs(localZone.BaseUtcOffset.Hours), 
                           Math.Abs(localZone.BaseUtcOffset.Minutes), 
                           (localZone.BaseUtcOffset >= TimeSpan.Zero) ? "later" : "earlier");
         // </Snippet1>                  
      }
   
      private void ShowTimeZoneNames()
      {
         TimeZoneInfo localZone = TimeZoneInfo.Local;
         Console.WriteLine("Local Time Zone ID: {0}", localZone.Id);
         Console.WriteLine("   Display Name is: {0}.", localZone.DisplayName);
         Console.WriteLine("   Standard name is: {0}.", localZone.StandardName);
         Console.WriteLine("   Daylight saving name is: {0}.", localZone.DaylightName); 
      }
   
      private void ShowUniversalTimeZoneNames()
      {
         // <Snippet3>
         TimeZoneInfo universalZone = TimeZoneInfo.Utc;
         Console.WriteLine("The universal time zone is {0}.", universalZone.DisplayName);
         Console.WriteLine("Its standard name is {0}.", universalZone.StandardName);
         Console.WriteLine("Its daylight savings name is {0}.", universalZone.DaylightName); 
         // </Snippet3>
      }
      
      private void ShowNoDSTZones()
      {
         // <Snippet4>
         ReadOnlyCollection<TimeZoneInfo> zones = TimeZoneInfo.GetSystemTimeZones();
         foreach(TimeZoneInfo zone in zones)
         {
            if (! zone.SupportsDaylightSavingTime)
               Console.WriteLine(zone.DisplayName);
         }
         // </Snippet4> 
      }

      private void ShowTimeZoneIDs()
      {
         // <Snippet5>
         ReadOnlyCollection<TimeZoneInfo> zones = TimeZoneInfo.GetSystemTimeZones();
         Console.WriteLine("The local system has the following {0} time zones", zones.Count);
         foreach (TimeZoneInfo zone in zones)
            Console.WriteLine(zone.Id);
         // </Snippet5>
      }
   
      private void TestForEquality()
      {
         // <Snippet7> 
         TimeZoneInfo thisTimeZone, zone1, zone2;
      
         thisTimeZone = TimeZoneInfo.Local;
         zone1 = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
         zone2 = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
         Console.WriteLine(thisTimeZone.Equals(zone1));
         Console.WriteLine(thisTimeZone.Equals(zone2));
         // </Snippet7>
      }
      
      private void ShowAmbiguousTimes()
      {
         // <Snippet8>
         // Specify DateTimeKind in Date constructor
         DateTime baseTime = new DateTime(2007, 11, 4, 0, 59, 00, DateTimeKind.Unspecified);
         DateTime newTime;
      
         // Get Pacific Standard Time zone
         TimeZoneInfo pstZone = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");

         // List possible ambiguous times for 63-minute interval, from 12:59 AM to 2:01 AM 
         for (int ctr = 0; ctr < 63; ctr++)
         {
            // Because of assignment, newTime.Kind is also DateTimeKind.Unspecified
            newTime = baseTime.AddMinutes(ctr);   
            Console.WriteLine("{0} is ambiguous: {1}", newTime, pstZone.IsAmbiguousTime(newTime));
         }
         // </Snippet8>      
      }
      
      private void ShowInvalidTimes()
      {
         // <Snippet9>
         // Specify DateTimeKind in Date constructor
         DateTime baseTime = new DateTime(2007, 3, 11, 1, 59, 0, DateTimeKind.Unspecified);
         DateTime newTime;
         
         // Get Pacific Standard Time zone
         TimeZoneInfo pstZone = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
         
         // List possible invalid times for a 63-minute interval, from 1:59 AM to 3:01 AM
         for (int ctr = 0; ctr < 63; ctr++)
         {
            // Because of assignment, newTime.Kind is also DateTimeKind.Unspecified
            newTime = baseTime.AddMinutes(ctr);
            Console.WriteLine("{0} is invalid: {1}", newTime, pstZone.IsInvalidTime(newTime));
         }
         // </Snippet9>

      }
   }
}
