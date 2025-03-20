// <Snippet5>
using System;
using System.Globalization;

public class Example8
{
   public static void Main()
   {
      string[] cultureNames = { "en-US", "en-GB", "fr-FR",
                                "hr-HR", "ja-JP" };
      Decimal value = 1603.49m;
      foreach (var cultureName in cultureNames) {
         CultureInfo culture = new CultureInfo(cultureName);
         Console.WriteLine($"{culture.Name}: {value.ToString("C2", culture)}");
      }
   }
}
// The example displays the following output:
//       en-US: $1,603.49
//       en-GB: £1,603.49
//       fr-FR: 1 603,49 €
//       hr-HR: 1.603,49 kn
//       ja-JP: ¥1,603.49
// </Snippet5>
