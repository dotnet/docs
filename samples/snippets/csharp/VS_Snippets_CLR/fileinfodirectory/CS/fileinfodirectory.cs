// <snippet1>
using System;
using System.IO;

public class DirectoryTest 
{
    public static void Main() 
    {

        // Open an existing file, or create a new one.
        FileInfo fi = new FileInfo("temp.txt");

        // Determine the full path of the file just created.
        DirectoryInfo di = fi.Directory;

        // Figure out what other entries are in that directory.
        FileSystemInfo[] fsi = di.GetFileSystemInfos();

        Console.WriteLine("The directory '{0}' contains the following files and directories:", di.FullName);

        // Print the names of all the files and subdirectories of that directory.
        foreach (FileSystemInfo info in fsi)
            Console.WriteLine(info.Name);
    }
}
//This code produces output similar to the following; 
//results may vary based on the computer/file structure/etc.:
//
//The directory 'C:\Visual Studio 2005\release' contains the following files 
//and directories:
//TempPE
//fileinfodirectory.exe
//fileinfodirectory.pdb
//newTemp.txt
//temp.txt

// </snippet1>