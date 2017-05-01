// <Snippet2>
using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      DateTime localDate = DateTime.Now;
      String[] cultureNames = { "en-US", "en-GB", "fr-FR",
                                "de-DE", "ru-RU" };

      foreach (var cultureName in cultureNames) {
         var culture = new CultureInfo(cultureName);
         Console.WriteLine("{0}: {1}", cultureName,
                           localDate.ToString(culture));
      }
   }
}
// The example displays the following output:
//       en-US: 6/19/2015 10:03:06 AM
//       en-GB: 19/06/2015 10:03:06
//       fr-FR: 19/06/2015 10:03:06
//       de-DE: 19.06.2015 10:03:06
//       ru-RU: 19.06.2015 10:03:06
// </Snippet2>