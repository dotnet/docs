// <Snippet10>
using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      DateTime date1 = new DateTime(2011, 8, 28);
      Calendar cal = new JapaneseLunisolarCalendar();

      Console.WriteLine($"{cal.GetEra(date1)} {cal.GetYear(date1):d4}/{cal.GetMonth(date1):d2}/{cal.GetDayOfMonth(date1):d2}");

      // Display eras
      CultureInfo culture = CultureInfo.CreateSpecificCulture("ja-JP");
      DateTimeFormatInfo dtfi = culture.DateTimeFormat;
      dtfi.Calendar = new JapaneseCalendar();

      Console.WriteLine($"{dtfi.GetAbbreviatedEraName(cal.GetEra(date1))} {cal.GetYear(date1):d4}/{cal.GetMonth(date1):d2}/{cal.GetDayOfMonth(date1):d2}");
   }
}
// The example displays the following output:
//       4 0023/07/29
//       平 0023/07/29
// </Snippet10>
