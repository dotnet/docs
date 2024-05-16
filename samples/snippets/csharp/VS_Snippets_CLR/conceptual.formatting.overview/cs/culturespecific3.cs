// <Snippet19>
using System.Globalization;

public class Example6
{
   public static void Main()
   {
      string[] cultureNames = { "en-US", "fr-FR", "es-MX", "de-DE" };
      Decimal value = 1043.17m;

      foreach (var cultureName in cultureNames) {
         // Change the current culture.
         CultureInfo.CurrentCulture = CultureInfo.CreateSpecificCulture(cultureName);
         Console.WriteLine($"The current culture is {CultureInfo.CurrentCulture.Name}");
         Console.WriteLine(value.ToString("C2"));
         Console.WriteLine();
      }
   }
}
// The example displays the following output:
//       The current culture is en-US
//       $1,043.17
//
//       The current culture is fr-FR
//       1 043,17 €
//
//       The current culture is es-MX
//       $1,043.17
//
//       The current culture is de-DE
//       1.043,17 €
// </Snippet19>
