// <snippet1>
using System;
using System.IO;

public class DeleteTest 
{
    public static void Main() 
    {
        // Create a reference to a file.
        FileInfo fi = new FileInfo("temp.txt");
        // Actually create the file.
        FileStream fs = fi.Create();
        // Modify the file as required, and then close the file.
        fs.Close();
        // Delete the file.
        fi.Delete();
    }
}
// </snippet1>