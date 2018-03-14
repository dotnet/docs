// <Snippet1>
using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      var date = new DateTime(2016, 05, 28, 10, 28, 0);
      var dtfi = DateTimeFormatInfo.CurrentInfo;
      Console.WriteLine("Date and Time Formats for {0:u} in the {1} Culture:\n", 
                        date, CultureInfo.CurrentCulture.Name); 

      Console.WriteLine("{0,-22} {1,-20} {2,-30}", "Long Date Pattern", 
                        dtfi.LongDatePattern, 
                        date.ToString(dtfi.LongDatePattern));
      Console.WriteLine("{0,-22} {1,-20} {2,-30}", "Long Time Pattern", 
                        dtfi.LongTimePattern, 
                        date.ToString(dtfi.LongTimePattern));
      Console.WriteLine("{0,-22} {1,-20} {2,-30}", "Month/Day Pattern", 
                        dtfi.MonthDayPattern, 
                        date.ToString(dtfi.MonthDayPattern));
      Console.WriteLine("{0,-22} {1,-20} {2,-30}", "Short Date Pattern", 
                        dtfi.ShortDatePattern, 
                        date.ToString(dtfi.ShortDatePattern));
      Console.WriteLine("{0,-22} {1,-20} {2,-30}", "Short Time Pattern", 
                        dtfi.ShortTimePattern, 
                        date.ToString(dtfi.ShortTimePattern));
      Console.WriteLine("{0,-22} {1,-20} {2,-30}", "Year/Month Pattern", 
                        dtfi.YearMonthPattern, 
                        date.ToString(dtfi.YearMonthPattern));
   }
}
// The example displays the following output:
//    Date and Time Formats for 2016-05-28 10:28:00Z in the en-US Culture:
//    
//    Long Date Pattern      dddd, MMMM d, yyyy   Saturday, May 28, 2016
//    Long Time Pattern      h:mm:ss tt           10:28:00 AM
//    Month/Day Pattern      MMMM d               May 28
//    Short Date Pattern     M/d/yyyy             5/28/2016
//    Short Time Pattern     h:mm tt              10:28 AM
//    Year/Month Pattern     MMMM yyyy            May 2016
// </Snippet1>

