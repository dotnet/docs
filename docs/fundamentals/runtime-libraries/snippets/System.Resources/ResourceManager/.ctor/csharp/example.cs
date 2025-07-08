// <Snippet1>
using System;
using System.Reflection;
using System.Resources;

public class Example1
{
    public static void Main()
    {
        // Retrieve the resource.
        ResourceManager rm = new ResourceManager("ExampleResources",
                                 typeof(Example).Assembly);
        string greeting = rm.GetString("Greeting");

        Console.Write("Enter your name: ");
        string name = Console.ReadLine();
        Console.WriteLine($"{greeting} {name}!");
    }
}
// The example produces output similar to the following:
//       Enter your name: John
//       Hello John!
// </Snippet1>
