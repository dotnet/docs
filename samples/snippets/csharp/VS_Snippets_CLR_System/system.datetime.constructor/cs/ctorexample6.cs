// <Snippet6>
using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading;

public class Example
{
   public static void Main()
   {
      Console.WriteLine("Using the Persian Calendar:");
      PersianCalendar persian = new PersianCalendar();
      DateTime date1 = new DateTime(1389, 5, 27, 16, 32, 18, 500, persian);
      Console.WriteLine(date1.ToString("M/dd/yyyy h:mm:ss.fff tt"));
      Console.WriteLine("{0}/{1}/{2} {3}{7}{4:D2}{7}{5:D2}.{6:G3}\n", 
                                       persian.GetMonth(date1), 
                                       persian.GetDayOfMonth(date1), 
                                       persian.GetYear(date1), 
                                       persian.GetHour(date1), 
                                       persian.GetMinute(date1), 
                                       persian.GetSecond(date1), 
                                       persian.GetMilliseconds(date1), 
                                       DateTimeFormatInfo.CurrentInfo.TimeSeparator);

      Console.WriteLine("Using the Hijri Calendar:");
      // Get current culture so it can later be restored.
      CultureInfo dftCulture = Thread.CurrentThread.CurrentCulture;
      
      // Define strings for use in composite formatting.
      string dFormat; 
      string fmtString; 
      // Define Hijri calendar.
      HijriCalendar hijri = new HijriCalendar();
      // Make ar-SY the current culture and Hijri the current calendar.
      Thread.CurrentThread.CurrentCulture = new CultureInfo("ar-SY");
      CultureInfo current = CultureInfo.CurrentCulture;
      current.DateTimeFormat.Calendar = hijri;
      dFormat = current.DateTimeFormat.ShortDatePattern;
      // Ensure year is displayed as four digits.
      dFormat = Regex.Replace(dFormat, "/yy$", "/yyyy") + " H:mm:ss.fff";
      fmtString = "{0} culture using the {1} calendar: {2:" + dFormat + "}";
      DateTime date2 = new DateTime(1431, 9, 9, 16, 32, 18, 500, hijri);
      Console.WriteLine(fmtString, current, GetCalendarName(hijri), date2);
      
      // Restore previous culture.
      Thread.CurrentThread.CurrentCulture = dftCulture;
      dFormat = DateTimeFormatInfo.CurrentInfo.ShortDatePattern +" H:mm:ss.fff";
      fmtString = "{0} culture using the {1} calendar: {2:" + dFormat + "}";
      Console.WriteLine(fmtString, 
                        CultureInfo.CurrentCulture, 
                        GetCalendarName(CultureInfo.CurrentCulture.Calendar), 
                        date2); 
   }
   
   private static string GetCalendarName(Calendar cal)
   {
      return Regex.Match(cal.ToString(), "\\.(\\w+)Calendar").Groups[1].Value;
   }
}
// The example displays the following output:
//       8/18/2010 4:32:18.500 PM
//       5/27/1389 16:32:18.500
//       
//       Using the Hijri Calendar:
//       ar-SY culture using the Hijri calendar: 09/09/1431 16:32:18.500
//       en-US culture using the Gregorian calendar: 8/18/2010 16:32:18.500
// </Snippet6>
