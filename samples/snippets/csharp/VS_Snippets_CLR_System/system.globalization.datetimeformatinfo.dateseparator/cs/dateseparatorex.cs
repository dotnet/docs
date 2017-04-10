// <Snippet1>
using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      DateTime value = new DateTime(2013, 9, 8);
      
      string[] formats = { "d", "G", "g" };
      CultureInfo culture = CultureInfo.CreateSpecificCulture("en-US");
      DateTimeFormatInfo dtfi = culture.DateTimeFormat;
      dtfi.DateSeparator = "-";
      
      foreach (var fmt in formats)
         Console.WriteLine("{0}: {1}", fmt, value.ToString(fmt, dtfi));
   }
}
// The example displays the following output:
//       d: 9-8-2013
//       G: 9-8-2013 12:00:00 AM
//       g: 9-8-2013 12:00 AM
// </Snippet1>
