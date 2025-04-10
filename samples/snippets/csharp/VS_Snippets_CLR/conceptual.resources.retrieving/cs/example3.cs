// <Snippet9>
using System;
using System.Globalization;
using System.Resources;
using System.Threading;

[assembly: NeutralResourcesLanguage("en-US")]

public class Example
{
   public static void Main()
   {
      string[] cultureNames = { "en-US", "en-CA", "ru-RU", "fr-FR" };
      ResourceManager rm = ResourceManager.CreateFileBasedResourceManager("Strings", "Resources", null);

      foreach (var cultureName in cultureNames) {
         Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(cultureName);
         string greeting = rm.GetString("Greeting", CultureInfo.CurrentCulture);
         Console.WriteLine($"\n{greeting}!");
         Console.Write(rm.GetString("Prompt", CultureInfo.CurrentCulture));
         string name = Console.ReadLine();
         if (! String.IsNullOrEmpty(name))
            Console.WriteLine("{0}, {1}!", greeting, name);
      }
      Console.WriteLine();
   }
}
// The example displays output like the following:
//       Hello!
//       What is your name? Dakota
//       Hello, Dakota!
//
//       Hello!
//       What is your name? Koani
//       Hello, Koani!
//
//       Здравствуйте!
//       Как вас зовут?Samuel
//       Здравствуйте, Samuel!
//
//       Bon jour!
//       Comment vous appelez-vous?Yiska
//       Bon jour, Yiska!
// </Snippet9>