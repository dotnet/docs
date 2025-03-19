// <Snippet5>
using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      DateTime date1 = new DateTime(2009, 6, 30);
      Console.WriteLine($"D Format Specifier:     {0:D}");
      string longPattern = CultureInfo.CurrentCulture.DateTimeFormat.LongDatePattern;
      Console.WriteLine("'{0}' custom format string:     {1}",
                        longPattern, date1.ToString(longPattern));
   }
}
// The example displays the following output when run on a system whose
// current culture is en-US:
//    D Format Specifier:     Tuesday, June 30, 2009
//    'dddd, MMMM dd, yyyy' custom format string:     Tuesday, June 30, 2009
// </Snippet5>
