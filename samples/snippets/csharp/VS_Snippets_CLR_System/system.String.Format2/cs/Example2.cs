using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      // <Snippet2>
      string[] cultureNames = { "en-US", "fr-FR", "de-DE", "es-ES" };
      
      DateTime dateToDisplay = new DateTime(2009, 9, 1, 18, 32, 0);
      double value = 9164.32;

      Console.WriteLine("Culture     Date                                Value\n");
      foreach (string cultureName in cultureNames)
      {
         System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo(cultureName);
         string output = String.Format(culture, "{0,-11} {1,-35:D} {2:N}", 
                                       culture.Name, dateToDisplay, value);
         Console.WriteLine(output);
      }    
      // The example displays the following output:
      //    Culture     Date                                Value
      //    
      //    en-US       Tuesday, September 01, 2009         9,164.32
      //    fr-FR       mardi 1 septembre 2009              9 164,32
      //    de-DE       Dienstag, 1. September 2009         9.164,32
      //    es-ES       martes, 01 de septiembre de 2009    9.164,32
      // </Snippet2>
   }
}
