// <Snippet19>
using System;

public class Example
{
   public static void Main()
   {
      DateTime midYear = new DateTime(2013, 7, 1);
      Console.WriteLine("{0:d} is a {1}.", midYear, GetDayName(midYear));   
   }
   
   private static string GetDayName(DateTime date)
   {
      return date.DayOfWeek.ToString("G");
   }
}
// The example displays the following output:
//        7/1/2013 is a Monday.
// </Snippet19>
