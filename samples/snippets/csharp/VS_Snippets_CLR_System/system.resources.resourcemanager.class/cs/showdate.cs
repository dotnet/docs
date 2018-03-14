// <Snippet2>
using System;
using System.Globalization;
using System.Resources;
using System.Threading;

[assembly:NeutralResourcesLanguage("en")]

public class Example
{
   public static void Main()
   {
      string[] cultureNames = { "en-US", "fr-FR", "ru-RU", "sv-SE" };
      ResourceManager rm = new ResourceManager("DateStrings",
                                               typeof(Example).Assembly);
      
      foreach (var cultureName in cultureNames) {
         CultureInfo culture = CultureInfo.CreateSpecificCulture(cultureName);
         Thread.CurrentThread.CurrentCulture = culture; 
         Thread.CurrentThread.CurrentUICulture = culture;

         Console.WriteLine("Current UI Culture: {0}", 
                           CultureInfo.CurrentUICulture.Name);
         string dateString = rm.GetString("DateStart");
         Console.WriteLine("{0} {1:M}.\n", dateString, DateTime.Now);                           
      }                                           
   }
}
// The example displays output similar to the following:
//       Current UI Culture: en-US
//       Today is February 03.
//       
//       Current UI Culture: fr-FR
//       Aujourd'hui, c'est le 3 février
//       
//       Current UI Culture: ru-RU
//       Сегодня февраля 03.
//       
//       Current UI Culture: sv-SE
//       Today is den 3 februari.
// </Snippet2>
