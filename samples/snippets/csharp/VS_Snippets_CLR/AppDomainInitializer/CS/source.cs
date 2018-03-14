//<Snippet1>
using System;
using System.Security.Policy;

public class Example
{
    public static void Main()
    {
        // Get a reference to the default application domain.
        //
        AppDomain current = AppDomain.CurrentDomain;

        // Create the AppDomainSetup that will be used to set up the child
        // AppDomain.
        AppDomainSetup ads = new AppDomainSetup();

        // Use the evidence from the default application domain to
        // create evidence for the child application domain.
        //
        Evidence ev = new Evidence(current.Evidence);

        // Create an AppDomainInitializer delegate that represents the 
        // callback method, AppDomainInit. Assign this delegate to the
        // AppDomainInitializer property of the AppDomainSetup object.
        //
        AppDomainInitializer adi = new AppDomainInitializer(AppDomainInit);
        ads.AppDomainInitializer = adi;

        // Create an array of strings to pass as arguments to the callback
        // method. Assign the array to the AppDomainInitializerArguments
        // property.
        string[] initArgs = {"String1", "String2"};
        ads.AppDomainInitializerArguments = initArgs;

        // Create a child application domain named "ChildDomain", using 
        // the evidence and the AppDomainSetup object.
        //
        AppDomain ad = AppDomain.CreateDomain("ChildDomain", ev, ads);

        Console.WriteLine("Press the Enter key to exit the example program.");
        Console.ReadLine();
    }

    // The callback method invoked when the child application domain is
    // initialized. The method simply displays the arguments that were
    // passed to it.
    //
    public static void AppDomainInit(string[] args)
    {
        Console.WriteLine("AppDomain \"{0}\" is initialized with these arguments:", 
            AppDomain.CurrentDomain.FriendlyName);
        foreach (string arg in args)
        {
            Console.WriteLine("    {0}", arg);
        }
    }
}

/* This code example produces the following output:

AppDomain "ChildDomain" is initialized with these arguments:
    String1
    String2
 */
//</Snippet1>