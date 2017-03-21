using System;
using System.Globalization;
using System.Resources; 
using System.Threading;

[assembly:NeutralResourcesLanguageAttribute("en-US")]

public class Example
{
   static string[] cultureNames = { "fr-FR", "pt-BR", "ru-RU" };
   
   public static void Main()
   {
      // Make any non-default culture the current culture.
      Random rnd = new Random();
      CultureInfo culture = CultureInfo.CreateSpecificCulture(cultureNames[rnd.Next(0, cultureNames.Length)]);
      Thread.CurrentThread.CurrentUICulture = culture;
      Console.WriteLine("The current culture is {0}\n", CultureInfo.CurrentUICulture.Name);
      CultureInfo enCulture = CultureInfo.CreateSpecificCulture("en-US"); 

      ResourceManager rm = new ResourceManager(typeof(NumberResources));
      Numbers numbers = (Numbers) rm.GetObject("Numbers");
      Numbers numbersEn = (Numbers) rm.GetObject("Numbers", enCulture);
      Console.WriteLine("{0} --> {1}", numbers.One, numbersEn.One); 
      Console.WriteLine("{0} --> {1}", numbers.Three, numbersEn.Three); 
      Console.WriteLine("{0} --> {1}", numbers.Five, numbersEn.Five); 
      Console.WriteLine("{0} --> {1}", numbers.Seven, numbersEn.Seven); 
      Console.WriteLine("{0} --> {1}\n", numbers.Nine, numbersEn.Nine); 
   }
}

internal class NumberResources
{
}
// The example displays output like the following:
//       The current culture is pt-BR
//       
//       um --> one
//       três --> three
//       cinco --> five
//       sete --> seven
//       nove --> nine