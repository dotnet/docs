// <Snippet17>
using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      Console.WriteLine("'d' standard format string:");
      foreach (var customString in DateTimeFormatInfo.CurrentInfo.GetAllDateTimePatterns('d'))
          Console.WriteLine($"   {customString}");
   }
}
// The example displays the following output:
//       'd' standard format string:
//          M/d/yyyy
//          M/d/yy
//          MM/dd/yy
//          MM/dd/yyyy
//          yy/MM/dd
//          yyyy-MM-dd
//          dd-MMM-yy
// </Snippet17>
