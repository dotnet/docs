using System;
using System.Security.Principal;

class GenericIdentityMembers
{
    [STAThread]
    static void Main(string[] args)
    {
        // Create a GenericIdentity object with no authentication type 
        // specified.
        GenericIdentity defaultIdentity = new GenericIdentity("DefaultUser");

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
        string identityName = genericIdentity.Name;

        // Retrieve the authentication type of the generic identity object.
        string identityAuthenticationType = 
            genericIdentity.AuthenticationType;

        Console.WriteLine("Name: " + identityName);
        Console.WriteLine("Type: " + identityAuthenticationType);
        
        // Verify that the user's identity has been authenticated
        // (was created with a valid name).
        if (genericIdentity.IsAuthenticated)
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
        WindowsIdentity windowsIdentity = WindowsIdentity.GetCurrent();

        // Construct a GenericIdentity object based on the current Windows
        // identity name and authentication type.
        string authenticationType = windowsIdentity.AuthenticationType;
        string userName = windowsIdentity.Name;
        GenericIdentity authenticatedGenericIdentity =
            new GenericIdentity(userName, authenticationType);

        return authenticatedGenericIdentity;
    }
}
