//<Snippet1>
using System;
using System.Reflection;
using System.Security;
using System.Security.AccessControl;
using Microsoft.Win32;

public class Example
{
    public static void Main()
    {
        // Delete the example key if it exists.
        try
        {
            Registry.CurrentUser.DeleteSubKey("RegistryRightsExample");
            Console.WriteLine("Example key has been deleted.");
        }
        catch (ArgumentException)
        {
            // ArgumentException is thrown if the key does not exist. In
            // this case, there is no reason to display a message.
        }
        catch (Exception ex)
        {
            Console.WriteLine("Unable to delete the example key: {0}", ex);
            return;
        }

        string user = Environment.UserDomainName + "\\" + Environment.UserName;

        RegistrySecurity rs = new RegistrySecurity();

        // Allow the current user to read and delete the key.
        //
        rs.AddAccessRule(new RegistryAccessRule(user, 
            RegistryRights.ReadKey | RegistryRights.Delete, 
            InheritanceFlags.None, 
            PropagationFlags.None, 
            AccessControlType.Allow));

        // Prevent the current user from writing or changing the
        // permission set of the key. Note that if Delete permission
        // were not allowed in the previous access rule, denying
        // WriteKey permission would prevent the user from deleting the 
        // key.
        rs.AddAccessRule(new RegistryAccessRule(user, 
            RegistryRights.WriteKey | RegistryRights.ChangePermissions, 
            InheritanceFlags.None, 
            PropagationFlags.None, 
            AccessControlType.Deny));

        // Create the example key with registry security.
        RegistryKey rk = null;
        try
        {
            rk = Registry.CurrentUser.CreateSubKey("RegistryRightsExample", 
                RegistryKeyPermissionCheck.Default, rs);
            Console.WriteLine("\r\nExample key created.");
            rk.SetValue("ValueName", "StringValue");
        }
        catch (Exception ex)
        {
            Console.WriteLine("\r\nUnable to create the example key: {0}", ex);
        }
        if (rk != null) rk.Close();

        rk = Registry.CurrentUser;

        RegistryKey rk2;
        
        // Open the key with read access.
        rk2 = rk.OpenSubKey("RegistryRightsExample", false);
        Console.WriteLine("\r\nRetrieved value: {0}", rk2.GetValue("ValueName"));
        rk2.Close();

        // Attempt to open the key with write access.
        try
        {
            rk2 = rk.OpenSubKey("RegistryRightsExample", true);
        }
        catch (SecurityException ex)
        {
            Console.WriteLine("\nUnable to write to the example key." +
                " Caught SecurityException: {0}", ex.Message);
        }
        if (rk2 != null) rk2.Close();

        // Attempt to change permissions for the key.
        try
        {
            rs = new RegistrySecurity();
            rs.AddAccessRule(new RegistryAccessRule(user, 
                RegistryRights.WriteKey, 
                InheritanceFlags.None, 
                PropagationFlags.None, 
                AccessControlType.Allow));
            rk2 = rk.OpenSubKey("RegistryRightsExample", false);
            rk2.SetAccessControl(rs);
            Console.WriteLine("\r\nExample key permissions were changed.");
        }
        catch (UnauthorizedAccessException ex)
        {
            Console.WriteLine("\nUnable to change permissions for the example key." +
                " Caught UnauthorizedAccessException: {0}", ex.Message);
        }
        if (rk2 != null) rk2.Close();

        Console.WriteLine("\r\nPress Enter to delete the example key.");
        Console.ReadLine();

        try
        {
            rk.DeleteSubKey("RegistryRightsExample");
            Console.WriteLine("Example key was deleted.");
        }
        catch(Exception ex)
        {
            Console.WriteLine("Unable to delete the example key: {0}", ex);
        }

        rk.Close();
    }
}

/* This code example produces the following output:

Example key created.

Retrieved value: StringValue

Unable to write to the example key. Caught SecurityException: Requested registry access is not allowed.

Unable to change permissions for the example key. Caught UnauthorizedAccessException: Cannot write to the registry key.

Press Enter to delete the example key.

Example key was deleted.
 */
//</Snippet1>

