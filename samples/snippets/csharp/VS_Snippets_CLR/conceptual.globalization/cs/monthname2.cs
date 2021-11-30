// <Snippet20>
using System;
using System.Globalization;
using System.Threading;

public class Example13
{
   public static void Main13()
   {
      // Set the current culture to French (France).
      CultureInfo.CurrentCulture = CultureInfo.CreateSpecificCulture("fr-FR");

      DateTime midYear = new DateTime(2013, 7, 1);
      Console.WriteLine("{0:d} is a {1}.", midYear, DateUtilities.GetDayName(midYear));
      Console.WriteLine("{0:d} is a {1}.", midYear, DateUtilities.GetDayName((int) midYear.DayOfWeek));
      Console.WriteLine("{0:d} is in {1}.", midYear, DateUtilities.GetMonthName(midYear));
      Console.WriteLine("{0:d} is in {1}.", midYear, DateUtilities.GetMonthName(midYear.Month));
   }
}

public static class DateUtilities
{
   public static string GetDayName(int dayOfWeek)
   {
      if (dayOfWeek < 0 | dayOfWeek > DateTimeFormatInfo.CurrentInfo.DayNames.Length)
         return String.Empty;
      else
         return DateTimeFormatInfo.CurrentInfo.DayNames[dayOfWeek];
   }

   public static string GetDayName(DateTime date)
   {
      return date.ToString("dddd");
   }

   public static string GetMonthName(int month)
   {
      if (month < 1 | month > DateTimeFormatInfo.CurrentInfo.MonthNames.Length - 1)
         return String.Empty;
      else
         return DateTimeFormatInfo.CurrentInfo.MonthNames[month - 1];
   }

   public static string GetMonthName(DateTime date)
   {
      return date.ToString("MMMM");
   }
}
// The example displays the following output:
//       01/07/2013 is a lundi.
//       01/07/2013 is a lundi.
//       01/07/2013 is in juillet.
//       01/07/2013 is in juillet.
// </Snippet20>
