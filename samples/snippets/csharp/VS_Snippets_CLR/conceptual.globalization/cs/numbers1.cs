// <Snippet5>
using System;
using System.Globalization;
using System.Threading;

public class Example14
{
   public static void Main14()
   {
      DateTime dateForMonth = new DateTime(2013, 1, 1);
      double[] temperatures = {  3.4, 3.5, 7.6, 10.4, 14.5, 17.2,
                                19.9, 18.2, 15.9, 11.3, 6.9, 5.3 };

      Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("fr-FR");
      Console.WriteLine("Current Culture: {0}", CultureInfo.CurrentCulture.DisplayName);
      // Build the format string dynamically so we allocate enough space for the month name.
      string fmtString = "{0,-" + GetLongestMonthNameLength().ToString() + ":MMMM}     {1,4}";
      for (int ctr = 0; ctr < temperatures.Length; ctr++)
         Console.WriteLine(fmtString,
                           dateForMonth.AddMonths(ctr),
                           temperatures[ctr]);

      Console.WriteLine();

      Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
      Console.WriteLine("Current Culture: {0}", CultureInfo.CurrentCulture.DisplayName);
      fmtString = "{0,-" + GetLongestMonthNameLength().ToString() + ":MMMM}     {1,4}";
      for (int ctr = 0; ctr < temperatures.Length; ctr++)
         Console.WriteLine(fmtString,
                           dateForMonth.AddMonths(ctr),
                           temperatures[ctr]);
   }

   private static int GetLongestMonthNameLength()
   {
      int length = 0;
      foreach (var nameOfMonth in DateTimeFormatInfo.CurrentInfo.MonthNames)
         if (nameOfMonth.Length > length) length = nameOfMonth.Length;

      return length;
   }
}
// The example displays the following output:
//    Current Culture: French (France)
//       janvier        3,4
//       février        3,5
//       mars           7,6
//       avril         10,4
//       mai           14,5
//       juin          17,2
//       juillet       19,9
//       août          18,2
//       septembre     15,9
//       octobre       11,3
//       novembre       6,9
//       décembre       5,3
//
//       Current Culture: English (United States)
//       January        3.4
//       February       3.5
//       March          7.6
//       April         10.4
//       May           14.5
//       June          17.2
//       July          19.9
//       August        18.2
//       September     15.9
//       October       11.3
//       November       6.9
//       December       5.3
// </Snippet5>
