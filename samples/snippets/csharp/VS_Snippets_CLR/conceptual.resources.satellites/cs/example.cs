using System.Reflection;
using System.Resources;

// <Snippet3>
using System;
using System.Globalization;
using System.Threading;

public class Example
{
   public static void Main()
   {
      string[] cultureNames = { "en-GB", "en-US", "fr-FR", "ru-RU" };
      Random rnd = new Random();
      string cultureName = cultureNames[rnd.Next(0, cultureNames.Length)];
      Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(cultureName);
      Console.WriteLine($"The current UI culture is {Thread.CurrentThread.CurrentUICulture.Name}");
      StringLibrary strLib = new StringLibrary();
      string greeting = strLib.GetGreeting();
      Console.WriteLine(greeting);
   }
}
// </Snippet3>

public class StringLibrary
{
   public string GetGreeting()
   {
      ResourceManager rm = new ResourceManager("Strings",
                                    Assembly.GetAssembly(typeof(StringLibrary)));
      string greeting = rm.GetString("Greeting");
      return greeting;
   }
}
