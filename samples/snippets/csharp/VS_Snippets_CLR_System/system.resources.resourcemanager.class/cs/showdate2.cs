// <Snippet3>
using System;
using System.Globalization;
using System.Resources;
using System.Threading;

[assembly:NeutralResourcesLanguage("en")]

public class Example
{
   public static void Main()
   {
      Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("ru-RU");
      Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("ru-RU");
      
      string[] cultureNames = { "fr-FR", "sv-SE" };
      ResourceManager rm = new ResourceManager("DateStrings",
                                               typeof(Example).Assembly);
      
      foreach (var cultureName in cultureNames) {
         CultureInfo culture = CultureInfo.CreateSpecificCulture(cultureName);
         string dateString = rm.GetString("DateStart", culture);
         Console.WriteLine("{0}: {1} {2}.", culture.DisplayName, dateString, 
                                            DateTime.Now.ToString("M", culture));                           
         Console.WriteLine();
      }   
   }
}
// The example displays output similar to the following:
//       French (France): Aujourd'hui, c'est le 7 février.
//       
//       Swedish (Sweden): Today is den 7 februari.
// </Snippet3>
