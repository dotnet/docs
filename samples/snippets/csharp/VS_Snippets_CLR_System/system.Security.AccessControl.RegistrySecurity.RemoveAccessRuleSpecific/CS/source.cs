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
        RegistryAccessRule rule1 = new RegistryAccessRule(user, 
            RegistryRights.ReadKey | RegistryRights.WriteKey
                | RegistryRights.Delete, 
            InheritanceFlags.ContainerInherit, 
            PropagationFlags.None, 
            AccessControlType.Allow);
        mSec.AddAccessRule(rule1);

        // Add a rule that allows the current user the right
        // right to take ownership of a key, using the same 
        // inheritance and propagation flags. This rule 
        // merges with the first rule.
        RegistryAccessRule rule2 = new RegistryAccessRule(user, 
            RegistryRights.ChangePermissions, 
            InheritanceFlags.ContainerInherit,
            PropagationFlags.None, 
            AccessControlType.Allow);
        mSec.AddAccessRule(rule2);

        // Display the rules in the security object.
        ShowSecurity(mSec);

        // Attempt to use RemoveRuleSpecific to remove the
        // first rule. The removal fails, because the rule
        // in the RegistrySecurity object has been altered.
        mSec.RemoveAccessRuleSpecific(rule1);

        // Show that the rule was not removed.
        ShowSecurity(mSec);

        // Use the RemoveAccessRule method to remove rule2,
        // and then use RemoveAccessRuleSpecific to remove
        // rule1.
        mSec.RemoveAccessRule(rule2);
        mSec.RemoveAccessRuleSpecific(rule1);

        // Show that the rules have been removed.
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
        Type: Allow
      Rights: SetValue, CreateSubKey, Delete, ReadKey, ChangePermissions
 Inheritance: ContainerInherit
 Propagation: None
   Inherited? False


Current access rules:

        User: TestDomain\TestUser
        Type: Allow
      Rights: SetValue, CreateSubKey, Delete, ReadKey, ChangePermissions
 Inheritance: ContainerInherit
 Propagation: None
   Inherited? False


Current access rules:

*/
//</Snippet1>



