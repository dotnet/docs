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
        const string TestKey = "TestKey3927";
        RegistryKey cu = Registry.CurrentUser;

        string user = Environment.UserDomainName + 
            "\\" + Environment.UserName;

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
           AccessControlType.Allow
        );
        mSec.AddAccessRule(rule);

        // Add a rule that allows the current user the right
        // right to set the name/value pairs in a key. 
        // This rule is inherited by contained subkeys, but
        // propagation flags limit it to immediate child 
        // subkeys.
        rule = new RegistryAccessRule(user, 
            RegistryRights.ChangePermissions, 
            InheritanceFlags.ContainerInherit, 
            PropagationFlags.InheritOnly | 
                PropagationFlags.NoPropagateInherit, 
            AccessControlType.Allow);
        mSec.AddAccessRule(rule);

        // Display the rules in the security object.
        ShowSecurity(mSec);

        // Create the test key using the security object.
        //
        RegistryKey rk = cu.CreateSubKey(TestKey, 
            RegistryKeyPermissionCheck.ReadWriteSubTree, mSec);

        // Create a child subkey and a grandchild subkey, 
        // without security.
        RegistryKey rkChild = rk.CreateSubKey("ChildKey", 
            RegistryKeyPermissionCheck.ReadWriteSubTree);
        RegistryKey rkGrandChild = 
            rkChild.CreateSubKey("GrandChildKey", 
                RegistryKeyPermissionCheck.ReadWriteSubTree);

        Show(rk);
        Show(rkChild);
        Show(rkGrandChild);

        rkGrandChild.Close();
        rkChild.Close();
        rk.Close();

        cu.DeleteSubKeyTree(TestKey);
    }

    private static void Show(RegistryKey rk)
    {
        Console.WriteLine(rk.Name);
        ShowSecurity(rk.GetAccessControl());
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

HKEY_CURRENT_USER\TestKey3927

Current access rules:

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

HKEY_CURRENT_USER\TestKey3927\ChildKey

Current access rules:

        User: TestDomain\TestUser
        Type: Allow
      Rights: SetValue, CreateSubKey, Delete, ReadKey
 Inheritance: ContainerInherit
 Propagation: None
   Inherited? True

        User: TestDomain\TestUser
        Type: Allow
      Rights: ChangePermissions
 Inheritance: None
 Propagation: None
   Inherited? True

HKEY_CURRENT_USER\TestKey3927\ChildKey\GrandChildKey

Current access rules:

        User: TestDomain\TestUser
        Type: Allow
      Rights: SetValue, CreateSubKey, Delete, ReadKey
 Inheritance: ContainerInherit
 Propagation: None
   Inherited? True
 */
//</Snippet1>



