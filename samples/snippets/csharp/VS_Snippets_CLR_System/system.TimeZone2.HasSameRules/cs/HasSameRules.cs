using System;
using System.Collections.ObjectModel;

[assembly:CLSCompliant(true)]

namespace TimeZoneInfoCode
{
public sealed class TestSameRules
{
   private TestSameRules() {}   

   public static void Main()
   {
      // <Snippet1>
      ReadOnlyCollection<TimeZoneInfo> timeZones = TimeZoneInfo.GetSystemTimeZones();
      TimeZoneInfo[] timeZoneArray = new TimeZoneInfo[timeZones.Count];
      timeZones.CopyTo(timeZoneArray, 0);
      // Iterate array from top to bottom
      for (int ctr = timeZoneArray.GetUpperBound(0); ctr >= 1; ctr--)
      {
         // Get next item from top
         TimeZoneInfo thisTimeZone = timeZoneArray[ctr];
         for (int compareCtr = 0; compareCtr <= ctr - 1; compareCtr++)
         {
            // Determine if time zones have the same rules
            if (thisTimeZone.HasSameRules(timeZoneArray[compareCtr]))
            {
               Console.WriteLine("{0} has the same rules as {1}", 
                                 thisTimeZone.StandardName,
                                 timeZoneArray[compareCtr].StandardName);
            }
         }
      }
      // </Snippet1>
   }
}
} // End namespace
