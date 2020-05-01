//<Snippet1>
using System;

class ADSetupInformation
{
    static void Main()
    {
        AppDomain root = AppDomain.CurrentDomain;

        AppDomainSetup setup = new AppDomainSetup();
        setup.ApplicationBase =
            root.SetupInformation.ApplicationBase + @"MyAppSubfolder\";

        AppDomain domain = AppDomain.CreateDomain("MyDomain", null, setup);

        Console.WriteLine("Application base of {0}:\r\n\t{1}",
            root.FriendlyName, root.SetupInformation.ApplicationBase);
        Console.WriteLine("Application base of {0}:\r\n\t{1}",
            domain.FriendlyName, domain.SetupInformation.ApplicationBase);

        AppDomain.Unload(domain);
    }
}

/* This example produces output similar to the following:

Application base of MyApp.exe:
        C:\Program Files\MyApp\
Application base of MyDomain:
        C:\Program Files\MyApp\MyAppSubfolder\
 */
//</Snippet1>
