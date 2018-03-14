// <Snippet1>
// This sample demonstrates the IsSubsetOf, Union, Intersect, Copy, ToXml, FromXml
// GetPathList, AddPathList, and SetPathList methods
// of the RegistryPermission class.


using System;
using System.Security;
using System.Security.Permissions;
using System.Collections;

[assembly: CLSCompliant(true)]

public class RegistryPermissionDemo
{
    private static RegistryPermission readPerm1 = new RegistryPermission(RegistryPermissionAccess.Read,
        "HKEY_LOCAL_MACHINE\\HARDWARE\\DESCRIPTION\\System\\CentralProcessor\\0");
    private static RegistryPermission readPerm2 = new RegistryPermission(RegistryPermissionAccess.Read,
       "HKEY_LOCAL_MACHINE\\HARDWARE\\DESCRIPTION");
    private static RegistryPermission readPerm3 = new RegistryPermission(RegistryPermissionAccess.Read,
    "HKEY_LOCAL_MACHINE\\HARDWARE\\DESCRIPTION\\System\\FloatingPointProcessor\\0");
    private static RegistryPermission createPerm1 = new RegistryPermission(RegistryPermissionAccess.Create,
        "HKEY_LOCAL_MACHINE\\HARDWARE\\DESCRIPTION\\System\\CentralProcessor\\0");
    private static IPermission readPerm4;

    public static void Main(String[] args)
    {
        IsSubsetOfDemo();
        UnionDemo();
        IntersectDemo();
        CopyDemo();
        ToFromXmlDemo();
        SetGetPathListDemo();
    }

    //<Snippet2>
    // IsSubsetOf determines whether the current permission is a subset of the specified permission.
    private static bool IsSubsetOfDemo()
    {

        bool returnValue = true;

        if (readPerm1.IsSubsetOf(readPerm2))
        {

            Console.WriteLine(readPerm1.GetPathList(RegistryPermissionAccess.Read) +
                "\n is a subset of " + readPerm2.GetPathList(RegistryPermissionAccess.Read) + "\n");
        }
        else
        {
            Console.WriteLine(readPerm1.GetPathList(RegistryPermissionAccess.Read) +
                "\n is not a subset of " + readPerm2.GetPathList(RegistryPermissionAccess.Read) + "\n");
        }
        if (createPerm1.IsSubsetOf(readPerm1))
        {

            Console.WriteLine("RegistryPermissionAccess.Create" +
                "\n is a subset of " + "RegistryPermissionAccess.Read" + "\n");
        }
        else
        {
            Console.WriteLine("RegistryPermissionAccess.Create" +
                "\n is not a subset of " + "RegistryPermissionAccess.Read" + "\n");
        }

        return returnValue;
    }
    //</Snippet2>
    //<Snippet3>
    // Union creates a new permission that is the union of the current permission and
    // the specified permission.
    private static bool UnionDemo()
    {

        bool returnValue = true;
        readPerm3 = (RegistryPermission)readPerm1.Union(readPerm2);

        if (readPerm3 == null)
        {
            Console.WriteLine("The union of \n" +
                readPerm1.GetPathList(RegistryPermissionAccess.Read) + " \nand "
                + readPerm2.GetPathList(RegistryPermissionAccess.Read) + " is null.");
        }
        else
        {
            Console.WriteLine("The union of \n" + readPerm1.GetPathList(RegistryPermissionAccess.Read) +
                " \nand " + readPerm2.GetPathList(RegistryPermissionAccess.Read) + " = \n\t"
                + ((RegistryPermission)readPerm3).GetPathList(RegistryPermissionAccess.Read).ToString());
        }

        return returnValue;

    }
    //</Snippet3>
    //<Snippet4>
    // Intersect creates and returns a new permission that is the intersection of the
    // current permission and the permission specified.
    private static bool IntersectDemo()
    {

        bool returnValue = true;

        readPerm3 = (RegistryPermission)readPerm1.Intersect(readPerm2);
        if (readPerm3 != null && readPerm3.GetPathList(RegistryPermissionAccess.Read) != null)
        {

            Console.WriteLine("The intersection of \n" + readPerm1.GetPathList(RegistryPermissionAccess.Read)
                + " \nand " + readPerm2.GetPathList(RegistryPermissionAccess.Read) + " = \n\t"
                + ((RegistryPermission)readPerm3).GetPathList(RegistryPermissionAccess.Read).ToString());
        }
        else
        {
            Console.WriteLine("The intersection of \n" + readPerm2.GetPathList(RegistryPermissionAccess.Read)
                + " \nand " + readPerm2.GetPathList(RegistryPermissionAccess.Read) + " is null. ");
        }

        return returnValue;

    }
    //</Snippet4>
    //<Snippet5>
    //Copy creates and returns an identical copy of the current permission.
    private static bool CopyDemo()
    {

        bool returnValue = true;
        readPerm4 = (RegistryPermission)readPerm1.Copy();
        if (readPerm4 != null)
        {
            Console.WriteLine("Result of copy = " + readPerm4.ToString() + "\n");
        }
        else
        {
            Console.WriteLine("Result of copy is null. \n");
        }
        return returnValue;
    }
    //</Snippet5>
    //<Snippet6>
    // ToXml creates an XML encoding of the permission and its current state; FromXml
    // reconstructs a permission with the specified state from the XML encoding.
    private static bool ToFromXmlDemo()
    {

        bool returnValue = true;
        //<Snippet7>
        readPerm2 = new RegistryPermission(PermissionState.None);
        readPerm2.FromXml(readPerm1.ToXml());
        Console.WriteLine("Result of ToFromXml = " + readPerm2.ToString() + "\n");
        //</Snippet7>
        return returnValue;

    }
    //</Snippet6>
    //<Snippet9> 
    // AddPathList adds access for the specified registry variables to the existing state of the permission.
    // SetPathList sets new access for the specified registry variable names to the existing state of the permission.
    // GetPathList gets paths for all registry variables with the specified RegistryPermissionAccess.
    private static bool SetGetPathListDemo()
    {
        try
        {
            Console.WriteLine("********************************************************\n");
            //<Snippet10>
            RegistryPermission readPerm1;
            Console.WriteLine("Creating RegistryPermission with AllAccess rights for 'HKEY_LOCAL_MACHINE\\HARDWARE\\DESCRIPTION\\System\\CentralProcessor\\0'");
            readPerm1 = new RegistryPermission(RegistryPermissionAccess.AllAccess, "HKEY_LOCAL_MACHINE\\HARDWARE\\DESCRIPTION\\System\\CentralProcessor\\0");
            //</Snippet10>
            Console.WriteLine("Adding 'HKEY_LOCAL_MACHINE\\HARDWARE\\DESCRIPTION' to the write access list, "
                + "and \n 'HKEY_LOCAL_MACHINE\\HARDWARE\\DESCRIPTION\\System\\FloatingPointProcessor\\0' "
                + "to the read access list.");
            readPerm1.AddPathList(RegistryPermissionAccess.Write, "HKEY_LOCAL_MACHINE\\HARDWARE\\DESCRIPTION");
            readPerm1.AddPathList(RegistryPermissionAccess.Read,
                "HKEY_LOCAL_MACHINE\\HARDWARE\\DESCRIPTION\\System\\FloatingPointProcessor\\0");
            Console.WriteLine("Read access list before SetPathList = " +
                readPerm1.GetPathList(RegistryPermissionAccess.Read));
            Console.WriteLine("Setting read access rights to \n'HKEY_LOCAL_MACHINE\\HARDWARE\\DESCRIPTION\\System\\CentralProcessor\\0'");
            readPerm1.SetPathList(RegistryPermissionAccess.Read,
                "HKEY_LOCAL_MACHINE\\HARDWARE\\DESCRIPTION\\System\\CentralProcessor\\0");
            Console.WriteLine("Read access list after SetPathList = \n" +
                readPerm1.GetPathList(RegistryPermissionAccess.Read));
            Console.WriteLine("Write access = \n" +
                readPerm1.GetPathList(RegistryPermissionAccess.Write));
            Console.WriteLine("Write access Registry variables = \n" +
                readPerm1.GetPathList(RegistryPermissionAccess.AllAccess));
        }
        catch (ArgumentException e)
        {
            // RegistryPermissionAccess.AllAccess can not be used as a parameter for GetPathList.
            Console.WriteLine("An ArgumentException occured as a result of using AllAccess. "
                + "AllAccess cannot be used as a parameter in GetPathList because it represents more than one "
                + "type of registry variable access : \n" + e);
        }

        return true;
    }
    //</Snippet9>
}

//</Snippet1>
