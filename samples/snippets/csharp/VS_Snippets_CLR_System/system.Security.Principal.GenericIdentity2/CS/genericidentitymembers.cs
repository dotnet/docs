// This sample demonstrates how to call each member of the GenericIdentity
// class.
//<Snippet1>
using System;
using System.Security.Principal;

class GenericIdentityMembers
{
    [STAThread]
    static void Main(string[] args)
    {
        // Create a GenericIdentity object with no authentication type 
        // specified.
        //<Snippet2>
        GenericIdentity defaultIdentity = new GenericIdentity("DefaultUser");
        //</Snippet2>

        // Retrieve a GenericIdentity created from current WindowsIdentity
        // values.
        GenericIdentity currentIdentity = GetGenericIdentity();

        ShowIdentityPreferences(new GenericIdentity(""));
        ShowIdentityPreferences(defaultIdentity);
        ShowIdentityPreferences(currentIdentity);

        Console.WriteLine("The sample completed successfully; " +
            "press Enter to continue.");
        Console.ReadLine();
    }

    // Print identity preferences to the console window.
    private static void ShowIdentityPreferences(
        GenericIdentity genericIdentity)
    {
        // Retrieve the name of the generic identity object.
        //<Snippet4>
        string identityName = genericIdentity.Name;
        //</Snippet4>

        // Retrieve the authentication type of the generic identity object.
        //<Snippet5>
        string identityAuthenticationType = 
            genericIdentity.AuthenticationType;
        //</Snippet5>

        Console.WriteLine("Name: " + identityName);
        Console.WriteLine("Type: " + identityAuthenticationType);
        
        // Verify that the user's identity has been authenticated
        // (was created with a valid name).
        //<Snippet6>
        if (genericIdentity.IsAuthenticated)
        //</Snippet6>
        {
            Console.WriteLine("The user's identity has been authenticated.");
        }
        else
        {
            Console.WriteLine("The user's identity has not been " + 
                "authenticated.");
        }
        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~");
    }

    // Create generic identity based on values from the current
    // WindowsIdentity.
    private static GenericIdentity GetGenericIdentity()
    {
        // Get values from the current WindowsIdentity.
        //<Snippet3>
        WindowsIdentity windowsIdentity = WindowsIdentity.GetCurrent();

        // Construct a GenericIdentity object based on the current Windows
        // identity name and authentication type.
        string authenticationType = windowsIdentity.AuthenticationType;
        string userName = windowsIdentity.Name;
        GenericIdentity authenticatedGenericIdentity =
            new GenericIdentity(userName, authenticationType);
        //</Snippet3>

        return authenticatedGenericIdentity;
    }
}

//</Snippet1>