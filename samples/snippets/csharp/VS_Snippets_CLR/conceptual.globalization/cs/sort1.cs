// <Snippet14>
using System;
using System.Globalization;
using System.Threading;

public class Example18
{
   public static void Main18()
   {
      string[] values = { "able", "ångström", "apple", "Æble",
                          "Windows", "Visual Studio" };
      // Change thread to en-US.
      Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
      // Sort the array and copy it to a new array to preserve the order.
      Array.Sort(values);
      string[] enValues = (String[]) values.Clone();

      // Change culture to Swedish (Sweden).
      Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("sv-SE");
      Array.Sort(values);
      string[] svValues = (String[]) values.Clone();

      // Compare the sorted arrays.
      Console.WriteLine("{0,-8} {1,-15} {2,-15}\n", "Position", "en-US", "sv-SE");
      for (int ctr = 0; ctr <= values.GetUpperBound(0); ctr++)
         Console.WriteLine("{0,-8} {1,-15} {2,-15}", ctr, enValues[ctr], svValues[ctr]);
   }
}
// The example displays the following output:
//       Position en-US           sv-SE
//
//       0        able            able
//       1        Æble            Æble
//       2        ångström        apple
//       3        apple           Windows
//       4        Visual Studio   Visual Studio
//       5        Windows         ångström
// </Snippet14>
