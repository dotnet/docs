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

        // Add a rule that grants the current user the right
        // to read and enumerate the name/value pairs in a key, 
        // to read its access and audit rules, to enumerate
        // its subkeys, to create subkeys, and to delete the key. 
        // The rule is inherited by all contained subkeys.
        //
        RegistryAccessRule rule = new RegistryAccessRule(user, 
            RegistryRights.ReadKey | RegistryRights.WriteKey
                | RegistryRights.Delete, 
            InheritanceFlags.ContainerInherit, 
            PropagationFlags.None, 
            AccessControlType.Allow);
        mSec.AddAccessRule(rule);

        // Add a rule that allows the current user the right
        // right to set the name/value pairs in a key. 
        // This rule is inherited by contained subkeys, but
        // propagation flags limit it to immediate child 
        // subkeys.
        rule = new RegistryAccessRule(user, 
            RegistryRights.ChangePermissions,
            InheritanceFlags.ContainerInherit,
            PropagationFlags.InheritOnly | PropagationFlags.NoPropagateInherit, 
            AccessControlType.Allow);
        mSec.AddAccessRule(rule);

        // Add a rule that denies the current user the right
        // to set the name/value pairs in a key. This rule
        // has no inheritance or propagation flags, so it 
        // affects only the key itself.
        rule = new RegistryAccessRule(user,
            RegistryRights.SetValue,
            AccessControlType.Deny);
        mSec.AddAccessRule(rule);

        // Display the rules in the security object.
        ShowSecurity(mSec);

        // Create a rule that allows the current user the 
        // right to change the ownership of the key, with
        // no inheritance or propagation flags. The rights
        // and flags are ignored by RemoveAccessRuleAll,
        // and all rules that allow access for the current
        // user are removed.
        rule = new RegistryAccessRule(user, 
            RegistryRights.TakeOwnership, 
            AccessControlType.Allow);
        mSec.RemoveAccessRuleAll(rule);

        // Show that all rules that allow access have been 
        // removed.
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
        Type: Deny
      Rights: SetValue
 Inheritance: None
 Propagation: None
   Inherited? False

        User: TestDomain\TestUser
        Type: Allow
      Rights: SetValue, CreateSubKey, Delete, ReadKey
 Inheritance: ContainerInherit
 Propagation: None
   Inherited? False

        User: TestDomain\TestUser
        Type: Allow
      Rights: ChangePermissions
 Inheritance: ContainerInherit
 Propagation: NoPropagateInherit, InheritOnly
   Inherited? False


Current access rules:

        User: TestDomain\TestUser
        Type: Deny
      Rights: SetValue
 Inheritance: None
 Propagation: None
   Inherited? False

*/
//</Snippet1>



