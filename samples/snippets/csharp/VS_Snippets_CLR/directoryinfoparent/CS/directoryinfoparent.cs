// <snippet1>
using System;
using System.IO;

public class MoveToTest 
{
    public static void Main() 
    {

        // Make a reference to a directory.
        DirectoryInfo di = new DirectoryInfo("TempDir");

        // Create the directory only if it does not already exist.
        if (di.Exists == false)
            di.Create();

        // Create a subdirectory in the directory just created.
        DirectoryInfo dis = di.CreateSubdirectory("SubDir");

        // Get a reference to the parent directory of the subdirectory you just made.
        DirectoryInfo parentDir = dis.Parent;
        Console.WriteLine("The parent directory of '{0}' is '{1}'", dis.Name, parentDir.Name);

        // Delete the parent directory.
        di.Delete(true);
    }
}
// </snippet1>