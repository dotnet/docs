
using System;
using System.Security;
using System.Security.Permissions;

public class FileIOPermissionDemo
{
    public static void Main()
    {
        try
        {
            FileIOPermission fileIOPerm1;
            fileIOPerm1 = new FileIOPermission(PermissionState.Unrestricted);

            // Tests for: SetPathList(FileIOPermissionAccess,String)

            // Test the Read list
            fileIOPerm1.SetPathList(FileIOPermissionAccess.Read, "C:\\documents");

            Console.WriteLine("Read access before SetPathList = ");
            foreach (string path in fileIOPerm1.GetPathList(FileIOPermissionAccess.Read))
            {
                Console.WriteLine("\t" + path);
            }

            //<Snippet12>
            fileIOPerm1.SetPathList(FileIOPermissionAccess.Read, "C:\\temp");
            //</Snippet12>

            Console.WriteLine("Read access after SetPathList = ");
            foreach (string path in fileIOPerm1.GetPathList(FileIOPermissionAccess.Read))
            {
                Console.WriteLine("\t" + path);
            }


            // Test the Write list
            fileIOPerm1.SetPathList(FileIOPermissionAccess.Write, "C:\\temp");

            Console.WriteLine("Write access before SetPathList = ");
            foreach (string path in fileIOPerm1.GetPathList(FileIOPermissionAccess.Write))
            {
                Console.WriteLine("\t" + path);
            }
            //<Snippet13>
            fileIOPerm1.SetPathList(FileIOPermissionAccess.Write, "C:\\documents");
            //</Snippet13>

            Console.WriteLine("Write access after SetPathList = ");
            foreach (string path in fileIOPerm1.GetPathList(FileIOPermissionAccess.Write))
            {
                Console.WriteLine("\t" + path);
            }

            // Tests for: SetPathList(FileIOPermissionAccess,String[])

            // Test the Read list
            fileIOPerm1.SetPathList(FileIOPermissionAccess.Read, new string[] {"C:\\pictures", "C:\\music"});

            Console.WriteLine("Read access before SetPathList = ");
            foreach (string path in fileIOPerm1.GetPathList(FileIOPermissionAccess.Read))
            {
                Console.WriteLine("\t" + path);
            }

            //<Snippet14>
            fileIOPerm1.SetPathList(FileIOPermissionAccess.Read, new string[] {"C:\\temp", "C:\\Documents"});
            //</Snippet14>

            Console.WriteLine("Read access after SetPathList = ");
            foreach (string path in fileIOPerm1.GetPathList(FileIOPermissionAccess.Read))
            {
                Console.WriteLine("\t" + path);
            }


            // Test the Write list
            fileIOPerm1.SetPathList(FileIOPermissionAccess.Write, new string[] {"C:\\temp", "C:\\Documents"});

            Console.WriteLine("Write access before SetPathList = ");
            foreach (string path in fileIOPerm1.GetPathList(FileIOPermissionAccess.Write))
            {
                Console.WriteLine("\t" + path);
            }
            //<Snippet15>
            fileIOPerm1.SetPathList(FileIOPermissionAccess.Write, new string[] {"C:\\pictures", "C:\\music"});
            //</Snippet15>

            Console.WriteLine("Write access after SetPathList = ");
            foreach (string path in fileIOPerm1.GetPathList(FileIOPermissionAccess.Write))
            {
                Console.WriteLine("\t" + path);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
