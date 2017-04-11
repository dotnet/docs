// <Snippet1>

using System;
using System.Security;
using System.Security.Permissions;


public class StrongNameIdentityDemo
{
    // Public key
    static byte[] b1 = { 0, 36, 0, 0, 4, 128, 0, 0, 148, 0, 0, 0, 6, 2, 0, 0, 0, 36, 0, 0,
82, 83, 65, 49, 0, 4, 0, 0, 1, 0, 1, 0, 237, 146, 145, 51, 34,
97, 123, 196, 90, 174, 41, 170, 173, 221, 41, 193, 175, 39, 7,
151, 178, 0, 230, 152, 218, 8, 206, 206, 170,84, 111, 145, 26,
208, 158, 240, 246, 219, 228, 34, 31, 163, 11, 130, 16, 199, 111,
224, 4, 112, 46, 84, 0, 104, 229, 38, 39, 63, 53, 189, 0, 157,
32, 38, 34, 109, 0, 171, 114, 244, 34, 59, 9, 232, 150, 192, 247,
175, 104, 143, 171, 42, 219, 66, 66, 194, 191, 218, 121, 59, 92,
42, 37, 158, 13, 108, 210, 189, 9, 203, 204, 32, 48, 91, 212, 101,
193, 19, 227, 107, 25, 133, 70, 2, 220, 83, 206, 71, 102, 245, 104,
252, 87, 109, 190, 56, 34, 180};

    StrongNamePublicKeyBlob blob = new StrongNamePublicKeyBlob(b1);
    // Use this version number.
    Version v1 = new Version("1.0.0.0");
    //<Snippet2>
    // IsSubsetOf determines whether the current permission is a subset of the specified permission.
    private bool IsSubsetOfDemo()
    {

        bool returnValue = true;

        StrongNameIdentityPermission snIdPerm1, snIdPerm2;

        //<Snippet8>
        snIdPerm1 = new StrongNameIdentityPermission(blob, "MyCompany.MyDepartment.*", new Version("1.0.0.0"));
        //</Snippet8>
        snIdPerm2 = new StrongNameIdentityPermission(blob, "MyCompany.MyDepartment.MyFile", new Version("1.0.0.0"));

        if (snIdPerm1.IsSubsetOf(snIdPerm2))
        {

            Console.WriteLine("MyCompany.MyDepartment.* is a subset " +
            "of MyCompany.MyDepartment.MyFile \n");
        }
        else
        {
            Console.WriteLine("MyCompany.MyDepartment.*" +
            " is not a subset of MyCompany.MyDepartment.MyFile \n");
        }

        return returnValue;
    }
    //</Snippet2>
    //<Snippet3>
    // Union creates a new permission that is the union of the current permission and the specified permission.
    private bool UnionDemo()
    {

        bool returnValue = true;

        StrongNameIdentityPermission snIdPerm1, snIdPerm2;
        IPermission snIdPerm3;

        snIdPerm1 = new StrongNameIdentityPermission(blob, "MyCompany.MyDepartment.*", new Version("1.0.0.0"));
        snIdPerm2 = new StrongNameIdentityPermission(blob, "MyCompany.MyDepartment.MyFile", new Version("1.0.0.0"));

        snIdPerm3 = (StrongNameIdentityPermission)snIdPerm1.Union(snIdPerm2);

        try
        {
            Console.WriteLine("The union of MyCompany.MyDepartment.*" +
            "and MyCompany.MyDepartment.MyFile is " +
            ((StrongNameIdentityPermission)snIdPerm3).Name.ToString());
        }
        catch (Exception e)
        {
            Console.WriteLine("An expected exception was thrown: " + e.Message);
        }


        return returnValue;

    }
    //</Snippet3>
    //<Snippet4>
    // Intersect creates and returns a new permission that is the intersection of the current
    // permission and the permission specified.
    private bool IntersectDemo()
    {

        bool returnValue = true;

        StrongNameIdentityPermission snIdPerm1, snIdPerm2, snIdPerm3;

        snIdPerm1 = new StrongNameIdentityPermission(blob, "MyCompany.MyDepartment.*", new Version("1.0.0.0"));
        snIdPerm2 = new StrongNameIdentityPermission(blob, "MyCompany.MyDepartment.MyFile", new Version("1.0.0.0"));

        try
        {

            snIdPerm3 = (StrongNameIdentityPermission)snIdPerm1.Intersect(snIdPerm2);

            Console.WriteLine("The intersection of MyCompany.MyDepartment.*"
            + "MyCompany.MyDepartment.MyFile is "
            + ((StrongNameIdentityPermission)snIdPerm3).Name.ToString());

        }
        catch (Exception e)
        {
            Console.WriteLine("An exception was thrown: " + e);
            returnValue = false;
        }

        return returnValue;

    }
    //</Snippet4>
    //<Snippet5>
    //Copy creates and returns an identical copy of the current permission.
    private bool CopyDemo()
    {
        bool returnValue = true;

        StrongNameIdentityPermission snIdPerm1, snIdPerm2;

        snIdPerm1 = new StrongNameIdentityPermission(blob, "MyCompany.MyDepartment.*", new Version("1.0.0.0"));
        //<Snippet7>
        snIdPerm2 = new StrongNameIdentityPermission(PermissionState.None);
        //</Snippet7>

        snIdPerm2 = (StrongNameIdentityPermission)snIdPerm1.Copy();
        Console.WriteLine("Result of copy = " + snIdPerm2.ToString() + "\n");

        return returnValue;
    }
    //</Snippet5>
    //<Snippet6>
    // ToXml creates an XML encoding of the permission and its current state;
    //FromXml reconstructs a permission with the specified state from the XML encoding.
    private bool ToFromXmlDemo()
    {

        bool returnValue = true;

        StrongNameIdentityPermission snIdPerm1, snIdPerm2;

        snIdPerm1 = new StrongNameIdentityPermission(blob, "MyCompany.MyDepartment.*", new Version("1.0.0.0"));    
        snIdPerm2 = new StrongNameIdentityPermission(PermissionState.None);
        snIdPerm2.FromXml(snIdPerm1.ToXml());
        Console.WriteLine("Result of ToFromXml = " + snIdPerm2.ToString() + "\n");

        return returnValue;

    }
    //</Snippet6>
    // Invoke all demos.
    public bool RunDemo()
    {

        bool ret = true;
        bool retTmp;
        // Call the IsSubsetOf demo.
        if (retTmp = IsSubsetOfDemo()) Console.Out.WriteLine("IsSubsetOf demo completed successfully.");
        else
            Console.Out.WriteLine("IsSubsetOf demo failed.");
        ret = retTmp && ret;

        // Call the Union demo.
        if (retTmp = UnionDemo()) Console.Out.WriteLine("Union demo completed successfully.");
        else
            Console.Out.WriteLine("Union demo failed.");
        ret = retTmp && ret;

        // Call the Intersect demo.
        if (retTmp = IntersectDemo()) Console.Out.WriteLine("Intersect demo completed successfully.");
        else
            Console.Out.WriteLine("Intersect demo failed.");
        ret = retTmp && ret;


        // Call the Copy demo.
        if (retTmp = CopyDemo()) Console.Out.WriteLine("Copy demo completed successfully");
        else
            Console.Out.WriteLine("Copy demo failed.");
        ret = retTmp && ret;

        // Call the ToFromXml demo.
        if (retTmp = ToFromXmlDemo()) Console.Out.WriteLine("ToFromXml demo completed successfully");
        else
            Console.Out.WriteLine("ToFromXml demo failed.");
        ret = retTmp && ret;

        Console.WriteLine("********************************************************\n");


        return (ret);






    }
    // Test harness.
    public static void Main(String[] args)
    {
        try
        {
            StrongNameIdentityDemo democase = new StrongNameIdentityDemo();
            bool ret = democase.RunDemo();
            if (ret)
            {
                Console.Out.WriteLine("StrongNameIdentity demo completed successfully.");
                Console.Out.WriteLine("Press the Enter key to exit.");
                string consoleInput = Console.ReadLine();
                System.Environment.ExitCode = 100;
            }
            else
            {
                Console.Out.WriteLine("StrongNameIdentity demo failed.");
                Console.Out.WriteLine("Press the Enter key to exit.");
                string consoleInput = Console.ReadLine();
                System.Environment.ExitCode = 101;
            }
        }
        catch (Exception e)
        {
            Console.Out.WriteLine("StrongNameIdentity demo failed.");
            Console.WriteLine(e.ToString());
            Console.Out.WriteLine("Press the Enter key to exit.");
            string consoleInput = Console.ReadLine();
            System.Environment.ExitCode = 101;
        }
        // Catch non-CLSCompliant exceptions.
        catch
        {
            Console.WriteLine("An unexpected non-CLSCompliant exception was thrown.");
        }
    }
}

// </Snippet1>


