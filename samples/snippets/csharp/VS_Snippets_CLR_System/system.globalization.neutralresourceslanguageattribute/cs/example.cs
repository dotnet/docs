// <Snippet1>
using System;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Threading;

[assembly:NeutralResourcesLanguageAttribute("en")]
public class Example
{
   public static void Main()
   {
      // Select the current culture randomly to test resource fallback.
      string[] cultures = { "de-DE", "en-us", "fr-FR" };
      Random rnd = new Random();
      int index = rnd.Next(0, cultures.Length);
      Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(cultures[index]);      
      Console.WriteLine("The current culture is {0}", 
                        CultureInfo.CurrentUICulture.Name);       

      // Retrieve the resource.
      ResourceManager rm = new ResourceManager("ExampleResources" , 
                                               typeof(Example).Assembly);
      string greeting = rm.GetString("Greeting");
      
      Console.Write("Enter your name: ");
      string name = Console.ReadLine();
      Console.WriteLine("{0} {1}!", greeting, name);
   }
}
// </Snippet1>
