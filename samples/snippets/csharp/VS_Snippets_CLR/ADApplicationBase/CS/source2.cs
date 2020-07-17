// <snippet2>
using System;
using System.Reflection;

class AppDomain4
{
    public static void Main()
    {
        // Create application domain setup information.
        AppDomainSetup domaininfo = new AppDomainSetup();
        domaininfo.ApplicationBase = "f:\\work\\development\\latest";

        // Create the application domain.
        AppDomain domain = AppDomain.CreateDomain("MyDomain", null, domaininfo);

        // Write application domain information to the console.
        Console.WriteLine("Host domain: " + AppDomain.CurrentDomain.FriendlyName);
        Console.WriteLine("child domain: " + domain.FriendlyName);
        Console.WriteLine("Application base is: " + domain.SetupInformation.ApplicationBase);

        // Unload the application domain.
        AppDomain.Unload(domain);
    }
}
// </snippet2>
