// <Snippet3>
using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      DateTime date = new DateTime(2014, 8, 28, 12, 28, 30);
      DateTimeFormatInfo invDTF = new DateTimeFormatInfo();
      String[] formats = invDTF.GetAllDateTimePatterns();

      Console.WriteLine("{0,-40} {1}\n", "Pattern", "Result String");
      foreach (var fmt in formats)
         Console.WriteLine("{0,-40} {1}", fmt, date.ToString(fmt));
   }
}
// The example displays the following output:
//    Pattern                                  Result String
//
//    MM/dd/yyyy                               08/28/2014
//    yyyy-MM-dd                               2014-08-28
//    dddd, dd MMMM yyyy                       Thursday, 28 August 2014
//    dddd, dd MMMM yyyy HH:mm                 Thursday, 28 August 2014 12:28
//    dddd, dd MMMM yyyy hh:mm tt              Thursday, 28 August 2014 12:28 PM
//    dddd, dd MMMM yyyy H:mm                  Thursday, 28 August 2014 12:28
//    dddd, dd MMMM yyyy h:mm tt               Thursday, 28 August 2014 12:28 PM
//    dddd, dd MMMM yyyy HH:mm:ss              Thursday, 28 August 2014 12:28:30
//    MM/dd/yyyy HH:mm                         08/28/2014 12:28
//    MM/dd/yyyy hh:mm tt                      08/28/2014 12:28 PM
//    MM/dd/yyyy H:mm                          08/28/2014 12:28
//    MM/dd/yyyy h:mm tt                       08/28/2014 12:28 PM
//    yyyy-MM-dd HH:mm                         2014-08-28 12:28
//    yyyy-MM-dd hh:mm tt                      2014-08-28 12:28 PM
//    yyyy-MM-dd H:mm                          2014-08-28 12:28
//    yyyy-MM-dd h:mm tt                       2014-08-28 12:28 PM
//    MM/dd/yyyy HH:mm:ss                      08/28/2014 12:28:30
//    yyyy-MM-dd HH:mm:ss                      2014-08-28 12:28:30
//    MMMM dd                                  August 28
//    MMMM dd                                  August 28
//    yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK   2014-08-28T12:28:30.0000000
//    yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK   2014-08-28T12:28:30.0000000
//    ddd, dd MMM yyyy HH':'mm':'ss 'GMT'      Thu, 28 Aug 2014 12:28:30 GMT
//    ddd, dd MMM yyyy HH':'mm':'ss 'GMT'      Thu, 28 Aug 2014 12:28:30 GMT
//    yyyy'-'MM'-'dd'T'HH':'mm':'ss            2014-08-28T12:28:30
//    HH:mm                                    12:28
//    hh:mm tt                                 12:28 PM
//    H:mm                                     12:28
//    h:mm tt                                  12:28 PM
//    HH:mm:ss                                 12:28:30
//    yyyy'-'MM'-'dd HH':'mm':'ss'Z'           2014-08-28 12:28:30Z
//    dddd, dd MMMM yyyy HH:mm:ss              Thursday, 28 August 2014 12:28:30
//    yyyy MMMM                                2014 August
//    yyyy MMMM                                2014 August
// </Snippet3>

