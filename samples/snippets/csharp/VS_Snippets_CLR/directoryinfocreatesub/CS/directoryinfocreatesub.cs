// <snippet1>
using System;
using System.IO;

public class CreateSubTest 
{
    public static void Main() 
    {
        // Create a reference to a directory.
        DirectoryInfo di = new DirectoryInfo("TempDir");

        // Create the directory only if it does not already exist.
        if (di.Exists == false)
            di.Create();

        // Create a subdirectory in the directory just created.
        DirectoryInfo dis = di.CreateSubdirectory("SubDir");

        // Process that directory as required.
        // ...

        // Delete the subdirectory.
        dis.Delete(true);

        // Delete the directory.
        di.Delete(true);
    }
}
// </snippet1>