// <Snippet10>
using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      DateTime dateValue = new DateTime(2013, 8, 18); 
      CultureInfo enUS = CultureInfo.CreateSpecificCulture("en-US");
      DateTimeFormatInfo dtfi = enUS.DateTimeFormat;
      
      Console.WriteLine("Before modifying DateTimeFormatInfo object: ");
      Console.WriteLine("{0}: {1}\n", dtfi.ShortDatePattern, 
                                    dateValue.ToString("d", enUS));

      // Modify the short date pattern.
      dtfi.ShortDatePattern = "yyyy-MM-dd";
      Console.WriteLine("After modifying DateTimeFormatInfo object: ");
      Console.WriteLine("{0}: {1}", dtfi.ShortDatePattern, 
                                    dateValue.ToString("d", enUS));
   }
}
// The example displays the following output:
//       Before modifying DateTimeFormatInfo object:
//       M/d/yyyy: 8/18/2013
//       
//       After modifying DateTimeFormatInfo object:
//       yyyy-MM-dd: 2013-08-18
// </Snippet10>
