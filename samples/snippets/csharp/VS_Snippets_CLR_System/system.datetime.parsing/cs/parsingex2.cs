// <Snippet2>
using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      string[] formats = { "yyyyMMdd", "HHmmss" };
      string[] dateStrings = { "20130816", "20131608", "  20130816   ", 
                               "115216", "521116", "  115216  " };
      DateTime parsedDate;
      
      foreach (var dateString in dateStrings) {
         if (DateTime.TryParseExact(dateString, formats, null, 
                                    DateTimeStyles.AllowWhiteSpaces |
                                    DateTimeStyles.AdjustToUniversal,
                                    out parsedDate))
            Console.WriteLine("{0} --> {1:g}", dateString, parsedDate);
         else
            Console.WriteLine("Cannot convert {0}", dateString);
      }
   }
}
// The example displays the following output:
//       20130816 --> 8/16/2013 12:00 AM
//       Cannot convert 20131608
//         20130816    --> 8/16/2013 12:00 AM
//       115216 --> 4/22/2013 11:52 AM
//       Cannot convert 521116
//         115216   --> 4/22/2013 11:52 AM
// </Snippet2>

