// <Snippet1>
using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      // Create a CultureInfo for Thai in Thailand.
      CultureInfo th = CultureInfo.CreateSpecificCulture("th-TH");
      DisplayCalendars(th);

      // Create a CultureInfo for Japanese in Japan.
      CultureInfo ja = CultureInfo.CreateSpecificCulture("ja-JP");
      DisplayCalendars(ja);
   }

   static void DisplayCalendars(CultureInfo ci)
   {
      Console.WriteLine($"Calendars for the {ci.Name} culture:");

      // Get the culture's default calendar.
      Calendar defaultCalendar = ci.Calendar;
      Console.Write("   Default Calendar: {0}", GetCalendarName(defaultCalendar));

      if (defaultCalendar is GregorianCalendar)
         Console.WriteLine(" ({0})",
                           ((GregorianCalendar) defaultCalendar).CalendarType);
      else
         Console.WriteLine();

      // Get the culture's optional calendars.
      Console.WriteLine("   Optional Calendars:");
      foreach (var optionalCalendar in ci.OptionalCalendars) {
         Console.Write("{0,6}{1}", "", GetCalendarName(optionalCalendar));
         if (optionalCalendar is GregorianCalendar)
            Console.Write(" ({0})",
                          ((GregorianCalendar) optionalCalendar).CalendarType);

         Console.WriteLine();
      }
      Console.WriteLine();
   }

   static string GetCalendarName(Calendar cal)
   {
      return cal.ToString().Replace("System.Globalization.", "");
   }
}
// The example displays the following output:
//       Calendars for the th-TH culture:
//          Default Calendar: ThaiBuddhistCalendar
//          Optional Calendars:
//             ThaiBuddhistCalendar
//             GregorianCalendar (Localized)
//
//       Calendars for the ja-JP culture:
//          Default Calendar: GregorianCalendar (Localized)
//          Optional Calendars:
//             GregorianCalendar (Localized)
//             JapaneseCalendar
//             GregorianCalendar (USEnglish)
// </Snippet1>
