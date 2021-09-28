//<snippet2>
using System;
using System.Reflection;

class AppDomain3
{
    public static void Main()
    {
        // Create the new application domain.
        AppDomain domain = AppDomain.CreateDomain("MyDomain", null);

        // Output to the console.
        Console.WriteLine("Host domain: " + AppDomain.CurrentDomain.FriendlyName);
        Console.WriteLine("New domain: " + domain.FriendlyName);
        Console.WriteLine("Application base is: " + domain.BaseDirectory);
        Console.WriteLine("Relative search path is: " + domain.RelativeSearchPath);
        Console.WriteLine("Shadow copy files is set to: " + domain.ShadowCopyFiles);
        AppDomain.Unload(domain);
    }
}
//</snippet2>
