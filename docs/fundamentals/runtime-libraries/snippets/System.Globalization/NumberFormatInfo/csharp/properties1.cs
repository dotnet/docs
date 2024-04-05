// <Snippet2>
using System;
using System.Globalization;

public class PropertiesEx1
{
    public static void Main()
    {
        string[] formatStrings = { "C2", "E1", "F", "G3", "N",
                                 "#,##0.000", "0,000,000,000.0##" };
        CultureInfo culture = CultureInfo.CreateSpecificCulture("en-US");
        Decimal[] values = { 1345.6538m, 1921651.16m };

        foreach (var value in values)
        {
            foreach (var formatString in formatStrings)
            {
                string resultString = value.ToString(formatString, culture);
                Console.WriteLine("{0,-18} -->  {1}", formatString, resultString);
            }
            Console.WriteLine();
        }
    }
}
// The example displays the following output:
//       C2                 -->  $1,345.65
//       E1                 -->  1.3E+003
//       F                  -->  1345.65
//       G3                 -->  1.35E+03
//       N                  -->  1,345.65
//       #,##0.000          -->  1,345.654
//       0,000,000,000.0##  -->  0,000,001,345.654
//
//       C2                 -->  $1,921,651.16
//       E1                 -->  1.9E+006
//       F                  -->  1921651.16
//       G3                 -->  1.92E+06
//       N                  -->  1,921,651.16
//       #,##0.000          -->  1,921,651.160
//       0,000,000,000.0##  -->  0,001,921,651.16
// </Snippet2>
