// <Snippet9>
using System;
using System.Globalization;

public class Example15
{
   public static void Main()
   {
      string dateString = "07/10/2011";
      CultureInfo[] cultures = { CultureInfo.InvariantCulture, 
                                 CultureInfo.CreateSpecificCulture("en-GB"), 
                                 CultureInfo.CreateSpecificCulture("en-US") };
      Console.WriteLine("{0,-12} {1,10} {2,8} {3,8}\n", "Date String", "Culture", 
                                                 "Month", "Day");
      foreach (var culture in cultures) {
         DateTime date = DateTime.Parse(dateString, culture);
         Console.WriteLine("{0,-12} {1,10} {2,8} {3,8}", dateString, 
                           String.IsNullOrEmpty(culture.Name) ?
                           "Invariant" : culture.Name, 
                           date.Month, date.Day);
      }                      
   }
}
// The example displays the following output:
//       Date String     Culture    Month      Day
//       
//       07/10/2011    Invariant        7       10
//       07/10/2011        en-GB       10        7
//       07/10/2011        en-US        7       10
// </Snippet9>
