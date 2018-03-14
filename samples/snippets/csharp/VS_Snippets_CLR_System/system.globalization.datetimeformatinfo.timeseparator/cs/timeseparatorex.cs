// <Snippet1>
using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      DateTime value = new DateTime(2013, 9, 8, 14, 30, 0);
      
      string[] formats = { "t", "T", "f", "F", "G", "g" };
      CultureInfo culture = CultureInfo.CreateSpecificCulture("en-US");
      DateTimeFormatInfo dtfi = culture.DateTimeFormat;
      dtfi.TimeSeparator = ".";
      
      foreach (var fmt in formats)
         Console.WriteLine("{0}: {1}", fmt, value.ToString(fmt, dtfi));
   }
}
// The example displays the following output:
//       t: 2.30 PM
//       T: 2.30.00 PM
//       f: Sunday, September 08, 2013 2.30 PM
//       F: Sunday, September 08, 2013 2.30.00 PM
//       G: 9/8/2013 2.30.00 PM
//       g: 9/8/2013 2.30 PM
// </Snippet1>
