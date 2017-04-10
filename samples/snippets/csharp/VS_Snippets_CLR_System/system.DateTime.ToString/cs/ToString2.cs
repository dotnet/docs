// <Snippet2>
using System;

public class DateToStringExample
{
   public static void Main()
   {
      DateTime dateValue = new DateTime(2008, 6, 15, 21, 15, 07);
      // Create an array of standard format strings.
      string[] standardFmts = {"d", "D", "f", "F", "g", "G", "m", "o", 
                               "R", "s", "t", "T", "u", "U", "y"};
      // Output date and time using each standard format string.
      foreach (string standardFmt in standardFmts)
         Console.WriteLine("{0}: {1}", standardFmt, 
                           dateValue.ToString(standardFmt));
      Console.WriteLine();
      
      // Create an array of some custom format strings.
      string[] customFmts = {"h:mm:ss.ff t", "d MMM yyyy", "HH:mm:ss.f", 
                             "dd MMM HH:mm:ss", @"\Mon\t\h\: M", "HH:mm:ss.ffffzzz" };
      // Output date and time using each custom format string.
      foreach (string customFmt in customFmts)
         Console.WriteLine("'{0}': {1}", customFmt,
                           dateValue.ToString(customFmt));
   }
}
// This example displays the following output to the console:
//       d: 6/15/2008
//       D: Sunday, June 15, 2008
//       f: Sunday, June 15, 2008 9:15 PM
//       F: Sunday, June 15, 2008 9:15:07 PM
//       g: 6/15/2008 9:15 PM
//       G: 6/15/2008 9:15:07 PM
//       m: June 15
//       o: 2008-06-15T21:15:07.0000000
//       R: Sun, 15 Jun 2008 21:15:07 GMT
//       s: 2008-06-15T21:15:07
//       t: 9:15 PM
//       T: 9:15:07 PM
//       u: 2008-06-15 21:15:07Z
//       U: Monday, June 16, 2008 4:15:07 AM
//       y: June, 2008
//       
//       'h:mm:ss.ff t': 9:15:07.00 P
//       'd MMM yyyy': 15 Jun 2008
//       'HH:mm:ss.f': 21:15:07.0
//       'dd MMM HH:mm:ss': 15 Jun 21:15:07
//       '\Mon\t\h\: M': Month: 6
//       'HH:mm:ss.ffffzzz': 21:15:07.0000-07:00
// </Snippet2>
