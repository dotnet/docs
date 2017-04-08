// <Snippet1>
using System;
using System.Globalization;
using System.Threading;

public class YearMethodExample
{
    public static void Main()
    {
      // Initialize date variable and display year
      DateTime date1 = new DateTime(2008, 1, 1, 6, 32, 0);
      Console.WriteLine(date1.Year);                    // Displays 2008
      
      // Set culture to th-TH
      Thread.CurrentThread.CurrentCulture = new CultureInfo("th-TH");
      Console.WriteLine(date1.Year);                    // Displays 2008
      
      // display year using current culture's calendar 
      Calendar thaiCalendar = CultureInfo.CurrentCulture.Calendar;
      Console.WriteLine(thaiCalendar.GetYear(date1));   // Displays 2551
      
      // display year using Persian calendar
      PersianCalendar persianCalendar = new PersianCalendar();
      Console.WriteLine(persianCalendar.GetYear(date1)); // Displays 1386 
   }
}
// </Snippet1>
