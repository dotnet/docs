// <Snippet6>
using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      JulianCalendar julian = new JulianCalendar();
      DateTime date1 = new DateTime(1905, 1, 9, julian);

      Console.WriteLine("Date ({0}): {1:d}",
                        CultureInfo.CurrentCulture.Calendar,
                        date1);
      Console.WriteLine("Date in Julian calendar: {0:d2}/{1:d2}/{2:d4}",
                        julian.GetMonth(date1),
                        julian.GetDayOfMonth(date1),
                        julian.GetYear(date1));
   }
}
// The example displays the following output:
//    Date (System.Globalization.GregorianCalendar): 1/22/1905
//    Date in Julian calendar: 01/09/1905
// </Snippet6>
