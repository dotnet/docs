// <Snippet1>
using System;
using System.Reflection;
using System.Resources;

public class Example
{
   public static void Main()
   {
      ResourceManager rm = new ResourceManager("GreetingResources",
                               typeof(Example).Assembly);
      Console.Write(rm.GetString("prompt"));
      string name = Console.ReadLine();
      Console.WriteLine(rm.GetString("greeting"), name);
   }
}
// The example displays output like the following:
//       Enter your name: Wilberforce
//       Hello, Wilberforce!
// </Snippet1>
