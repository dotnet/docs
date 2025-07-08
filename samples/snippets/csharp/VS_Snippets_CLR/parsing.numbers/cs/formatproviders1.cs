// <Snippet1>
using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      string[] values = { "1,304.16", "$1,456.78", "1,094", "152",
                          "123,45 €", "1 304,16", "Ae9f" };
      double number;
      CultureInfo culture = null;

      foreach (string value in values) {
         try {
            culture = CultureInfo.CreateSpecificCulture("en-US");
            number = Double.Parse(value, culture);
            Console.WriteLine($"{culture.Name}: {value} --> {number}");
         }
         catch (FormatException) {
            Console.WriteLine($"{culture.Name}: Unable to parse '{value}'.");
            culture = CultureInfo.CreateSpecificCulture("fr-FR");
            try {
               number = Double.Parse(value, culture);
               Console.WriteLine($"{culture.Name}: {value} --> {number}");
            }
            catch (FormatException) {
               Console.WriteLine($"{culture.Name}: Unable to parse '{value}'.");
            }
         }
         Console.WriteLine();
      }
   }
}
// The example displays the following output:
//    en-US: 1,304.16 --> 1304.16
//
//    en-US: Unable to parse '$1,456.78'.
//    fr-FR: Unable to parse '$1,456.78'.
//
//    en-US: 1,094 --> 1094
//
//    en-US: 152 --> 152
//
//    en-US: Unable to parse '123,45 €'.
//    fr-FR: Unable to parse '123,45 €'.
//
//    en-US: Unable to parse '1 304,16'.
//    fr-FR: 1 304,16 --> 1304.16
//
//    en-US: Unable to parse 'Ae9f'.
//    fr-FR: Unable to parse 'Ae9f'.
// </Snippet1>
