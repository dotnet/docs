// <Snippet1>
using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      Calendar cal = new UmAlQuraCalendar();
      int currentYear = cal.GetYear(DateTime.Now);
      
      for (int year = currentYear; year <= currentYear + 9; year++)
         Console.WriteLine("{0:d4}: {1} days {2}", year, 
                           cal.GetDaysInYear(year, UmAlQuraCalendar.UmAlQuraEra), 
                           cal.IsLeapYear(year, UmAlQuraCalendar.UmAlQuraEra) ?
                              "(Leap Year)" : "");        
   }
}
// The example displays the following output:
//       1431: 354 days
//       1432: 354 days
//       1433: 355 days (Leap Year)
//       1434: 354 days
//       1435: 355 days (Leap Year)
//       1436: 354 days
//       1437: 354 days
//       1438: 354 days
//       1439: 355 days (Leap Year)
//       1440: 354 days
// </Snippet1>
