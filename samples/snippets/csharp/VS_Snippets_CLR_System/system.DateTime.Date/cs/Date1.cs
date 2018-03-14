// <Snippet1>
using System;

public class Example
{
   public static void Main()
   {
      DateTime date1 = new DateTime(2008, 6, 1, 7, 47, 0);
      Console.WriteLine(date1.ToString());
      
      // Get date-only portion of date, without its time.
      DateTime dateOnly = date1.Date;
      // Display date using short date string.
      Console.WriteLine(dateOnly.ToString("d"));
      // Display date using 24-hour clock.
      Console.WriteLine(dateOnly.ToString("g"));
      Console.WriteLine(dateOnly.ToString("MM/dd/yyyy HH:mm"));   
   }
}
// The example displays output like the following output:
//       6/1/2008 7:47:00 AM
//       6/1/2008
//       6/1/2008 12:00 AM
//       06/01/2008 00:00
// </Snippet1>
