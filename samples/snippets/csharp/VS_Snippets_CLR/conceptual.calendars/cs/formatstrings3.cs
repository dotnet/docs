// <Snippet10>
using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      DateTime date1 = new DateTime(2011, 8, 28);
      Calendar cal = new JapaneseLunisolarCalendar();

      Console.WriteLine("{0} {1:d4}/{2:d2}/{3:d2}",
                        cal.GetEra(date1),
                        cal.GetYear(date1),
                        cal.GetMonth(date1),
                        cal.GetDayOfMonth(date1));

      // Display eras
      CultureInfo culture = CultureInfo.CreateSpecificCulture("ja-JP");
      DateTimeFormatInfo dtfi = culture.DateTimeFormat;
      dtfi.Calendar = new JapaneseCalendar();

      Console.WriteLine("{0} {1:d4}/{2:d2}/{3:d2}",
                        dtfi.GetAbbreviatedEraName(cal.GetEra(date1)),
                        cal.GetYear(date1),
                        cal.GetMonth(date1),
                        cal.GetDayOfMonth(date1));
   }
}
// The example displays the following output:
//       4 0023/07/29
//       平 0023/07/29
// </Snippet10>
