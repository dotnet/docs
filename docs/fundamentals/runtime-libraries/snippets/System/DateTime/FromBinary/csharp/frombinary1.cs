// <Snippet1>
using System;

public class Example
{
   public static void Main()
   {
      DateTime localDate = new DateTime(2010, 3, 14, 2, 30, 0, DateTimeKind.Local);
      long binLocal = localDate.ToBinary();
      if (TimeZoneInfo.Local.IsInvalidTime(localDate))
         Console.WriteLine($"{localDate} is an invalid time in the {TimeZoneInfo.Local.StandardName} zone.");

      DateTime localDate2 = DateTime.FromBinary(binLocal);
      Console.WriteLine("{0} = {1}: {2}",
                        localDate, localDate2, localDate.Equals(localDate2));
   }
}
// The example displays the following output:
//    3/14/2010 2:30:00 AM is an invalid time in the Pacific Standard Time zone.
//    3/14/2010 2:30:00 AM = 3/14/2010 3:30:00 AM: False
// </Snippet1>
