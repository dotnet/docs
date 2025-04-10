// <Snippet3>
using System;
using System.Globalization;
using System.Resources;
using System.Threading;

[assembly: NeutralResourcesLanguageAttribute("en-US")]

public class Example
{
   public static void Main()
   {
      string[] cultureNames = { "en-US", "fr-FR", "ru-RU", "es-ES" };
      Random rnd = new Random();
      ResourceManager rm = new ResourceManager("Strings",
                               typeof(Example).Assembly);

      for (int ctr = 0; ctr <= cultureNames.Length; ctr++) {
         string cultureName = cultureNames[rnd.Next(0, cultureNames.Length)];
         CultureInfo culture = CultureInfo.CreateSpecificCulture(cultureName);
         Thread.CurrentThread.CurrentCulture = culture;
         Thread.CurrentThread.CurrentUICulture = culture;

         Console.WriteLine($"Current culture: {culture.NativeName}");
         string timeString = rm.GetString("TimeHeader");
         Console.WriteLine($"{timeString} {DateTime.Now:T}\n");
      }
   }
}
// The example displays output like the following:
//    Current culture: English (United States)
//    The current time is 9:34:18 AM
//
//    Current culture: Español (España, alfabetización internacional)
//    The current time is 9:34:18
//
//    Current culture: русский (Россия)
//    Текущее время — 9:34:18
//
//    Current culture: français (France)
//    L'heure actuelle est 09:34:18
//
//    Current culture: русский (Россия)
//    Текущее время — 9:34:18
// </Snippet3>
