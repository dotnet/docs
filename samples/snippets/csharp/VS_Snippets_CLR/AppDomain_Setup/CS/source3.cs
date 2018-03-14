//<snippet3>
using System;
using System.Reflection;

class AppDomain5
{
    public static void Main()
    {
        // Application domain setup information.
        AppDomainSetup domaininfo = new AppDomainSetup();
        domaininfo.ApplicationBase = "f:\\work\\development\\latest";
        domaininfo.ConfigurationFile = "f:\\work\\development\\latest\\appdomain5.exe.config";

        // Creates the application domain.
        AppDomain domain = AppDomain.CreateDomain("MyDomain", null, domaininfo);

        // Write the application domain information to the console.
        Console.WriteLine("Host domain: " + AppDomain.CurrentDomain.FriendlyName);
        Console.WriteLine("Child domain: " + domain.FriendlyName);
        Console.WriteLine();
        Console.WriteLine("Application base is: " + domain.SetupInformation.ApplicationBase);
        Console.WriteLine("Configuration file is: " + domain.SetupInformation.ConfigurationFile);

        // Unloads the application domain.
        AppDomain.Unload(domain);
    }
}
//</snippet3>
