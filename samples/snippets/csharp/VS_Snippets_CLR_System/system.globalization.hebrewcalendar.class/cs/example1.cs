// <Snippet1>
using System;
using System.Globalization;
using System.IO;
using System.Threading;

public class Example
{
   public static void Main()
   {
      StreamWriter output = new StreamWriter("HebrewCalendarInfo.txt");
      
      // Make the Hebrew Calendar the current calendar and
      // Hebrew (Israel) the current thread culture.
      HebrewCalendar hc = new HebrewCalendar();
      CultureInfo culture = CultureInfo.CreateSpecificCulture("he-IL");
      culture.DateTimeFormat.Calendar = hc;
      Thread.CurrentThread.CurrentCulture = culture;
      
      output.WriteLine("{0} Information:\n", 
                       GetCalendarName(culture.DateTimeFormat.Calendar));
      
      // Get the calendar range expressed in both Hebrew calendar and
      // Gregorian calendar dates.
      output.WriteLine("Start Date: {0} ", hc.MinSupportedDateTime);  
      culture.DateTimeFormat.Calendar = culture.Calendar;
      output.WriteLine("            ({0} Gregorian)\n", 
                       hc.MinSupportedDateTime);
      
      culture.DateTimeFormat.Calendar = hc;
      output.WriteLine("End Date: {0} ", hc.MaxSupportedDateTime);
      culture.DateTimeFormat.Calendar = culture.Calendar;
      output.WriteLine("          ({0} Gregorian)\n", 
                       hc.MaxSupportedDateTime);  
      
      culture.DateTimeFormat.Calendar = hc;
      
      // Get the year in the Hebrew calendar that corresponds to 1/1/2012
      // and display information about it.
      DateTime startOfYear = new DateTime(2012, 1, 1);
      output.WriteLine("Days in the Year {0}: {1}\n", 
                       hc.GetYear(startOfYear), 
                       hc.GetDaysInYear(hc.GetYear(startOfYear)));
      
      output.WriteLine("Days in Each Month of {0}:\n", hc.GetYear(startOfYear));
      output.WriteLine("Month       Days       Month Name");
      // Change start of year to first day of first month 
      startOfYear = hc.ToDateTime(hc.GetYear(startOfYear), 1, 1, 0, 0, 0, 0);
      DateTime startOfMonth = startOfYear;
      for (int ctr = 1; ctr <= hc.GetMonthsInYear(hc.GetYear(startOfYear)); ctr++) { 
         output.Write(" {0,2}", ctr);
         output.WriteLine("{0,12}{1,15:MMM}", 
                          hc.GetDaysInMonth(hc.GetYear(startOfMonth), hc.GetMonth(startOfMonth)),
                          startOfMonth);  
         startOfMonth = hc.AddMonths(startOfMonth, 1);                 
      } 
                                     
      output.Close();          
   }

   private static string GetCalendarName(Calendar cal) 
   {
      return cal.ToString().Replace("System.Globalization.", "").Replace("Cal", " Cal");
   }
}
// The example displays the following output:
//       Hebrew Calendar Information:
//       
//       Start Date: ז// טבת שמ"ג 00:00:00 
//                   (01/01/1583 00:00:00 Gregorian)
//       
//       End Date: כ"ט אלול תתקצ"ט 23:59:59 
//                 (29/09/2239 23:59:59 Gregorian)
//       
//       Days in the Year 5772: 354
//       
//       Days in Each Month of 5772:
//       
//       Month       Days       Month Name
//         1          30           תשרי
//         2          29           חשון
//         3          30           כסלו
//         4          29            טבת
//         5          30            שבט
//         6          29            אדר
//         7          30           ניסן
//         8          29           אייר
//         9          30           סיון
//        10          29           תמוז
//        11          30             אב
//        12          29           אלול
// </Snippet1>