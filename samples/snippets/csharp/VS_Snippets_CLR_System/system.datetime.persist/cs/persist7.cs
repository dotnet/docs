// <Snippet7>
using System;
using DateTimeExtensions;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

public class Example
{
   public static void Main()
   {
      DateWithTimeZone[] dates= { new DateWithTimeZone(new DateTime(2014, 8, 9, 19, 30, 0),  
                                      TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time")),
                                  new DateWithTimeZone(new DateTime(2014, 8, 15, 19, 0, 0), 
                                      TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time")),  
                                  new DateWithTimeZone(new DateTime(2014, 8, 22, 19, 30, 0),  
                                      TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time")),  
                                  new DateWithTimeZone(new DateTime(2014, 8, 28, 19, 0, 0), 
                                      TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time")) };
      FileStream fs = new FileStream(@".\Schedule.bin", FileMode.Create);
      BinaryFormatter formatter = new BinaryFormatter();
      try {
         formatter.Serialize(fs, dates);
         // Display dates.
         foreach (var date in dates) {
            TimeZoneInfo tz = date.TimeZone;
            Console.WriteLine("{0} {1}", date.DateTime, 
                              tz.IsDaylightSavingTime(date.DateTime) ? 
                              tz.DaylightName : tz.StandardName);      
         }
      }
      catch (SerializationException e) {
         Console.WriteLine("Serialization failed. Reason: {0}", e.Message);
      }   
      finally {
         if (fs != null) fs.Close();
      }
   }
}
// The example displays the following output:
//       8/9/2014 7:30:00 PM Eastern Daylight Time
//       8/15/2014 7:00:00 PM Pacific Daylight Time
//       8/22/2014 7:30:00 PM Eastern Daylight Time
//       8/28/2014 7:00:00 PM Eastern Daylight Time
// </Snippet7>

namespace DateTimeExtensions
{
   [Serializable] public struct DateWithTimeZone
   {
      private TimeZoneInfo tz;
      private DateTime dt;
      
      public DateWithTimeZone(DateTime dateValue, TimeZoneInfo timeZone)
      {
         dt = dateValue;
         if (timeZone == null)
            tz = TimeZoneInfo.Local;
         else
            tz = timeZone;
      }   
      
      public TimeZoneInfo TimeZone 
      { get { return (tz); }
        set { tz = value; } }
      
      public DateTime DateTime 
      { get { return (dt); }
        set { dt = value; } }
   }
}