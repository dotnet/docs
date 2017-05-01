// <Snippet4>
using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      var faIR = new CultureInfo("fa-IR");
      var cal = faIR.DateTimeFormat.Calendar;
      var dat = new DateTime(1395, 8, 18, cal);
      Console.WriteLine("Using the Umm-al-Qura calendar:");
      Console.WriteLine("Date: {0}", dat.ToString("d", faIR));
      Console.WriteLine("Year: {0}", cal.GetYear(dat));
      Console.WriteLine("Leap year: {0}\n", 
                        cal.IsLeapYear(cal.GetYear(dat)));
      
      Console.WriteLine("Using the Gregorian calendar:");
      Console.WriteLine("Date: {0:d}", dat);
      Console.WriteLine("Year: {0}", dat.Year);
      Console.WriteLine("Leap year: {0}", DateTime.IsLeapYear(dat.Year));
   }
}
// The example displays the following output:
//       Using the Umm-al-Qura calendar:
//       Date: 18/08/1395
//       Year: 1395
//       Leap year: True
//       
//       Using the Gregorian calendar:
//       Date: 11/8/2016
//       Year: 2016
//       Leap year: True
// </Snippet4>

