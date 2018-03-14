// <Snippet1>
using System;
using System.Reflection;

public class Example
{
    public static void Main()
    {
        Assembly mainAssembly = typeof(Example).Assembly;
        Console.WriteLine("The executing assembly is {0}.", mainAssembly);
        Module[] mods = mainAssembly.GetModules();
        Console.WriteLine("\tModules in the assembly:");
        foreach (Module m in mods)
            Console.WriteLine("\t{0}", m);
    }
}
// </Snippet1>
