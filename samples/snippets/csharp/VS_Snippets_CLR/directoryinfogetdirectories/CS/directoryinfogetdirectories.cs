// <snippet1>
using System;
using System.IO;

public class GetDirectoriesTest 
{
    public static void Main() 
    {

        // Make a reference to a directory.
        DirectoryInfo di = new DirectoryInfo("c:\\");

        // Get a reference to each directory in that directory.
        DirectoryInfo[] diArr = di.GetDirectories();

        // Display the names of the directories.
        foreach (DirectoryInfo dri in diArr)
            Console.WriteLine(dri.Name);
    }
}
// </snippet1>