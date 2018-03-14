// <Snippet1>
using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      CultureInfo ci = CultureInfo.CreateSpecificCulture("");
      ci.NumberFormat.NegativeSign = "\u203E";
      double[] numbers = { -1.0, -16.3, -106.35 };

      foreach (var number in numbers)
         Console.WriteLine(number.ToString(culture));
   }
}
// The example displays the following output:
//       ‾1
//       ‾16.3
//       ‾106.35
// </Snippet1>
