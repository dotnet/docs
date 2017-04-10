// <Snippet2>
using System;

public class Example
{
   public static void Main()
   {
      // Get time in local time zone 
      DateTime thisTime = DateTime.Now;
      Console.WriteLine("Time in {0} zone: {1}", TimeZoneInfo.Local.IsDaylightSavingTime(thisTime) ?
                        TimeZoneInfo.Local.DaylightName : TimeZoneInfo.Local.StandardName, thisTime);
      Console.WriteLine("   UTC Time: {0}", TimeZoneInfo.ConvertTimeToUtc(thisTime, TimeZoneInfo.Local));
      // Get Tokyo Standard Time zone
      TimeZoneInfo tst = TimeZoneInfo.FindSystemTimeZoneById("Tokyo Standard Time");
      DateTime tstTime = TimeZoneInfo.ConvertTime(thisTime, TimeZoneInfo.Local, tst);      
      Console.WriteLine("Time in {0} zone: {1}", tst.IsDaylightSavingTime(tstTime) ?
                        tst.DaylightName : tst.StandardName, tstTime);
      Console.WriteLine("   UTC Time: {0}", TimeZoneInfo.ConvertTimeToUtc(tstTime, tst));
   }
}
// The example displays output like the following when run on a system in the
// U.S. Pacific Standard Time zone:
//       Time in Pacific Standard Time zone: 12/6/2013 10:57:51 AM
//          UTC Time: 12/6/2013 6:57:51 PM
//       Time in Tokyo Standard Time zone: 12/7/2013 3:57:51 AM
//          UTC Time: 12/6/2013 6:57:51 PM
// </Snippet2>
