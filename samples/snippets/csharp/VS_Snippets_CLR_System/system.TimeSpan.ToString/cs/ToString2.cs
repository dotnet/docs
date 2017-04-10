// <Snippet2>
using System;

public class ToString
{
   public static void Main()
   {
      TimeSpan span;

      // Initialize a time span to zero.
      span = TimeSpan.Zero;
      Console.WriteLine(FormatTimeSpan(span, true));
      
      // Initialize a time span to 14 days.
      span = new TimeSpan(-14, 0, 0, 0, 0);
      Console.WriteLine(FormatTimeSpan(span, true));
     
      // Initialize a time span to 1:02:03.
      span = new TimeSpan(1, 2, 3);
      Console.WriteLine(FormatTimeSpan(span, false));
      
      
      // Initialize a time span to 250 milliseconds.
      span = new TimeSpan(0, 0, 0, 0, 250);
      Console.WriteLine(FormatTimeSpan(span, true));
      
      // Initalize a time span to 99 days, 23 hours, 59 minutes, and 59.9999999 seconds.
      span = new TimeSpan(99, 23, 59, 59, 999);
      Console.WriteLine(FormatTimeSpan(span, false));

      // Initalize a timespan to 25 milliseconds.
      span = new TimeSpan(0, 0, 0, 0, 25);
      Console.WriteLine(FormatTimeSpan(span, false));
   }

   private static string FormatTimeSpan(TimeSpan span, bool showSign)
   {
      string sign = String.Empty;
      if (showSign && (span > TimeSpan.Zero)) 
         sign = "+";  
      
      return sign + span.Days.ToString("00") + "." + 
             span.Hours.ToString("00") + ":" + 
             span.Minutes.ToString("00") + ":" + 
             span.Seconds.ToString("00") + "." + 
             span.Milliseconds.ToString("000");
   }
}
// This example displays the following output:
//       00.00:00:00.000
//       -14.00:00:00.000
//       00.01:02:03.000
//       +00.00:00:00.250
//       99.23:59:59.999
//       00.00:00:00.025
// </Snippet2>
