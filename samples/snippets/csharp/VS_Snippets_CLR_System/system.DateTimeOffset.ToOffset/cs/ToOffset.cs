// <Snippet1>
using System;

public class DateTimeOffsetConversion
{
   private static DateTimeOffset sourceTime; 
   
   public static void Main()
   {
      DateTimeOffset targetTime;
      sourceTime = new DateTimeOffset(2007, 9, 1, 9, 30, 0, 
                                      new TimeSpan(-5, 0, 0));
                                            
      // Convert to same time (return sourceTime unchanged)
      targetTime = sourceTime.ToOffset(new TimeSpan(-5, 0, 0));
      ShowDateAndTimeInfo(targetTime);
      
      // Convert to UTC (0 offset)
      targetTime = sourceTime.ToOffset(TimeSpan.Zero);
      ShowDateAndTimeInfo(targetTime);
      
      // Convert to 8 hours behind UTC
      targetTime = sourceTime.ToOffset(new TimeSpan(-8, 0, 0));
      ShowDateAndTimeInfo(targetTime);
      
      // Convert to 3 hours ahead of UTC
      targetTime = sourceTime.ToOffset(new TimeSpan(3, 0, 0));
      ShowDateAndTimeInfo(targetTime);
   }

   private static void ShowDateAndTimeInfo(DateTimeOffset newTime)
   {
      Console.WriteLine("{0} converts to {1}", sourceTime, newTime);
      Console.WriteLine("{0} and {1} are equal: {2}", 
                        sourceTime, newTime, sourceTime.Equals(newTime));
      Console.WriteLine("{0} and {1} are identical: {2}", 
                        sourceTime, newTime, 
                        sourceTime.EqualsExact(newTime)); 
      Console.WriteLine();
   }
}
//
// The example displays the following output:
//    9/1/2007 9:30:00 AM -05:00 converts to 9/1/2007 9:30:00 AM -05:00
//    9/1/2007 9:30:00 AM -05:00 and 9/1/2007 9:30:00 AM -05:00 are equal: True
//    9/1/2007 9:30:00 AM -05:00 and 9/1/2007 9:30:00 AM -05:00 are identical: True
//    
//    9/1/2007 9:30:00 AM -05:00 converts to 9/1/2007 2:30:00 PM +00:00
//    9/1/2007 9:30:00 AM -05:00 and 9/1/2007 2:30:00 PM +00:00 are equal: True
//    9/1/2007 9:30:00 AM -05:00 and 9/1/2007 2:30:00 PM +00:00 are identical: False
//    
//    9/1/2007 9:30:00 AM -05:00 converts to 9/1/2007 6:30:00 AM -08:00
//    9/1/2007 9:30:00 AM -05:00 and 9/1/2007 6:30:00 AM -08:00 are equal: True
//    9/1/2007 9:30:00 AM -05:00 and 9/1/2007 6:30:00 AM -08:00 are identical: False
//    
//    9/1/2007 9:30:00 AM -05:00 converts to 9/1/2007 5:30:00 PM +03:00
//    9/1/2007 9:30:00 AM -05:00 and 9/1/2007 5:30:00 PM +03:00 are equal: True
//    9/1/2007 9:30:00 AM -05:00 and 9/1/2007 5:30:00 PM +03:00 are identical: False
// </Snippet1>
