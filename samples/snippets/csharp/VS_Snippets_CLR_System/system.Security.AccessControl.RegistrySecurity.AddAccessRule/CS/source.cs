//<Snippet1>
using System;
using Microsoft.Win32;
using System.Security.AccessControl;
using System.Security.Principal;

public class Example
{
    public static void Main()
    {
        // Create a string representing the current user.
        string user = Environment.UserDomainName + "\\"
            + Environment.UserName;

        // Create a security object that grants no access.
        RegistrySecurity mSec = new RegistrySecurity();

        // Add a rule that grants the current user the 
        // right to read the key.
        RegistryAccessRule rule = new RegistryAccessRule(user, 
            RegistryRights.ReadKey, 
            AccessControlType.Allow);
        mSec.AddAccessRule(rule);

        // Add a rule that denies the current user the 
        // right to change permissions on the Registry.
        rule = new RegistryAccessRule(user, 
            RegistryRights.ChangePermissions, 
            AccessControlType.Deny);
        mSec.AddAccessRule(rule);

        // Display the rules in the security object.
        ShowSecurity(mSec);

        // Add a rule that allows the current user the 
        // right to read permissions on the Registry. This 
        // rule is merged with the existing Allow rule.
        rule = new RegistryAccessRule(user, 
            RegistryRights.WriteKey, 
            AccessControlType.Allow);
        mSec.AddAccessRule(rule);

        ShowSecurity(mSec);
    }

    private static void ShowSecurity(RegistrySecurity security)
    {
        Console.WriteLine("\r\nCurrent access rules:\r\n");

        foreach( RegistryAccessRule ar in 
            security.GetAccessRules(true, true, typeof(NTAccount)) )
        {
            Console.WriteLine("        User: {0}", ar.IdentityReference);
            Console.WriteLine("        Type: {0}", ar.AccessControlType);
            Console.WriteLine("      Rights: {0}", ar.RegistryRights);
            Console.WriteLine();
        }
    }
}

/* This code example produces output similar to following:

Current access rules:

        User: TestDomain\TestUser
        Type: Deny
      Rights: ChangePermissions

        User: TestDomain\TestUser
        Type: Allow
      Rights: ReadKey


Current access rules:

        User: TestDomain\TestUser
        Type: Deny
      Rights: ChangePermissions

        User: TestDomain\TestUser
        Type: Allow
      Rights: SetValue, CreateSubKey, ReadKey
 */
//</Snippet1>



