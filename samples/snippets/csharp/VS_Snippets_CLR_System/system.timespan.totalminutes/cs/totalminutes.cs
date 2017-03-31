// <Snippet1>
using System;

public class Example
{
   public static void Main()
   {
      // Define an interval of 1 day, 15+ hours.
      TimeSpan interval = new TimeSpan(1, 15, 42, 45, 750); 
      Console.WriteLine("Value of TimeSpan: {0}", interval);
      
      Console.WriteLine("{0:N5} minutes, as follows:", interval.TotalMinutes);
      Console.WriteLine("   Minutes:      {0,5}", interval.Days * 24 * 60 +  
                                                  interval.Hours * 60 + 
                                                  interval.Minutes);
      Console.WriteLine("   Seconds:      {0,5}", interval.Seconds);
      Console.WriteLine("   Milliseconds: {0,5}", interval.Milliseconds);
   }
}
// The example displays the following output:
//       Value of TimeSpan: 1.15:42:45.7500000
//       2,382.76250 minutes, as follows:
//          Minutes:       2382
//          Seconds:         45
//          Milliseconds:   750
// </Snippet1>
