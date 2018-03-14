// This sample demonstrates the IsSubsetOf, Union, Intersect, Copy, ToXml and FromXml methods
// of the EnvironmentPermission class.
// <Snippet1>
using System;
using System.Security;
using System.Security.Permissions;
using System.Collections;

[assembly: CLSCompliant(true)]

public class EnvironmentPermissionDemo
{
    // IsSubsetOf determines whether the current permission is a subset of the specified permission.
    //<Snippet2>
    private bool IsSubsetOfDemo()
    {
        bool returnValue = true;
        EnvironmentPermission envPerm1 = new EnvironmentPermission(EnvironmentPermissionAccess.Read, "windir");
        EnvironmentPermission envPerm2 = new EnvironmentPermission(EnvironmentPermissionAccess.AllAccess, "TEMP");
        if (envPerm1.IsSubsetOf(envPerm2))
        {

            Console.WriteLine("'windir' is a subset of 'TEMP'\n");
        }
        else
        {
            Console.WriteLine("windir" + " is not a subset of "
                + "TEMP" + "\n");
        }
        envPerm1.SetPathList(EnvironmentPermissionAccess.Read, "TEMP");

        if (envPerm1.IsSubsetOf(envPerm2))
        {

            Console.WriteLine("Read access is a subset of AllAccess\n");
        }
        else
        {
            Console.WriteLine("Read access is not a subset of AllAccess\n");
        }

        return returnValue;
    }
    //</Snippet2>
    // Union creates a new permission that is the union of the current permission and the specified permission.
    //<Snippet3>
    private bool UnionDemo()
    {
        bool returnValue = true;
        IPermission envIdPerm3;
        EnvironmentPermission envPerm1 = new EnvironmentPermission(EnvironmentPermissionAccess.Read, "windir");
        EnvironmentPermission envPerm2 = new EnvironmentPermission(EnvironmentPermissionAccess.Read, "TEMP");
        envIdPerm3 = (EnvironmentPermission)envPerm1.Union(envPerm2);
        envIdPerm3 = envPerm1.Union(envPerm2);
        Console.WriteLine("The union of 'windir' and 'TEMP'" +
            " = " + ((EnvironmentPermission)envIdPerm3).GetPathList(EnvironmentPermissionAccess.Read).ToString());

        return returnValue;

    }
    //</Snippet3>
    // Intersect creates and returns a new permission that is the intersection of
    // the current permission and the permission specified.
    //<Snippet4>
    private bool IntersectDemo()
    {

        IPermission envIdPerm3;
        bool returnValue = true;
        EnvironmentPermission envPerm1 = new EnvironmentPermission(EnvironmentPermissionAccess.Read, "windir");
        EnvironmentPermission envPerm2 = new EnvironmentPermission(EnvironmentPermissionAccess.Read, "TEMP");
        try
        {
            envIdPerm3 = (EnvironmentPermission)envPerm1.Intersect(envPerm2);
            if (envIdPerm3 != null && ((EnvironmentPermission)envIdPerm3).GetPathList(EnvironmentPermissionAccess.Read) != null)
            {
                Console.WriteLine("The intersection of " + "windir" + " and " + "TEMP" +                    " = " + ((EnvironmentPermission)envIdPerm3).GetPathList(EnvironmentPermissionAccess.Read).ToString());
            }
            else
            {
                Console.WriteLine("The intersection of " + "windir" + " and "
                    + "TEMP" + " is null.");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("An exception was thrown for intersection : " + e);
            returnValue = false;
        }
    
        return returnValue;

    }
    //</Snippet4>
    //Copy creates and returns an identical copy of the current permission.
    //<Snippet5>
    private bool CopyDemo()
    {
        bool returnValue = true;
        //<Snippet9>
        EnvironmentPermission envPerm1 = new EnvironmentPermission(EnvironmentPermissionAccess.Read, "windir");
        //</Snippet9>
        try
        {
            EnvironmentPermission envPerm2 = (EnvironmentPermission)envPerm1.Copy();
            if (envPerm2 != null)
            {
                Console.WriteLine("Result of copy = " + envPerm2.ToString() + "\n");
            }
            else
            {
                Console.WriteLine("Result of copy is null. \n");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        return returnValue;
    }
    //</Snippet5>
    // ToXml creates an XML encoding of the permission and its current state; FromXml reconstructs
    // a permission with the specified state from the XML encoding.
    //<Snippet6>
    private bool ToFromXmlDemo()
    {
        bool returnValue = true;
        EnvironmentPermission envPerm1 = new EnvironmentPermission(EnvironmentPermissionAccess.Read, "windir");
        EnvironmentPermission envPerm2 = new EnvironmentPermission(PermissionState.None);
        envPerm2.FromXml(envPerm1.ToXml());
        Console.WriteLine("Result of ToFromXml = " + envPerm2.ToString() + "\n");

        return returnValue;

    }
    //</Snippet6>
    // AddPathList adds access for the specified environment variables to the existing state of the permission.
    // SetPathList Sets the specified access to the specified environment variables to the existing state
    // of the permission.
    // GetPathList gets all environment variables with the specified EnvironmentPermissionAccess.
    //<Snippet7> 
    private bool SetGetPathListDemo()
    {
        try
        {
            Console.WriteLine("********************************************************\n");
            //<Snippet8>
            Console.WriteLine("Creating an EnvironmentPermission with AllAccess rights for 'TMP'");
            EnvironmentPermission envPerm1 = new EnvironmentPermission(EnvironmentPermissionAccess.AllAccess, "TMP");
            //</Snippet8>
            Console.WriteLine("Adding 'TEMP' to the write access list, and 'windir' to the read access list.");
            envPerm1.AddPathList(EnvironmentPermissionAccess.Write, "TEMP");
            envPerm1.AddPathList(EnvironmentPermissionAccess.Read, "windir");
            Console.WriteLine("Read access list before SetPathList = "
                + envPerm1.GetPathList(EnvironmentPermissionAccess.Read));
            Console.WriteLine("Setting read access to 'TMP'");
            envPerm1.SetPathList(EnvironmentPermissionAccess.Read, "TMP");
            Console.WriteLine("Read access list after SetPathList = "
                + envPerm1.GetPathList(EnvironmentPermissionAccess.Read));
            Console.WriteLine("Write access list = " + envPerm1.GetPathList(EnvironmentPermissionAccess.Write));
            Console.WriteLine("Write access environment variables = "
                + envPerm1.GetPathList(EnvironmentPermissionAccess.AllAccess));
        }
        catch (ArgumentException e)
        {
            // EnvironmentPermissionAccess.AllAccess cannot be used as a parameter for GetPathList.
            Console.WriteLine("An ArgumentException occurred as a result of using AllAccess. "
                + " This property cannot be used as a parameter in GetPathList, because it represents "
                + "more than one type of environment variable : \n" + e);
        }

        return true;
    }
    //</Snippet7>
    // Invoke all demos.
    public bool RunDemo()
    {

        bool ret = true;
        bool retTmp;
        // Call IsSubsetOf demo.
        if (retTmp = IsSubsetOfDemo()) Console.Out.WriteLine("IsSubset demo completed successfully.");
        else Console.Out.WriteLine("IsSubset demo failed.");
        ret = retTmp && ret;

        // Call Union demo.
        if (retTmp = UnionDemo()) Console.Out.WriteLine("Union demo completed successfully.");
        else Console.Out.WriteLine("Union demo failed.");
        ret = retTmp && ret;

        // Call Intersect demo.
        if (retTmp = IntersectDemo()) Console.Out.WriteLine("Intersect demo completed successfully.");
        else Console.Out.WriteLine("Intersect demo failed.");
        ret = retTmp && ret;


        // Call Copy demo.
        if (retTmp = CopyDemo()) Console.Out.WriteLine("Copy demo completed successfully.");
        else Console.Out.WriteLine("Copy demo failed.");
        ret = retTmp && ret;

        // Call ToFromXml demo.
        if (retTmp = ToFromXmlDemo()) Console.Out.WriteLine("ToFromXml demo completed successfully.");
        else Console.Out.WriteLine("ToFromXml demo failed.");
        ret = retTmp && ret;

        // Call SetGetPathList demo.
        if (retTmp = SetGetPathListDemo()) Console.Out.WriteLine("SetGetPathList demo completed successfully.");
        else Console.Out.WriteLine("SetGetPathList demo failed.");
        ret = retTmp && ret;

        return (ret);

    }
    // Test harness.
    public static void Main(String[] args)
    {
        try
        {
            EnvironmentPermissionDemo democase = new EnvironmentPermissionDemo();
            bool ret = democase.RunDemo();
            if (ret)
            {
                Console.Out.WriteLine("EnvironmentPermission demo completed successfully.");
                Console.Out.WriteLine("Press the Enter key to exit.");
                string consoleInput = Console.ReadLine();
                System.Environment.ExitCode = 100;
            }
            else
            {
                Console.Out.WriteLine("EnvironmentPermission demo failed.");
                Console.Out.WriteLine("Press the Enter key to exit.");
                string consoleInput = Console.ReadLine();
                System.Environment.ExitCode = 101;
            }
        }
        catch (Exception e)
        {
            Console.Out.WriteLine("EnvironmentPermission demo failed.");
            Console.WriteLine(e.ToString());
            Console.Out.WriteLine("Press the Enter key to exit.");
            string consoleInput = Console.ReadLine();
            System.Environment.ExitCode = 101;
        }
    }
}



//</Snippet1>

