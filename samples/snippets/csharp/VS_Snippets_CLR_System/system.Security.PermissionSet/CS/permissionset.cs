//<Snippet1>
// This sample demonstrates the use of the PermissionSet class.

using System;
using System.Reflection;
using System.Security.Permissions;
using System.Security;
using System.IO;
using System.Collections;

class MyClass
{
    public static void PermissionSetDemo()
    {
        Console.WriteLine("Executing PermissionSetDemo");
        try
        {
            //<Snippet2>
            // Open a new PermissionSet.
            PermissionSet ps1 = new PermissionSet(PermissionState.None);
            Console.WriteLine("Adding permission to open a file from a file dialog box.");
            //<Snippet3>
            // Add a permission to the permission set.
            ps1.AddPermission(
                new FileDialogPermission(FileDialogPermissionAccess.Open));
            //</Snippet3>
            Console.WriteLine("Demanding permission to open a file.");
            ps1.Demand();
            Console.WriteLine("Demand succeeded.");
            //</Snippet2>
            Console.WriteLine("Adding permission to save a file from a file dialog box.");
            ps1.AddPermission(
                new FileDialogPermission(FileDialogPermissionAccess.Save));
            Console.WriteLine("Demanding permission to open and save a file.");
            ps1.Demand();
            Console.WriteLine("Demand succeeded.");
            Console.WriteLine("Adding permission to read environment variable USERNAME.");
            ps1.AddPermission(
                new EnvironmentPermission(EnvironmentPermissionAccess.Read, "USERNAME"));
            ps1.Demand();
            Console.WriteLine("Demand succeeded.");
            Console.WriteLine("Adding permission to read environment variable COMPUTERNAME.");
            ps1.AddPermission(
                new EnvironmentPermission(EnvironmentPermissionAccess.Read, "COMPUTERNAME"));
            //<Snippet4>
            // Demand all the permissions in the set.
            Console.WriteLine("Demand all permissions.");
            ps1.Demand();
            //</Snippet4>
            Console.WriteLine("Demand succeeded.");
            //<Snippet5>
            // Display the number of permissions in the set.
            Console.WriteLine("Number of permissions = " + ps1.Count);
            //</Snippet5>
            //<Snippet6>
            // Display the value of the IsSynchronized property.
            Console.WriteLine("IsSynchronized property = " + ps1.IsSynchronized);
            //</Snippet6>
            //<Snippet7>
            // Display the value of the IsReadOnly property.
            Console.WriteLine("IsReadOnly property = " + ps1.IsReadOnly);
            //</Snippet7>
            //<Snippet8>
            // Display the value of the SyncRoot property.
            Console.WriteLine("SyncRoot property = " + ps1.SyncRoot);
            //</Snippet8>
            //<Snippet9>
            // Display the result of a call to the ContainsNonCodeAccessPermissions method.
            // Gets a value indicating whether the PermissionSet contains permissions
            // that are not derived from CodeAccessPermission.
            // Returns true if the PermissionSet contains permissions that are not
            // derived from CodeAccessPermission; otherwise, false.
            Console.WriteLine("ContainsNonCodeAccessPermissions method returned " +
                ps1.ContainsNonCodeAccessPermissions());
            //</Snippet9>
            //<Snippet10>
            Console.WriteLine("Value of the permission set ToString = \n" + ps1.ToString());
            //</Snippet10>
            PermissionSet ps2 = new PermissionSet(PermissionState.None);
            //<Snippet11>
            // Create a second permission set and compare it to the first permission set.
            ps2.AddPermission(
                new EnvironmentPermission(EnvironmentPermissionAccess.Read, "USERNAME"));
            ps2.AddPermission(
                new EnvironmentPermission(EnvironmentPermissionAccess.Write, "COMPUTERNAME"));
            IEnumerator list =  ps1.GetEnumerator();
            Console.WriteLine("Permissions in first permission set:");
            while (list.MoveNext())
                Console.WriteLine(list.Current.ToString());
            Console.WriteLine("Second permission IsSubsetOf first permission = " + ps2.IsSubsetOf(ps1));
            //</Snippet11>
            //<Snippet12>
            // Display the intersection of two permission sets.
            PermissionSet ps3 = ps2.Intersect(ps1);
            Console.WriteLine("The intersection of the first permission set and "
                + "the second permission set = " + ps3.ToString());
            //</Snippet12>
            // Create a new permission set.
            PermissionSet ps4 = new PermissionSet(PermissionState.None);
            ps4.AddPermission(
                new FileIOPermission(FileIOPermissionAccess.Read,
                "C:\\Temp\\Testfile.txt"));
            ps4.AddPermission(
                new FileIOPermission(FileIOPermissionAccess.Read |
                FileIOPermissionAccess.Write | FileIOPermissionAccess.Append,
                "C:\\Temp\\Testfile.txt"));
            //<Snippet13>
            // Display the union of two permission sets.
            PermissionSet ps5 = ps3.Union(ps4);
            Console.WriteLine("The union of permission set 3 and permission set 4 = "
                + ps5.ToString());
            //</Snippet13>
            //<Snippet15>
            // Remove FileIOPermission from the permission set.
            ps5.RemovePermission(typeof(FileIOPermission));
            Console.WriteLine("The last permission set after removing FileIOPermission = "
                + ps5.ToString());
            //</Snippet15>
            //<Snippet16>
            // Change the permission set using SetPermission.
            ps5.SetPermission(new EnvironmentPermission(EnvironmentPermissionAccess.AllAccess, "USERNAME"));
            Console.WriteLine("Permission set after SetPermission = " + ps5.ToString());
            //</Snippet16>
            //<Snippet17>
            // Display result of ToXml and FromXml operations.
            PermissionSet ps6 = new PermissionSet(PermissionState.None);
            ps6.FromXml(ps5.ToXml());
            Console.WriteLine("Result of ToFromXml = " + ps6.ToString() + "\n");
            //</Snippet17>
            //<Snippet18>
            // Display results of PermissionSet.GetEnumerator.
            IEnumerator psEnumerator = ps1.GetEnumerator();
            while (psEnumerator.MoveNext())
            {
                Console.WriteLine(psEnumerator.Current);
            }
            //</Snippet18>
            //<Snippet19>
            // Check for an unrestricted permission set.
            PermissionSet ps7 = new PermissionSet(PermissionState.Unrestricted);
            Console.WriteLine("Permission set is unrestricted = " + ps7.IsUnrestricted());
            //</Snippet19>
            //<Snippet20>
            // Create and display a copy of a permission set.
            ps7 = ps5.Copy();
            Console.WriteLine("Result of copy = " + ps7.ToString());
            //</Snippet20>
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message.ToString());
        }

    }


    static void Main(string[] args)
    {
        PermissionSetDemo();
    }

}
//</Snippet1>
