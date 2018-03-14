// This sample demonstrates how to use each member of the WindowsIdentity
// class.
//<Snippet1>
using System;
using System.Security.Principal;

class WindowsIdentityMembers
{
    [STAThread]
    static void Main(string[] args)
    {
        // Retrieve the Windows account token for the current user.
        IntPtr logonToken = LogonUser();

        // Constructor implementations.
        IntPtrConstructor(logonToken);
        IntPtrStringConstructor(logonToken);
        IntPtrStringTypeConstructor(logonToken);
        IntPrtStringTypeBoolConstructor(logonToken);

        // Property implementations.
        UseProperties(logonToken);

        // Method implementations.
        GetAnonymousUser();
        ImpersonateIdentity(logonToken);

        Console.WriteLine("This sample completed successfully; " +
            "press Enter to exit.");
        Console.ReadLine();
    }

    // Create a WindowsIdentity object for the user represented by the
    // specified Windows account token.
            //<Snippet2>
    private static void IntPtrConstructor(IntPtr logonToken)
    {
        // Construct a WindowsIdentity object using the input account token.
        WindowsIdentity windowsIdentity = new WindowsIdentity(logonToken);

        Console.WriteLine("Created a Windows identity object named " +
            windowsIdentity.Name + ".");
    }
	        //</Snippet2>

 
    // Create a WindowsIdentity object for the user represented by the
    // specified account token and authentication type.
            //<Snippet4>
    private static void IntPtrStringConstructor(IntPtr logonToken)
    {
        // Construct a WindowsIdentity object using the input account token 
        // and the specified authentication type.
        string authenticationType = "WindowsAuthentication";
        WindowsIdentity windowsIdentity =
			            new WindowsIdentity(logonToken, authenticationType);

        Console.WriteLine("Created a Windows identity object named " +
            windowsIdentity.Name + ".");
    }
        //</Snippet4>

    // Create a WindowsIdentity object for the user represented by the
    // specified account token, authentication type, and Windows account
    // type.
            //<Snippet7>
    private static void IntPtrStringTypeConstructor(IntPtr logonToken)
    {
        // Construct a WindowsIdentity object using the input account token,
        // and the specified authentication type, and Windows account type.
        string authenticationType = "WindowsAuthentication";
        WindowsAccountType guestAccount = WindowsAccountType.Guest;
        WindowsIdentity windowsIdentity =
            new WindowsIdentity(logonToken, authenticationType, guestAccount);

        Console.WriteLine("Created a Windows identity object named " +
            windowsIdentity.Name + ".");
    }
		        //</Snippet7>

    // Create a WindowsIdentity object for the user represented by the
    // specified account token, authentication type, Windows account type, and
    // Boolean authentication flag.
            //<Snippet17>
    private static void IntPrtStringTypeBoolConstructor(IntPtr logonToken)
    {
        // Construct a WindowsIdentity object using the input account token,
        // and the specified authentication type, Windows account type, and
        // authentication flag.
        string authenticationType = "WindowsAuthentication";
        WindowsAccountType guestAccount = WindowsAccountType.Guest;
        bool isAuthenticated = true;
        WindowsIdentity windowsIdentity = new WindowsIdentity(
            logonToken, authenticationType, guestAccount, isAuthenticated);

        Console.WriteLine("Created a Windows identity object named " +
            windowsIdentity.Name + ".");
    }
        //</Snippet17>
    // Access the properties of a WindowsIdentity object.
    private static void UseProperties(IntPtr logonToken)
    {
        WindowsIdentity windowsIdentity = new WindowsIdentity(logonToken);
        string propertyDescription = "The Windows identity named ";

        // Retrieve the Windows logon name from the Windows identity object.
        //<Snippet8>
        propertyDescription += windowsIdentity.Name;
        //</Snippet8>

        // Verify that the user account is not considered to be an Anonymous
        // account by the system.
        //<Snippet9>
        if (!windowsIdentity.IsAnonymous)
        {
            propertyDescription += " is not an Anonymous account";
        }
		        //</Snippet9>

        // Verify that the user account has been authenticated by Windows.
        //<Snippet10>
        if (windowsIdentity.IsAuthenticated)
        {
            propertyDescription += ", is authenticated";
        }
		        //</Snippet10>

        // Verify that the user account is considered to be a System account
        // by the system.
        //<Snippet11>
        if (windowsIdentity.IsSystem)
        {
            propertyDescription += ", is a System account";
        }
        //</Snippet11>
        // Verify that the user account is considered to be a Guest account
        // by the system.
        //<Snippet12>
        if (windowsIdentity.IsGuest)
        {
            propertyDescription += ", is a Guest account";
        }
		        //</Snippet12>

        // Retrieve the authentication type for the 
        //<Snippet18>
        String authenticationType = windowsIdentity.AuthenticationType;

        // Append the authenication type to the output message.
        if (authenticationType != null)
        {
            propertyDescription += (" and uses " + authenticationType);
            propertyDescription += (" authentication type.");
        }
		        //</Snippet18>

        Console.WriteLine(propertyDescription);

        // <Snippet19>
        // Display the SID for the owner.
        Console.Write("The SID for the owner is : ");
        SecurityIdentifier si = windowsIdentity.Owner;
        Console.WriteLine(si.ToString());
        //</Snippet19>
        //<Snippet20>
        // Display the SIDs for the groups the current user belongs to.
        Console.WriteLine("Display the SIDs for the groups the current user belongs to.");
        IdentityReferenceCollection irc = windowsIdentity.Groups;
        foreach (IdentityReference ir in irc)
            Console.WriteLine(ir.Value);
        //</Snippet20>
        //<Snippet21>
        TokenImpersonationLevel token = windowsIdentity.ImpersonationLevel;
        Console.WriteLine("The impersonation level for the current user is : " + token.ToString());
        //</Snippet21>
    }

    // Retrieve the account token from the current WindowsIdentity object
    // instead of calling the unmanaged LogonUser method in the advapi32.dll.
    private static IntPtr LogonUser()
    {
        //<Snippet13>
        //<Snippet14>
        IntPtr accountToken = WindowsIdentity.GetCurrent().Token;
        Console.WriteLine( "Token number is: " + accountToken.ToString());
        //</Snippet14>
        //</Snippet13>

        return accountToken;
    }

    // Get the WindowsIdentity object for an Anonymous user.
    private static void GetAnonymousUser()
    {
        // Retrieve a WindowsIdentity object that represents an anonymous
        // Windows user.
        //<Snippet15>
        WindowsIdentity windowsIdentity = WindowsIdentity.GetAnonymous();
        //</Snippet15>
    }

    // Impersonate a Windows identity.
    //<Snippet16>
    private static void ImpersonateIdentity(IntPtr logonToken)
    {
        // Retrieve the Windows identity using the specified token.
        WindowsIdentity windowsIdentity = new WindowsIdentity(logonToken);

        // Create a WindowsImpersonationContext object by impersonating the
        // Windows identity.
        WindowsImpersonationContext impersonationContext =
            windowsIdentity.Impersonate();

        Console.WriteLine("Name of the identity after impersonation: "
            + WindowsIdentity.GetCurrent().Name + ".");
        Console.WriteLine(windowsIdentity.ImpersonationLevel);
        // Stop impersonating the user.
        impersonationContext.Undo();

        // Check the identity name.
        Console.Write("Name of the identity after performing an Undo on the");
        Console.WriteLine(" impersonation: " +
            WindowsIdentity.GetCurrent().Name);
    }
    //</Snippet16>
}

//</Snippet1>