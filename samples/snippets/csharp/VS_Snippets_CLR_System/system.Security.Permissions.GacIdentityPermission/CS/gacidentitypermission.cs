// <Snippet1>
using System;
using System.Security;
using System.Security.Permissions;

public class GacIdentityPermissionDemo
{
    // <Snippet2>
    // IsSubsetOf determines whether the current permission is a subset of the specified permission.
    private bool IsSubsetOfDemo()
    {
        try
        {
            //<Snippet9>
            GacIdentityPermission Gac1 = new GacIdentityPermission();
            GacIdentityPermission Gac2 = new GacIdentityPermission(PermissionState.None);
            if (Gac1.Equals(Gac2))
                Console.WriteLine("GacIdentityPermission() equals GacIdentityPermission(PermissionState.None).");
            //</Snippet9>
            if (Gac1.IsSubsetOf(Gac2))
            {
                Console.WriteLine(Gac1 + " is a subset of " + Gac2);
            }
            else
            {
                Console.WriteLine(Gac1 + " is not a subset of " + Gac2);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine ("An exception was thrown : " + e);
            return false;
        }
        return true;
    }
    // </Snippet2>
    // <Snippet3>
    // Union creates a new permission that is the union of the current permission
    // and the specified permission.
    private bool UnionDemo()
    {
        //<Snippet7>
        GacIdentityPermission Gac1 = new GacIdentityPermission(PermissionState.None);
        //</Snippet7>
        //<Snippet8>
        GacIdentityPermission Gac2 = new GacIdentityPermission();
        //</Snippet8>
        try
        {
            GacIdentityPermission p3 = (GacIdentityPermission)Gac1.Union(Gac2);

            if (p3 != null)
            {
                Console.WriteLine("The union of two GacIdentityPermissions was successful.");

            }
            else
            {
                Console.WriteLine("The union of two GacIdentityPermissions failed.");
                return false;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("An exception was thrown : " + e);
            return false;

        }

        return true;

    }
    // </Snippet3>
    // <Snippet4>
    // Intersect creates and returns a new permission that is the intersection of the
    // current permission and the specified permission.
    private bool IntersectDemo()
    {
        GacIdentityPermission Gac1 = new GacIdentityPermission();
        GacIdentityPermission Gac2 = new GacIdentityPermission();
        try
        {
            GacIdentityPermission p3 = (GacIdentityPermission)Gac1.Intersect(Gac2);
            if (p3 != null)
            {
                Console.WriteLine("The intersection of the two permissions = " + p3.ToString() + "\n");

            }
            else
            {
                Console.WriteLine("The intersection of the two permissions is null.\n");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("An exception was thrown : " + e);
            return false;

        }

        return true;

    }
    //</Snippet4>
    //<Snippet5>
    //Copy creates and returns an identical copy of the current permission.
    private bool CopyDemo()
    {

        GacIdentityPermission Gac1 = new GacIdentityPermission();
        GacIdentityPermission Gac2 = new GacIdentityPermission();
        Console.WriteLine("**************************************************************************");
        try
        {
            Gac2 = (GacIdentityPermission)Gac1.Copy();
            if (Gac2 != null)
            {
                Console.WriteLine("Result of copy = " + Gac2.ToString() + "\n");
            }

        }
        catch (Exception e)
        {
            Console.WriteLine("Copy failed : " + Gac1.ToString() + e);
            return false;
        }

        return true;

    }
    //</Snippet5>
    //<Snippet6>
    // ToXml creates an XML encoding of the permission and its current state; FromXml reconstructs a
    // permission with the specified state from the XML encoding.
    private bool ToFromXmlDemo()
    {
        GacIdentityPermission Gac1 = new GacIdentityPermission();
        GacIdentityPermission Gac2 = new GacIdentityPermission();
        Console.WriteLine("**************************************************************************");
        try
        {
            Gac2 = new GacIdentityPermission(PermissionState.None);
            Gac2.FromXml(Gac1.ToXml());
            bool result = Gac2.Equals(Gac1);
            if (Gac2.IsSubsetOf(Gac1) && Gac1.IsSubsetOf(Gac2))
            {
                Console.WriteLine("Result of ToFromXml = " + Gac2.ToString());
            }
            else
            {
                Console.WriteLine(Gac2.ToString());
                Console.WriteLine(Gac1.ToString());
                return false;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("ToFromXml failed. " + e);
            return false;
        }

        return true;

    }
    //</Snippet6>
    // Invoke all demos.
    public bool RunDemo()
    {

        bool returnCode =true;
        bool tempReturnCode;
        // Call the IsSubsetOf demo.
        if (tempReturnCode = IsSubsetOfDemo())Console.Out.WriteLine("IsSubsetOf demo completed successfully.");
        else Console.Out.WriteLine("Subset demo failed.");
        returnCode = tempReturnCode && returnCode;

        // Call the Union demo.
        if (tempReturnCode = UnionDemo())Console.Out.WriteLine("Union demo completed successfully.");
        else Console.Out.WriteLine("Union demo failed.");
        returnCode = tempReturnCode && returnCode;

        // Call the Intersect demo.
        if (tempReturnCode = IntersectDemo())Console.Out.WriteLine("Intersect demo completed successfully.");
        else Console.Out.WriteLine("Intersect demo failed.");
        returnCode = tempReturnCode && returnCode;


        // Call the Copy demo.
        if (tempReturnCode = CopyDemo())Console.Out.WriteLine("Copy demo completed successfully.");
        else Console.Out.WriteLine("Copy demo failed.");
        returnCode = tempReturnCode && returnCode;

        // Call the ToFromXML demo.
        if (tempReturnCode = ToFromXmlDemo())Console.Out.WriteLine("ToFromXML demo completed successfully.");
        else Console.Out.WriteLine("ToFromXml demo failed.");
        returnCode = tempReturnCode && returnCode;

        return (returnCode);

    }
    // Test harness.
    public static void Main(String[] args)
    {
        try
        {
            GacIdentityPermissionDemo testcase = new GacIdentityPermissionDemo();
            bool returnCode = testcase.RunDemo();
            if (returnCode)
            {
                Console.Out.WriteLine("The GacIdentityPermission demo completed successfully.");
                Console.Out.WriteLine("Press the Enter key to exit.");
                string consoleInput = Console.ReadLine();
                System.Environment.ExitCode = 100;
            }
            else
            {
                Console.Out.WriteLine("The GacIdentityPermission demo failed.");
                Console.Out.WriteLine("Press the Enter key to exit.");
                string consoleInput = Console.ReadLine();
                System.Environment.ExitCode = 101;
            }
        }
        catch (Exception e)
        {
            Console.Out.WriteLine("The GacIdentityPermission demo failed.");
            Console.WriteLine(e.ToString());
            Console.Out.WriteLine("Press the Enter key to exit.");
            string consoleInput = Console.ReadLine();
            System.Environment.ExitCode = 101;
        }
    }
}



// </Snippet1>