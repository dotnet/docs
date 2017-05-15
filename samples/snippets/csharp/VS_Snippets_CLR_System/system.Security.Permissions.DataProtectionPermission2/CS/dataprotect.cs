//<Snippet1>
using System;
using System.Security.Permissions;
using System.Security.Cryptography;
using System.Security;
using System.IO;

public class DataProtect
{
    // Create a byte array for additional entropy when using the
    // Protect and Unprotect methods.
    static byte[] s_aditionalEntropy = { 9, 8, 7, 6, 5 };

    private static byte[] encryptedSecret;
    private static byte[] originalData;
    public static void Main(string[] args)
    {
        //<Snippet2>
        Console.WriteLine("Creating a permission with the Flags property =" +
            " ProtectData.");
        DataProtectionPermission sp = new DataProtectionPermission(
            DataProtectionPermissionFlags.ProtectData);
        sp.PermitOnly();
        //</Snippet2>

        // Protect the data
        ProtectData();
        // This should fail without the correct permission
        UnprotectData();
        // Revert the permission that limited access
        CodeAccessPermission.RevertPermitOnly();

        // This should now work.
        UnprotectData();
        // Demonstrate the behavior of the class members.
        ShowMembers();

        Console.WriteLine("Press the Enter key to exit.");
        Console.ReadKey();
        return;
    }

    // The following method is intended to demonstrate only the behavior of
    // DataProtectionPermission class members,and not their practical usage.
    // Most properties and methods in this class are used for the resolution
    // and enforcement of security policy by the security infrastructure code.
    private static void ShowMembers()
    {
        Console.WriteLine("Creating four DataProtectionPermissions");
        Console.WriteLine("Creating the first permission with the Flags " +
            "property = ProtectData.");
        DataProtectionPermission sp1 = new DataProtectionPermission(
            DataProtectionPermissionFlags.ProtectData);

        Console.WriteLine("Creating the second permission with the Flags " +
            "property = AllFlags.");

        DataProtectionPermission sp2 = new DataProtectionPermission(
            DataProtectionPermissionFlags.AllFlags);

        Console.WriteLine("Creating the third permission with a permission " +
            "state = Unrestricted.");
        //<Snippet9>
        DataProtectionPermission sp3 = new DataProtectionPermission(
            PermissionState.Unrestricted);
        //</Snippet9>
        Console.WriteLine("Creating the fourth permission with a permission" +
            " state = None.");

        DataProtectionPermission sp4 = new DataProtectionPermission(
            PermissionState.None);
        //<Snippet3>
        bool rc = sp2.IsSubsetOf(sp3);
        Console.WriteLine("Is the permission with all flags set (AllFlags) " +
            "a subset of \n \tthe permission with an Unrestricted " +
            "permission state? " + (rc ? "Yes" : "No"));
        rc = sp1.IsSubsetOf(sp2);
        Console.WriteLine("Is the permission with ProtectData access a " +
            "subset of the permission with \n" + "\tAllFlags set? " +
            (rc ? "Yes" : "No"));
        //</Snippet3>
        //<Snippet4>
        rc = sp3.IsUnrestricted();
        Console.WriteLine("Is the third permission unrestricted? " +
            (rc ? "Yes" : "No"));
        //</Snippet4>
        //<Snippet5>
        Console.WriteLine("Copying the second permission to the fourth " +
            "permission.");
        sp4 = (DataProtectionPermission)sp2.Copy();
        rc = sp4.Equals(sp2);
        Console.WriteLine("Is the fourth permission equal to the second " +
            "permission? " + (rc ? "Yes" : "No"));
        //</Snippet5>
        //<Snippet10>
        Console.WriteLine("Creating the intersection of the second and " +
            "first permissions.");
        sp4 = (DataProtectionPermission)sp2.Intersect(sp1);
        Console.WriteLine("The value of the Flags property is: " +
            sp4.Flags.ToString());
        //</Snippet10>
        //<Snippet6>
        Console.WriteLine("Creating the union of the second and first " +
            "permissions.");
        sp4 = (DataProtectionPermission)sp2.Union(sp1);
        Console.WriteLine("Result of the union of the second permission " +
            "with the first: " + sp4.Flags);
        //</Snippet6>
        //<Snippet7>
        Console.WriteLine("Using an XML round trip to reset the fourth " +
            "permission.");
        sp4.FromXml(sp2.ToXml());
        rc = sp4.Equals(sp2);
        Console.WriteLine("Does the XML round trip result equal the " +
            "original permission? " + (rc ? "Yes" : "No"));
        //</Snippet7>
    }

    // Create a simple byte array containing data to be encrypted.
    public static void ProtectData()
    {
        byte[] secret = { 0, 1, 2, 3, 4, 1, 2, 3, 4 };

        //Encrypt the data.
        encryptedSecret = Protect(secret);
        Console.WriteLine("The encrypted byte array is:");
        if (encryptedSecret != null)
            PrintValues(encryptedSecret);

    }

    // Decrypt the data and store in a byte array.
    public static void UnprotectData()
    {
        originalData = Unprotect(encryptedSecret);
        if (originalData != null)
        {
            Console.WriteLine("\r\nThe original data is:");
            PrintValues(originalData);
        }
    }

    // Encrypt data in the specified byte array.
    public static byte[] Protect(byte[] data)
    {
        try
        {
            // Encrypt the data using DataProtectionScope.CurrentUser.
            // The result can be decrypted only by the user who encrypted
            // the data.
            return ProtectedData.Protect(
                data,
                s_aditionalEntropy,
                DataProtectionScope.CurrentUser);
        }
        catch (CryptographicException e)
        {
            Console.WriteLine("Data was not encrypted. " +
                "An error has occurred.");
            Console.WriteLine(e.ToString());
            return null;
        }
        catch (SecurityException e)
        {
            Console.WriteLine("Insufficient permissions. " +
                "An error has occurred.");
            Console.WriteLine(e.ToString());
            return null;
        }
    }

    // Decrypt data in the specified byte array.
    public static byte[] Unprotect(byte[] data)
    {
        try
        {
            //Decrypt the data using DataProtectionScope.CurrentUser.
            return ProtectedData.Unprotect(
                data,
                s_aditionalEntropy,
                DataProtectionScope.CurrentUser);
        }
        catch (CryptographicException e)
        {
            Console.WriteLine("Data was not decrypted. " +
                "An error has occurred.");
            Console.WriteLine(e.ToString());
            return null;
        }
        catch (SecurityException e)
        {
            Console.WriteLine("Insufficient permissions. " +
                "An error has occurred.");
            Console.WriteLine(e.ToString());
            return null;
        }
    }

    public static void PrintValues(Byte[] myArr)
    {
        foreach (Byte i in myArr)
        {
            Console.Write("\t{0}", i);
        }
        Console.WriteLine();
    }


}

//</Snippet1>