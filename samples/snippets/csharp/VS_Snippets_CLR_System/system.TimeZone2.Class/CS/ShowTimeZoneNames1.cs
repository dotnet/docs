// <Snippet2>
using System;

public class Example
{
   public static void Main()
   {
      TimeZoneInfo localZone = TimeZoneInfo.Local;
      Console.WriteLine("Local Time Zone ID: {0}", localZone.Id);
      Console.WriteLine("   Display Name is: {0}.", localZone.DisplayName);
      Console.WriteLine("   Standard name is: {0}.", localZone.StandardName);
      Console.WriteLine("   Daylight saving name is: {0}.", localZone.DaylightName); 
   }
}
// The example displays output like the following:
//     Local Time Zone ID: Pacific Standard Time
//        Display Name is: (UTC-08:00) Pacific Time (US & Canada).
//        Standard name is: Pacific Standard Time.
//        Daylight saving name is: Pacific Daylight Time.
// </Snippet2>

