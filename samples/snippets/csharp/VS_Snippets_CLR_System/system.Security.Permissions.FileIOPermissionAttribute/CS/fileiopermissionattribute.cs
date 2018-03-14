//<Snippet1>
// This sample demonstrates the use of the FileIOPermissionAttribute class.
// The sample follows the recommended procedure of first granting PermitOnly permissions,
// then using a Deny on that set of granted permissions.

using System;
using System.Reflection;
using System.Security.Permissions;
using System.Security;
using System.IO;

class MyClass
{

    // This method demonstrates the use of the FileIOPermissionAttribute to create a PermitOnly permission.
    //<Snippet2>
    //<Snippet7>
    // Set the Read property.
    [FileIOPermissionAttribute(SecurityAction.PermitOnly, Read = "C:\\")]
    //</Snippet2>
    //<Snippet3>
    // Set the PathDiscovery property.
    [FileIOPermissionAttribute(SecurityAction.PermitOnly,
         PathDiscovery = "C:\\Documents and Settings\\All Users")]
    //</Snippet3>
    //<Snippet4>
    // Set the Append property.
    [FileIOPermissionAttribute(SecurityAction.PermitOnly,
         Append = "C:\\Documents and Settings\\All Users\\Application Data")]
    //</Snippet4>
    //<Snippet5>
    // Set the Write property.
    [FileIOPermissionAttribute(SecurityAction.PermitOnly,
         Write = "C:\\Documents and Settings\\All Users\\Application Data\\Microsoft")]
    //</Snippet5>
    //<Snippet6>
    // Set the All property.
    [FileIOPermissionAttribute(SecurityAction.PermitOnly,
         All = "C:\\Documents and Settings\\All Users\\Application Data\\Microsoft\\Network")]
    //</Snippet6>
    public static void PermitOnlyMethod()
    {
        Console.WriteLine("Executing PermitOnlyMethod.");
        Console.WriteLine("PermitOnly the Read permission for drive C.");
        Console.WriteLine("PermitOnly the PathDiscovery permission for \n\tC:\\Documents and Settings\\All Users.");
        Console.WriteLine("PermitOnly the Append permission for \n\tC:\\Documents and Settings\\All Users\\Application Data.");
        Console.WriteLine("PermitOnly the Write permission for \n\tC:\\Documents and Settings\\All Users\\Application Data\\Microsoft.");
        Console.WriteLine("PermitOnly the All permission for \n\tC:\\Documents and Settings\\All Users\\Application Data\\Microsoft\\Network.");

        PermitOnlyTestMethod();
    }
    //</Snippet7>

    public static void PermitOnlyTestMethod()
    {
        Console.WriteLine("Executing PermitOnlyTestMethod.");
        try
        {
            PermissionSet ps = new PermissionSet(PermissionState.None);
            ps.AddPermission(new FileIOPermission(FileIOPermissionAccess.Write,
                "C:\\Documents and Settings\\All Users\\Application Data\\Microsoft\\Network\\SomeFile"));
            Console.WriteLine("Demanding permission to write " +
                "'C:\\Documents and Settings\\All Users\\Application Data\\Microsoft\\Network\\SomeFile'");
            ps.Demand();
            Console.WriteLine("Demand succeeded.");
            ps.AddPermission(
                new FileIOPermission(FileIOPermissionAccess.Write,
                "C:\\"));
            Console.WriteLine("Demanding permission to write to drive C.");

            // This demand should cause an exception.
            ps.Demand();
            // The TestFailed method is called if an exception is not thrown.
            TestFailed();
        }
        catch (Exception e)
        {
            Console.WriteLine("An exception was thrown because of a write demand: " + e.Message);
        }
    }


    public static void TestFailed()
    {
        Console.WriteLine("Executing TestFailed.");
        Console.WriteLine("Throwing an exception.");
        throw new Exception();
    }

    static void Main(string[] args)
    {
        try
        {
            PermitOnlyMethod();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message.ToString());
        }

    }

}

//</Snippet1>