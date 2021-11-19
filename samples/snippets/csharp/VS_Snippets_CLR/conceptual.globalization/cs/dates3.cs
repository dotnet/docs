// <Snippet4>
using System;
using System.IO;
using System.Globalization;
using System.Threading;

public class Example5
{
   public static void Main5()
   {
      // Persist two dates as strings.
      Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
      DateTime[] dates = { new DateTime(2013, 1, 9),
                           new DateTime(2013, 8, 18) };
      StreamWriter sw = new StreamWriter("dateData.dat");
      sw.Write(String.Format(CultureInfo.InvariantCulture,
                             "{0:d}|{1:d}", dates[0], dates[1]));
      sw.Close();

      // Read the persisted data.
      StreamReader sr = new StreamReader("dateData.dat");
      string dateData = sr.ReadToEnd();
      sr.Close();
      string[] dateStrings = dateData.Split('|');

      // Restore and display the data using the conventions of the en-US culture.
      Console.WriteLine("Current Culture: {0}",
                        Thread.CurrentThread.CurrentCulture.DisplayName);
      foreach (var dateStr in dateStrings) {
         DateTime restoredDate;
         if (DateTime.TryParse(dateStr, CultureInfo.InvariantCulture,
                               DateTimeStyles.None, out restoredDate))
            Console.WriteLine("The date is {0:D}", restoredDate);
         else
            Console.WriteLine("ERROR: Unable to parse {0}", dateStr);
      }
      Console.WriteLine();

      // Restore and display the data using the conventions of the en-GB culture.
      Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-GB");
      Console.WriteLine("Current Culture: {0}",
                        Thread.CurrentThread.CurrentCulture.DisplayName);
      foreach (var dateStr in dateStrings) {
         DateTime restoredDate;
         if (DateTime.TryParse(dateStr,  CultureInfo.InvariantCulture,
                               DateTimeStyles.None, out restoredDate))
            Console.WriteLine("The date is {0:D}", restoredDate);
         else
            Console.WriteLine("ERROR: Unable to parse {0}", dateStr);
      }
   }
}
// The example displays the following output:
//       Current Culture: English (United States)
//       The date is Wednesday, January 09, 2013
//       The date is Sunday, August 18, 2013
//
//       Current Culture: English (United Kingdom)
//       The date is 09 January 2013
//       The date is 18 August 2013
// </Snippet4>
