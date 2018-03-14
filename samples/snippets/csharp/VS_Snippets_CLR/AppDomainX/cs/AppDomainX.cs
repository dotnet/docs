//Types:System.AppDomain,System.AppDomainSetup Vendor: Richter
//Translated by REDMOND\glennha
//<snippet1>
using System;
using System.Reflection;
using System.Threading;

//<snippet2>
class Module1
{
    public static void Main()
    {
        // Get and display the friendly name of the default AppDomain.
        string callingDomainName = Thread.GetDomain().FriendlyName;
        Console.WriteLine(callingDomainName);

        // Get and display the full name of the EXE assembly.
        string exeAssembly = Assembly.GetEntryAssembly().FullName;
        Console.WriteLine(exeAssembly);

        // Construct and initialize settings for a second AppDomain.
        AppDomainSetup ads = new AppDomainSetup();
        ads.ApplicationBase = AppDomain.CurrentDomain.BaseDirectory;

        ads.DisallowBindingRedirects = false;
        ads.DisallowCodeDownload = true;
        ads.ConfigurationFile = 
            AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;

        // Create the second AppDomain.
        AppDomain ad2 = AppDomain.CreateDomain("AD #2", null, ads);

        // Create an instance of MarshalbyRefType in the second AppDomain. 
        // A proxy to the object is returned.
        MarshalByRefType mbrt = 
            (MarshalByRefType) ad2.CreateInstanceAndUnwrap(
                exeAssembly, 
                typeof(MarshalByRefType).FullName
            );

        // Call a method on the object via the proxy, passing the 
        // default AppDomain's friendly name in as a parameter.
        mbrt.SomeMethod(callingDomainName);

        // Unload the second AppDomain. This deletes its object and 
        // invalidates the proxy object.
        AppDomain.Unload(ad2);
        try
        {
            // Call the method again. Note that this time it fails 
            // because the second AppDomain was unloaded.
            mbrt.SomeMethod(callingDomainName);
            Console.WriteLine("Sucessful call.");
        }
        catch(AppDomainUnloadedException)
        {
            Console.WriteLine("Failed call; this is expected.");
        }
    }
}
//</snippet2>

//<snippet3>
// Because this class is derived from MarshalByRefObject, a proxy 
// to a MarshalByRefType object can be returned across an AppDomain 
// boundary.
public class MarshalByRefType : MarshalByRefObject
{
    //  Call this method via a proxy.
    public void SomeMethod(string callingDomainName)
    {
        // Get this AppDomain's settings and display some of them.
        AppDomainSetup ads = AppDomain.CurrentDomain.SetupInformation;
        Console.WriteLine("AppName={0}, AppBase={1}, ConfigFile={2}", 
            ads.ApplicationName, 
            ads.ApplicationBase, 
            ads.ConfigurationFile
        );

        // Display the name of the calling AppDomain and the name 
        // of the second domain.
        // NOTE: The application's thread has transitioned between 
        // AppDomains.
        Console.WriteLine("Calling from '{0}' to '{1}'.", 
            callingDomainName, 
            Thread.GetDomain().FriendlyName
        );
    }
}
//</snippet3>

/* This code produces output similar to the following: 

AppDomainX.exe
AppDomainX, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
AppName=, AppBase=C:\AppDomain\bin, ConfigFile=C:\AppDomain\bin\AppDomainX.exe.config
Calling from 'AppDomainX.exe' to 'AD #2'.
Failed call; this is expected.
 */
//</snippet1>




