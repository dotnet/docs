//<snippet00>
using System;
using System.IO;

class App
{
    public static void Main()
    {
        // Specify the directory you want to manipulate.
        string path = @"c:\";
        string searchPattern = "c*";

        DirectoryInfo di = new DirectoryInfo(path);
        DirectoryInfo[] directories = 
            di.GetDirectories(searchPattern, SearchOption.TopDirectoryOnly);

        FileInfo[] files = 
            di.GetFiles(searchPattern, SearchOption.TopDirectoryOnly);

        Console.WriteLine(
            "Directories that begin with the letter \"c\" in {0}", path);
        foreach (DirectoryInfo dir in directories)
        {
            Console.WriteLine(
                "{0,-25} {1,25}", dir.FullName, dir.LastWriteTime);
        }

        Console.WriteLine();
        Console.WriteLine(
            "Files that begin with the letter \"c\" in {0}", path);
        foreach (FileInfo file in files)
        {
            Console.WriteLine(
                "{0,-25} {1,25}", file.Name, file.LastWriteTime);
        }
    } // Main()
} // App()
//</snippet00>