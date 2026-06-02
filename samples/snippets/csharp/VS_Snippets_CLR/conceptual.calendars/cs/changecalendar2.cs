// <Snippet2>
using System;
using System.Globalization;
using System.Threading;

public class Example
{
   public static void Main()
   {
      DateTime date1 = new DateTime(2011, 6, 20);

      DisplayCurrentInfo();
      // Display the date using the current culture and calendar.
      Console.WriteLine(date1.ToString("d"));
      Console.WriteLine();

      CultureInfo arSA = CultureInfo.CreateSpecificCulture("ar-SA");

      // Change the current culture to Arabic (Saudi Arabia).
      Thread.CurrentThread.CurrentCulture = arSA;
      // Display date and information about the current culture.
      DisplayCurrentInfo();
      Console.WriteLine(date1.ToString("d"));
      Console.WriteLine();

      // Change the calendar to Hijri.
      Calendar hijri = new HijriCalendar();
      if (CalendarExists(arSA, hijri)) {
         arSA.DateTimeFormat.Calendar = hijri;
         // Display date and information about the current culture.
         DisplayCurrentInfo();
         Console.WriteLine(date1.ToString("d"));
      }
   }

   private static void DisplayCurrentInfo()
   {
      Console.WriteLine($"Current Culture: {CultureInfo.CurrentCulture.Name}");
      Console.WriteLine($"Current Calendar: {DateTimeFormatInfo.CurrentInfo.Calendar}");
   }

   private static bool CalendarExists(CultureInfo culture, Calendar cal)
   {
      foreach (Calendar optionalCalendar in culture.OptionalCalendars)
         if (cal.ToString().Equals(optionalCalendar.ToString()))
            return true;

      return false;
   }
}
// The example displays the following output:
//    Current Culture: en-US
//    Current Calendar: System.Globalization.GregorianCalendar
//    6/20/2011
//
//    Current Culture: ar-SA
//    Current Calendar: System.Globalization.UmAlQuraCalendar
//    18/07/32
//
//    Current Culture: ar-SA
//    Current Calendar: System.Globalization.HijriCalendar
//    19/07/32
// </Snippet2>
