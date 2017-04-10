//  <SNIPPET1>
using System;
using System.IO;
using System.Reflection;
using System.Security.Policy;  

class ADSetup
{
    public static void Main()
    {
        // Create application domain setup information
        var domaininfo = new AppDomainSetup();
        domaininfo.ConfigurationFile = System.Environment.CurrentDirectory + 
                                       Path.DirectorySeparatorChar +
                                       "ADSetup.exe.config";
        domaininfo.ApplicationBase = System.Environment.CurrentDirectory;

        //Create evidence for the new appdomain from evidence of the current application domain
        Evidence adEvidence = AppDomain.CurrentDomain.Evidence;

        // Create appdomain
        AppDomain domain = AppDomain.CreateDomain("Domain2", adEvidence, domaininfo);

        // Display application domain information.
        Console.WriteLine("Host domain: " + AppDomain.CurrentDomain.FriendlyName);
        Console.WriteLine("Child domain: " + domain.FriendlyName);
        Console.WriteLine();
        Console.WriteLine("Configuration file: " + domain.SetupInformation.ConfigurationFile);
        Console.WriteLine("Application Base Directory: " + domain.BaseDirectory);

        AppDomain.Unload(domain);
    }
}
// The example displays output like the following:
//    Host domain: adsetup.exe
//    Child domain: Domain2
//    
//    Configuration file: C:\Test\ADSetup.exe.config
//    Application Base Directory: C:\Test
//  </SNIPPET1>
