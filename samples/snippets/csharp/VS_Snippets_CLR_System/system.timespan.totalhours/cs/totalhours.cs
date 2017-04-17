// <Snippet1>
using System;

public class Example
{
   public static void Main()
   {
      // Define an interval of 1 day, 15+ hours.
      TimeSpan interval = new TimeSpan(1, 15, 42, 45, 750); 
      Console.WriteLine("Value of TimeSpan: {0}", interval);
      
      Console.WriteLine("{0:N5} hours, as follows:", interval.TotalHours);
      Console.WriteLine("   Hours:        {0,3}", 
                        interval.Days * 24 + interval.Hours);
      Console.WriteLine("   Minutes:      {0,3}", interval.Minutes);
      Console.WriteLine("   Seconds:      {0,3}", interval.Seconds);
      Console.WriteLine("   Milliseconds: {0,3}", interval.Milliseconds);
   }
}
// The example displays the following output:
//       Value of TimeSpan: 1.15:42:45.7500000
//       39.71271 hours, as follows:
//          Hours:         39
//          Minutes:       42
//          Seconds:       45
//          Milliseconds: 750
// </Snippet1>
