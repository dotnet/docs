// <Snippet1>
using System;

public class Example
{
   public static void Main()
   {
      // Define an interval of 1 day, 15+ hours.
      TimeSpan interval = new TimeSpan(1, 15, 42, 45, 750); 
      Console.WriteLine("Value of TimeSpan: {0}", interval);
      
      Console.WriteLine("There are {0:N5} milliseconds, as follows:", interval.TotalMilliseconds);
      long nMilliseconds = interval.Days * 24 * 60 * 60 * 1000 + 
                           interval.Hours *60 * 60 * 1000 + 
                           interval.Minutes * 60 * 1000 + 
                           interval.Seconds * 1000 + 
                           interval.Milliseconds;
      Console.WriteLine("   Milliseconds:     {0,18:N0}", nMilliseconds);
      Console.WriteLine("   Ticks:            {0,18:N0}", 
                        nMilliseconds * 10000 - interval.Ticks);
   }
}
// The example displays the following output:
//       Value of TimeSpan: 1.15:42:45.7500000
//       There are 142,965,750.00000 milliseconds, as follows:
//          Milliseconds:            142,965,750
//          Ticks:                             0
// </Snippet1>
