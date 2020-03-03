// <snippet1>
using System;
using System.IO;

public class GetFilesTest 
{
    public static void Main() 
    {
        // Make a reference to a directory.
        DirectoryInfo di = new DirectoryInfo("c:\\");

        // Get a reference to each file in that directory.
        FileInfo[] fiArr = di.GetFiles();

        // Display the names of the files.
        foreach (FileInfo fri in fiArr)
            Console.WriteLine(fri.Name);
    }
}
// </snippet1>