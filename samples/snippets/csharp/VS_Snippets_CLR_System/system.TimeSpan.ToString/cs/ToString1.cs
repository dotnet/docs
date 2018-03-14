// <Snippet1>
using System;

public class ToString
{
   public static void Main()
   {
      TimeSpan span;
      
      // Initialize a time span to zero.
      span = TimeSpan.Zero;
      Console.WriteLine(span);

      // Initialize a time span to 14 days.
      span = new TimeSpan(-14, 0, 0, 0, 0);
      Console.WriteLine(span);
     
      // Initialize a time span to 1:02:03.
      span = new TimeSpan(1, 2, 3);
      Console.WriteLine(span);
      
      
      // Initialize a time span to 250 milliseconds.
      span = new TimeSpan(0, 0, 0, 0, 250);
      Console.WriteLine(span);
      
      // Initalize a time span to 99 days, 23 hours, 59 minutes, and 59.999 seconds.
      span = new TimeSpan(99, 23, 59, 59, 999);
      Console.WriteLine(span);
      
      // Initalize a time span to 3 hours.
      span = new TimeSpan(3, 0, 0);
      Console.WriteLine(span);
      
      // Initalize a timespan to 25 milliseconds.
      span = new TimeSpan(0, 0, 0, 0, 25);
      Console.WriteLine(span);
   }
}
// The example displays the following output:
//       00:00:00
//       -14.00:00:00
//       01:02:03
//       00:00:00.2500000
//       99.23:59:59.9990000
//       03:00:00
//       00:00:00.0250000
// </Snippet1>
