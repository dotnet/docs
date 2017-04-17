// <Snippet1>
using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      CultureInfo ci = CultureInfo.CreateSpecificCulture("en-US");
      DateTimeFormatInfo dtfi = ci.DateTimeFormat;
      dtfi.AbbreviatedDayNames = new String[] { "Su", "M", "Tu", "W", 
                                                "Th", "F", "Sa" };  
      DateTime dat = new DateTime(2014, 5, 28);

      for (int ctr = 0; ctr <= 6; ctr++) {
         String output = String.Format(ci, "{0:ddd MMM dd, yyyy}", dat.AddDays(ctr));
         Console.WriteLine(output);
      } 
   }
}
// The example displays the following output:
//       W May 28, 2014
//       Th May 29, 2014
//       F May 30, 2014
//       Sa May 31, 2014
//       Su Jun 01, 2014
//       M Jun 02, 2014
//       Tu Jun 03, 2014
// </Snippet1>