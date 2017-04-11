// <Snippet1>
using System;

public class Example
{
   public static void Main()
   {
      DateTime date1 = new DateTime(2010, 3, 14, 2, 30, 0, DateTimeKind.Local);
      Console.WriteLine("Invalid time: {0}", 
                        TimeZoneInfo.Local.IsInvalidTime(date1));
      DateTime utcDate1 = date1.ToUniversalTime();
      DateTime date2 = utcDate1.ToLocalTime();
      Console.WriteLine("{0} --> {1}", date1, date2);      
   }
}
// The example displays the following output:
//       Invalid time: True
//       3/14/2010 2:30:00 AM --> 3/14/2010 3:30:00 AM
// </Snippet1>