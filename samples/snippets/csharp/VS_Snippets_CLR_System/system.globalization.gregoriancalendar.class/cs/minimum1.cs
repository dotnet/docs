// <Snippet1>
using System;
using System.Globalization;
using System.Threading;

public class Example
{
   public static void Main()
   {
      Thread.CurrentThread.CurrentCulture = new CultureInfo("da-DK");
      
      JulianCalendar jc = new JulianCalendar();
      DateTime lastDate = new DateTime(1700, 2, 18, jc);
      Console.WriteLine("Last date (Gregorian): {0:d}", lastDate);
      Console.WriteLine("Last date (Julian): {0}-{1}-{2}\n", jc.GetDayOfMonth(lastDate),
                        jc.GetMonth(lastDate), jc.GetYear(lastDate));
      
      DateTime firstDate = lastDate.AddDays(1);
      Console.WriteLine("First date (Gregorian): {0:d}", firstDate);
      Console.WriteLine("First date (Julian): {0}-{1}-{2}",  jc.GetDayOfMonth(firstDate),
                        jc.GetMonth(firstDate), jc.GetYear(firstDate));
   }
}
// The example displays the following output:
//       Last date (Gregorian): 28-02-1700
//       Last date (Julian): 18-2-1700
//       
//       First date (Gregorian): 01-03-1700
//       First date (Julian): 19-2-1700
// </Snippet1>