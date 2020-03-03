//<snippet1>
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

        // Move the main directory. Note that the contents move with the directory.
        if (Directory.Exists("NewTempDir") == false)
            di.MoveTo("NewTempDir");

        try 
        {
            // Attempt to delete the subdirectory. Note that because it has been
            // moved, an exception is thrown.
            dis.Delete(true);
        } 
        catch (Exception) 
        {
            // Handle this exception in some way, such as with the following code:
            // Console.WriteLine("That directory does not exist.");
        }

        // Point the DirectoryInfo reference to the new directory.
        //di = new DirectoryInfo("NewTempDir");

        // Delete the directory.
        //di.Delete(true);
    }
}
// </snippet1>