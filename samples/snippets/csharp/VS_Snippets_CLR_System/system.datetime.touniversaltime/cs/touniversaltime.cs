// <Snippet1>
using System;

public class Example
{
   public static void Main()
   {
      DateTime date1 = new DateTime(2006, 3, 21, 2, 0, 0);
      
      Console.WriteLine(date1.ToUniversalTime());
      Console.WriteLine(TimeZoneInfo.ConvertTimeToUtc(date1));
      
      TimeZoneInfo tz = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");  
      Console.WriteLine(TimeZoneInfo.ConvertTimeToUtc(date1, tz));     
   }
}
// The example displays the following output on Windows XP systems:
//       3/21/2006 9:00:00 AM
//       3/21/2006 9:00:00 AM
//       3/21/2006 10:00:00 AM
// </Snippet1>
