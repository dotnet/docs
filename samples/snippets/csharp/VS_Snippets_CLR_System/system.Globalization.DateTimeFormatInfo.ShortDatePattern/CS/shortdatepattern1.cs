// <Snippet2>
using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      DateTimeFormatInfo dtfi = CultureInfo.CreateSpecificCulture("en-US").DateTimeFormat;
      DateTime date1 = new DateTime(2011, 5, 1);
      Console.WriteLine("Original Short Date Pattern:");
      Console.WriteLine("   {0}: {1}", dtfi.ShortDatePattern, 
                                       date1.ToString("d", dtfi));
      dtfi.DateSeparator = "-";
      dtfi.ShortDatePattern = @"yyyy/MM/dd";
      Console.WriteLine("Revised Short Date Pattern:");
      Console.WriteLine("   {0}: {1}", dtfi.ShortDatePattern, 
                                       date1.ToString("d", dtfi));
   }
}
// The example displays the following output:
//       Original Short Date Pattern:
//          M/d/yyyy: 5/1/2011
//       Revised Short Date Pattern:
//          yyyy/MM/dd: 2011-05-01
// </Snippet2>
