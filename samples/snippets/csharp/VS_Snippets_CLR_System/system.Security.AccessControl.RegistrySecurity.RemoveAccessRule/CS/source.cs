// Created by REDMOND\glennha
//<Snippet1>

using System;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Security;
using Microsoft.Win32;

public class Example
{

    public static void Main()
    {

        string user = Environment.UserDomainName + "\\"
            + Environment.UserName;

        // Create a security object that grants no access.
        RegistrySecurity mSec = new RegistrySecurity();

        // Add a rule that grants the current user ReadKey
        // rights. ReadKey is a combination of four other 
        // rights. The rule is inherited by all 
        // contained subkeys.
        RegistryAccessRule rule = new RegistryAccessRule(user, 
            RegistryRights.ReadKey, 
            InheritanceFlags.ContainerInherit, 
            PropagationFlags.None, 
            AccessControlType.Allow);
        mSec.AddAccessRule(rule);

        // Create a rule that allows the current user only the 
        // right to query the key/value pairs of a key, using  
        // the same inheritance and propagation flags as the
        // first rule. QueryValues is a constituent of 
        // ReadKey, so when this rule is removed, using the 
        // RemoveAccessRule method, ReadKey is broken into
        // its constituent parts.
        rule = new RegistryAccessRule(user, 
            RegistryRights.QueryValues, 
            InheritanceFlags.ContainerInherit, 
            PropagationFlags.None, 
            AccessControlType.Allow);
        mSec.RemoveAccessRule(rule);

        // Display the rules in the security object.
        ShowSecurity(mSec);

        // Add the second rule back. It merges with the 
        // existing rule, so that the rule is now displayed
        // as ReadKey.
        mSec.AddAccessRule(rule);

        // Display the rules in the security object.
        ShowSecurity(mSec);
    }

    private static void ShowSecurity(RegistrySecurity security)
    {
        Console.WriteLine("\r\nCurrent access rules:\r\n");

        foreach( RegistryAccessRule ar in security.GetAccessRules(true, true, typeof(NTAccount)) )
        {
            Console.WriteLine("        User: {0}", ar.IdentityReference);
            Console.WriteLine("        Type: {0}", ar.AccessControlType);
            Console.WriteLine("      Rights: {0}", ar.RegistryRights);
            Console.WriteLine(" Inheritance: {0}", ar.InheritanceFlags);
            Console.WriteLine(" Propagation: {0}", ar.PropagationFlags);
            Console.WriteLine("   Inherited? {0}", ar.IsInherited);
            Console.WriteLine();
        }
    }
}

/* This code example produces output similar to following:

Current access rules:

        User: TestDomain\TestUser
        Type: Allow
      Rights: EnumerateSubKeys, Notify, ReadPermissions
 Inheritance: ContainerInherit
 Propagation: None
   Inherited? False


Current access rules:

        User: TestDomain\TestUser
        Type: Allow
      Rights: ReadKey
 Inheritance: ContainerInherit
 Propagation: None
   Inherited? False
 */
//</Snippet1>



