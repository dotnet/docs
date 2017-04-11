//Types:System.Security.Permissions.IsolatedStorageContainment (enum)  Vendor: Richter
//Types:System.Security.Permissions.IsolatedStoragePermissionAttribute  Vendor: Richter
//Types:System.Security.Permissions.SecurityAction  Vendor: Richter
//<snippet1>
using System;
using System.Security.Permissions;
using System.IO.IsolatedStorage;
using System.IO;

// Notify the CLR to only grant IsolatedStorageFilePermission to called methods. 
// This restricts the called methods to working only with storage files that are isolated 
// by user and assembly.
[IsolatedStorageFilePermission(SecurityAction.PermitOnly, UsageAllowed = IsolatedStorageContainment.AssemblyIsolationByUser)]
public sealed class App
{
    static void Main()
    {
        WriteIsolatedStorage();

    }
    private static void WriteIsolatedStorage()
    {
        // Attempt to create a storage file that is isolated by user and assembly.
        // IsolatedStorageFilePermission granted to the attribute at the top of this file 
        // allows CLR to load this assembly and execution of this statement.
        using (Stream s = new IsolatedStorageFileStream("AssemblyData", FileMode.Create, IsolatedStorageFile.GetUserStoreForAssembly()))
        {

            // Write some data out to the isolated file.
            using (StreamWriter sw = new StreamWriter(s))
            {
                sw.Write("This is some test data.");
            }
        }

        // Attempt to open the file that was previously created.
        using (Stream s = new IsolatedStorageFileStream("AssemblyData", FileMode.Open, IsolatedStorageFile.GetUserStoreForAssembly()))
        {
            // Read the data from the file and display it.
            using (StreamReader sr = new StreamReader(s))
            {
                Console.WriteLine(sr.ReadLine());
            }
        }
    }
}

// This code produces the following output.
//
//  Some test data.
//</snippet1>