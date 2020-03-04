// <snippet1>
using System;
using System.IO;

public class NameTest 
{
    public static void Main() 
    {
        // Create a reference to the current directory.
        DirectoryInfo di = new DirectoryInfo(Environment.CurrentDirectory);
        // Create an array representing the files in the current directory.
        FileInfo[] fi = di.GetFiles();
        Console.WriteLine("The following files exist in the current directory:");
        // Print out the names of the files in the current directory.
        foreach (FileInfo fiTemp in fi)
            Console.WriteLine(fiTemp.Name);
    }
}
//This code produces output similar to the following; 
//results may vary based on the computer/file structure/etc.:
//
//The following files exist in the current directory:
//fileinfoname.exe
//fileinfoname.pdb
//newTemp.txt
// </snippet1>