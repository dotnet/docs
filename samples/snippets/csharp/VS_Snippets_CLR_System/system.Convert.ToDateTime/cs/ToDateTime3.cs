// <Snippet3>
using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      Console.WriteLine("{0,-18}{1,-12}{2}\n", "Date String", "Culture", "Result");

      string[] cultureNames = { "en-US", "ru-RU","ja-JP" };
      string[] dateStrings = { "01/02/09", "2009/02/03",  "01/2009/03", 
                               "01/02/2009", "21/02/09", "01/22/09",  
                               "01/02/23" };
      // Iterate each culture name in the array.
      foreach (string cultureName in cultureNames)
      {
         CultureInfo culture = new CultureInfo(cultureName);
        
         // Parse each date using the designated culture.
         foreach (string dateStr in dateStrings)
         {
            DateTime dateTimeValue;
            try {
               dateTimeValue = Convert.ToDateTime(dateStr, culture);
                // Display the date and time in a fixed format.
                Console.WriteLine("{0,-18}{1,-12}{2:yyyy-MMM-dd}",
                                  dateStr, cultureName, dateTimeValue);
            }
            catch (FormatException e) { 
                Console.WriteLine("{0,-18}{1,-12}{2}", 
                                  dateStr, cultureName, e.GetType().Name);
            }
         }
         Console.WriteLine();
      }
   }
}
// </Snippet3>
