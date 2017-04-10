//<Snippet1>
// To run this sample you must create a strong-name key named snkey.snk 
// using the Strong Name tool (sn.exe).  Both the library assembly and the 
// application assembly that calls it must be signed with that key.  
// To run successfully, the application assembly must be in the global 
// assembly cache.
// This console application can be created using the following code.

//using System;
//using System.Security;
//using System.Reflection;
//using ClassLibrary1;
//[assembly: AssemblyVersion("1.0.555.0")]
//[assembly: AssemblyKeyFile("snKey.snk")]
//class MyClass
//{
//    static void Main(string[] args)
//    {
//        try
//        {
//            Class1 myLib = new Class1();
//            myLib.DoNothing();
//
//            Console.WriteLine("Exiting the sample.");
//        }
//        catch (Exception e)
//        {
//        Console.WriteLine(e.Message);
//        }
//    }
//}
using System;
using System.Security.Permissions;

namespace ClassLibrary1
{
    //<Snippet2>
    // Demand that the calling program be in the global assembly cache.
    [GacIdentityPermissionAttribute(SecurityAction.Demand)]
    public class Class1
    //</Snippet2>
    {
        public void DoNothing()
        {
            Console.WriteLine("Exiting the library program.");
        }
    }
}

//</Snippet1>