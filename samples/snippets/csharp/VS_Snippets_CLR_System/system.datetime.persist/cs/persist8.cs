// <Snippet8>
using System;
using DateTimeExtensions;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

public class Example
{
   private const string filename = @".\Schedule.bin";

   public static void Main()
   {
      FileStream fs;
      if (File.Exists(filename))
         fs = new FileStream(filename, FileMode.Open);
      else {
         Console.WriteLine("Unable to find file to deserialize.");
         return;
      }

      BinaryFormatter formatter = new BinaryFormatter();
      DateWithTimeZone[] dates;
      try {
         dates = (DateWithTimeZone[]) formatter.Deserialize(fs);
         // Display dates.
         foreach (var date in dates) {
            TimeZoneInfo tz = date.TimeZone;
            Console.WriteLine("{0} {1}", date.DateTime, 
                              tz.IsDaylightSavingTime(date.DateTime) ? 
                              tz.DaylightName : tz.StandardName);      
         }
      }
      catch (SerializationException e) {
         Console.WriteLine("Deserialization failed. Reason: {0}", e.Message);
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
// </Snippet8>

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