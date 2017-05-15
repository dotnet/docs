using System;
using System.Security;
using System.Security.Permissions;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            // <Snippet1>
            FileIOPermission f = new FileIOPermission(PermissionState.None);
            f.AllLocalFiles = FileIOPermissionAccess.Read;
            try
            {
                f.Demand();
            }
            catch (SecurityException s)
            {
                Console.WriteLine(s.Message);
            }

            // </Snippet1>
            
            // <Snippet2>
            FileIOPermission f2 = new FileIOPermission(FileIOPermissionAccess.Read, "C:\\test_r");
            f2.AddPathList(FileIOPermissionAccess.Write | FileIOPermissionAccess.Read, "C:\\example\\out.txt");
            try
            {
                f2.Demand();
            }
            catch (SecurityException s)
            {
                Console.WriteLine(s.Message);
            }
            // </Snippet2>
            Console.Read();

            // <Snippet3>
            FileIOPermission f3 = new FileIOPermission(PermissionState.None);
            f3.AllFiles = FileIOPermissionAccess.Read;
            try
            {
                f3.Demand();
            }
            catch (SecurityException s)
            {
                Console.WriteLine(s.Message);
            }

            // </Snippet3>
        }
    }
}
