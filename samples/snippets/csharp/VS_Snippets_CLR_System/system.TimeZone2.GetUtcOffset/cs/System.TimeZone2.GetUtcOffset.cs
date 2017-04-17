// <Snippet1>
using System;

[assembly:CLSCompliant(true)]
namespace TimeZoneInfoCode
{
   public class TimeOffsets
   {
      public static void Main()
      {
         TimeOffsets timeoff = new TimeOffsets();
         TimeZoneInfo cst = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
   
         timeoff.ShowOffset(new DateTime(2006, 6, 12, 11, 0, 0), TimeZoneInfo.Local);
         timeoff.ShowOffset(new DateTime(2007, 11, 4, 1, 0, 0), TimeZoneInfo.Local);
         timeoff.ShowOffset(new DateTime(2006, 12, 10, 15, 0, 0), TimeZoneInfo.Local);
         timeoff.ShowOffset(new DateTime(2007, 3, 11, 2, 30, 0), TimeZoneInfo.Local);
         timeoff.ShowOffset(DateTime.UtcNow, TimeZoneInfo.Local);
         timeoff.ShowOffset(new DateTime(2006, 6, 12, 11, 0, 0), TimeZoneInfo.Utc);
         timeoff.ShowOffset(new DateTime(2007, 11, 4, 1, 0, 0), TimeZoneInfo.Utc);
         timeoff.ShowOffset(new DateTime(2006, 12, 10, 3, 0, 0), TimeZoneInfo.Utc);
         timeoff.ShowOffset(new DateTime(2007, 3, 11, 2, 30, 0), TimeZoneInfo.Utc);
         timeoff.ShowOffset(DateTime.Now, TimeZoneInfo.Utc);
         timeoff.ShowOffset(new DateTime(2006, 6, 12, 11, 0, 0), cst);
         timeoff.ShowOffset(new DateTime(2007, 11, 4, 1, 0, 0), cst);
         timeoff.ShowOffset(new DateTime(2006, 12, 10, 15, 0, 0), cst);
         timeoff.ShowOffset(new DateTime(2007, 3, 11, 2, 30, 0, 0), cst);
         timeoff.ShowOffset(new DateTime(2007, 11, 14, 00, 00, 00, DateTimeKind.Local), cst);
      }
      
      private void ShowOffset(DateTime time, TimeZoneInfo timeZone)
      {
         DateTime convertedTime = time;  
         TimeSpan offset;
         
         if (time.Kind == DateTimeKind.Local && ! timeZone.Equals(TimeZoneInfo.Local)) 
            convertedTime = TimeZoneInfo.ConvertTime(time, TimeZoneInfo.Local, timeZone);
         else if (time.Kind == DateTimeKind.Utc && ! timeZone.Equals(TimeZoneInfo.Utc)) 
            convertedTime = TimeZoneInfo.ConvertTime(time, TimeZoneInfo.Utc, timeZone);         
   
         offset = timeZone.GetUtcOffset(time);
         if (time == convertedTime)
         {
            Console.WriteLine("{0} {1} ", time, 
                              timeZone.IsDaylightSavingTime(time) ? timeZone.DaylightName : timeZone.StandardName);
            Console.WriteLine("   It differs from UTC by {0} hours, {1} minutes.", 
                               offset.Hours, 
                               offset.Minutes);
         }
         else
         {
            Console.WriteLine("{0} {1} ", time, 
                              time.Kind == DateTimeKind.Utc ? "UTC" :  TimeZoneInfo.Local.Id);       
            Console.WriteLine("   converts to {0} {1}.", 
                              convertedTime, 
                              timeZone.Id);
            Console.WriteLine("   It differs from UTC by {0} hours, {1} minutes.", 
                              offset.Hours, offset.Minutes);  
         }
         Console.WriteLine();                                             
      }
   }
}
// The example produces the following output:
//
//       6/12/2006 11:00:00 AM Pacific Daylight Time 
//          It differs from UTC by -7 hours, 0 minutes.
//       
//       11/4/2007 1:00:00 AM Pacific Standard Time 
//          It differs from UTC by -8 hours, 0 minutes.
//       
//       12/10/2006 3:00:00 PM Pacific Standard Time 
//          It differs from UTC by -8 hours, 0 minutes.
//       
//       3/11/2007 2:30:00 AM Pacific Standard Time 
//          It differs from UTC by -8 hours, 0 minutes.
//       
//       2/2/2007 8:35:46 PM UTC 
//          converts to 2/2/2007 12:35:46 PM Pacific Standard Time.
//          It differs from UTC by -8 hours, 0 minutes.
//       
//       6/12/2006 11:00:00 AM UTC 
//          It differs from UTC by 0 hours, 0 minutes.
//       
//       11/4/2007 1:00:00 AM UTC 
//          It differs from UTC by 0 hours, 0 minutes.
//       
//       12/10/2006 3:00:00 AM UTC 
//          It differs from UTC by 0 hours, 0 minutes.
//       
//       3/11/2007 2:30:00 AM UTC 
//          It differs from UTC by 0 hours, 0 minutes.
//       
//       2/2/2007 12:35:46 PM Pacific Standard Time 
//          converts to 2/2/2007 8:35:46 PM UTC.
//          It differs from UTC by 0 hours, 0 minutes.
//       
//       6/12/2006 11:00:00 AM Central Daylight Time 
//          It differs from UTC by -5 hours, 0 minutes.
//       
//       11/4/2007 1:00:00 AM Central Standard Time 
//          It differs from UTC by -6 hours, 0 minutes.
//       
//       12/10/2006 3:00:00 PM Central Standard Time 
//          It differs from UTC by -6 hours, 0 minutes.
//       
//       3/11/2007 2:30:00 AM Central Standard Time 
//          It differs from UTC by -6 hours, 0 minutes.
//       
//       11/14/2007 12:00:00 AM Pacific Standard Time 
//          converts to 11/14/2007 2:00:00 AM Central Standard Time.
//          It differs from UTC by -6 hours, 0 minutes.
// </Snippet1>
