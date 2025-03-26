// <Snippet1>
using System;

public struct StoreInfo
{
   public String store;
   public TimeZoneInfo tz;
   public TimeSpan open;
   public TimeSpan close;

   public bool IsOpenNow()
   {
      return IsOpenAt(DateTime.Now.TimeOfDay);
   }

   public bool IsOpenAt(TimeSpan time)
   {
      TimeZoneInfo local = TimeZoneInfo.Local;
      TimeSpan offset = TimeZoneInfo.Local.BaseUtcOffset;

      // Is the store in the same time zone?
      if (tz.Equals(local)) {
         return time >= open & time <= close;
      }
      else {
         TimeSpan delta = TimeSpan.Zero;
         TimeSpan storeDelta = TimeSpan.Zero;

         // Is it daylight saving time in either time zone?
         if (local.IsDaylightSavingTime(DateTime.Now.Date + time))
            delta = local.GetAdjustmentRules()[local.GetAdjustmentRules().Length - 1].DaylightDelta;

         if (tz.IsDaylightSavingTime(TimeZoneInfo.ConvertTime(DateTime.Now.Date + time, local, tz)))
            storeDelta = tz.GetAdjustmentRules()[tz.GetAdjustmentRules().Length - 1].DaylightDelta;

         TimeSpan comparisonTime = time + (offset - tz.BaseUtcOffset).Negate() + (delta - storeDelta).Negate();
         return comparisonTime >= open && comparisonTime <= close;
      }
   }
}
// </Snippet1>

// <Snippet2>
public class Example
{
   public static void Main()
   {
      // Instantiate a StoreInfo object.
      var store103 = new StoreInfo();
      store103.store = "Store #103";
      store103.tz = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
      // Store opens at 8:00.
      store103.open = new TimeSpan(8, 0, 0);
      // Store closes at 9:30.
      store103.close = new TimeSpan(21, 30, 0);

      Console.WriteLine($"Store is open now at {DateTime.Now.TimeOfDay}: {store103.IsOpenNow()}");
      TimeSpan[] times = { new TimeSpan(8, 0, 0), new TimeSpan(21, 0, 0),
                           new TimeSpan(4, 59, 0), new TimeSpan(18, 31, 0) };
      foreach (var time in times)
         Console.WriteLine($"Store is open at {time}: {store103.IsOpenAt(time)}");
   }
}
// The example displays the following output:
//       Store is open now at 15:29:01.6129911: True
//       Store is open at 08:00:00: True
//       Store is open at 21:00:00: True
//       Store is open at 04:59:00: False
//       Store is open at 18:31:00: True
// </Snippet2>
