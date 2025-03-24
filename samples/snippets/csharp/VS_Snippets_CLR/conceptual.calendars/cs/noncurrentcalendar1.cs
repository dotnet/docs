// <Snippet6>
using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      JulianCalendar julian = new JulianCalendar();
      DateTime date1 = new DateTime(1905, 1, 9, julian);

      Console.WriteLine($"Date ({CultureInfo.CurrentCulture.Calendar}): {date1:d}");
      Console.WriteLine($"Date in Julian calendar: {julian.GetMonth(date1):d2}/{julian.GetDayOfMonth(date1):d2}/{julian.GetYear(date1):d4}");
   }
}
// The example displays the following output:
//    Date (System.Globalization.GregorianCalendar): 1/22/1905
//    Date in Julian calendar: 01/09/1905
// </Snippet6>
