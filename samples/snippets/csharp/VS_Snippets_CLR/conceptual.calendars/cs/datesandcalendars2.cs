// <Snippet3>
using System;
using System.Globalization;
using System.Threading;

public class Example
{
   public static void Main()
   {
      // Make Arabic (Egypt) the current culture
      // and Umm al-Qura calendar the current calendar.
      CultureInfo arEG = CultureInfo.CreateSpecificCulture("ar-EG");
      Calendar cal = new UmAlQuraCalendar();
      arEG.DateTimeFormat.Calendar = cal;
      Thread.CurrentThread.CurrentCulture = arEG;

      // Display information on current culture and calendar.
      DisplayCurrentInfo();

      // Instantiate a date object.
      DateTime date1 = new DateTime(2011, 7, 15);

      // Display the string representation of the date.
      Console.WriteLine($"Date: {date1:d}");
      Console.WriteLine($"Date in the Invariant Culture: {date1.ToString("d", CultureInfo.InvariantCulture)}");
      Console.WriteLine();

      // Compare DateTime properties and Calendar methods.
      Console.WriteLine($"DateTime.Month property: {date1.Month}");
      Console.WriteLine($"UmAlQura.GetMonth: {cal.GetMonth(date1)}");
      Console.WriteLine();

      Console.WriteLine($"DateTime.Day property: {date1.Day}");
      Console.WriteLine($"UmAlQura.GetDayOfMonth: {cal.GetDayOfMonth(date1)}");
      Console.WriteLine();

      Console.WriteLine($"DateTime.Year property: {date1.Year:D4}");
      Console.WriteLine($"UmAlQura.GetYear: {cal.GetYear(date1)}");
      Console.WriteLine();
   }

   private static void DisplayCurrentInfo()
   {
      Console.WriteLine($"Current Culture: {CultureInfo.CurrentCulture.Name}");
      Console.WriteLine($"Current Calendar: {DateTimeFormatInfo.CurrentInfo.Calendar}");
   }
}
// The example displays the following output:
//    Current Culture: ar-EG
//    Current Calendar: System.Globalization.UmAlQuraCalendar
//    Date: 14/08/32
//    Date in the Invariant Culture: 07/15/2011
//
//    DateTime.Month property: 7
//    UmAlQura.GetMonth: 8
//
//    DateTime.Day property: 15
//    UmAlQura.GetDayOfMonth: 14
//
//    DateTime.Year property: 2011
//    UmAlQura.GetYear: 1432
// </Snippet3>
