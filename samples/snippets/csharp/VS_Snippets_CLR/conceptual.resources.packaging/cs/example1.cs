// <Snippet1>
using System;
using System.Reflection;
using System.Resources;

[assembly:NeutralResourcesLanguage("fr", UltimateResourceFallbackLocation.Satellite)]

public class Example
{
   public static void Main()
   {
      ResourceManager rm = new ResourceManager("resources",
                                               typeof(Example).Assembly);
      string greeting = rm.GetString("Greeting");
      Console.WriteLine(greeting);
   }
}
// </Snippet1>
