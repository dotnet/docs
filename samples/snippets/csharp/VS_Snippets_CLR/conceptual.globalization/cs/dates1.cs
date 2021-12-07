// <Snippet2>
using System;
using System.Globalization;
using System.Threading;

public class Example3
{
   static DateTime[] dates = { new DateTime(2012, 10, 11, 7, 06, 0),
                        new DateTime(2012, 10, 11, 18, 19, 0) };

   public static void Main3()
   {
      Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("hr-HR");
      ShowDayInfo();
      Console.WriteLine();
      Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-GB");
      ShowDayInfo();
   }

   private static void ShowDayInfo()
   {
      Console.WriteLine("Date: {0:D}", dates[0]);
      Console.WriteLine("   Sunrise: {0:T}", dates[0]);
      Console.WriteLine("   Sunset:  {0:T}", dates[1]);
   }
}
// The example displays the following output:
//       Date: 11. listopada 2012.
//          Sunrise: 7:06:00
//          Sunset:  18:19:00
//
//       Date: 11 October 2012
//          Sunrise: 07:06:00
//          Sunset:  18:19:00
// </Snippet2>
