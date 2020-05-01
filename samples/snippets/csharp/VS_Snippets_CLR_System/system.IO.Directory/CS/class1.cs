//<Snippet5>
//<Snippet4>
//<Snippet3>
//<Snippet2>
//<Snippet1>
using System;

namespace GetFileSystemEntries
{
    class Class1
    {
        static void Main(string[] args)
        {
            Class1 snippets = new Class1();

            string path = System.IO.Directory.GetCurrentDirectory();
            string filter = "*.exe";

            snippets.PrintFileSystemEntries(path);
            snippets.PrintFileSystemEntries(path, filter);		
            snippets.GetLogicalDrives();
            snippets.GetParent(path);
            snippets.Move("C:\\proof", "C:\\Temp");
        }

        void PrintFileSystemEntries(string path)
        {
			
            try
            {
                // Obtain the file system entries in the directory path.
                string[] directoryEntries =
                    System.IO.Directory.GetFileSystemEntries(path);

                foreach (string str in directoryEntries)
                {
                    System.Console.WriteLine(str);
                }
            }
            catch (ArgumentNullException)
            {
                System.Console.WriteLine("Path is a null reference.");
            }
            catch (System.Security.SecurityException)
            {
                System.Console.WriteLine("The caller does not have the " +
                    "required permission.");
            }
            catch (ArgumentException)
            {
                System.Console.WriteLine("Path is an empty string, " +
                    "contains only white spaces, " +
                    "or contains invalid characters.");
            }
            catch (System.IO.DirectoryNotFoundException)
            {
                System.Console.WriteLine("The path encapsulated in the " +
                    "Directory object does not exist.");
            }
        }
        void PrintFileSystemEntries(string path, string pattern)
        {
            try
            {
                // Obtain the file system entries in the directory
                // path that match the pattern.
                string[] directoryEntries =
                    System.IO.Directory.GetFileSystemEntries(path, pattern);

                foreach (string str in directoryEntries)
                {
                    System.Console.WriteLine(str);
                }
            }
            catch (ArgumentNullException)
            {
                System.Console.WriteLine("Path is a null reference.");
            }
            catch (System.Security.SecurityException)
            {
                System.Console.WriteLine("The caller does not have the " +
                    "required permission.");
            }
            catch (ArgumentException)
            {
                System.Console.WriteLine("Path is an empty string, " +
                    "contains only white spaces, " +
                    "or contains invalid characters.");
            }
            catch (System.IO.DirectoryNotFoundException)
            {
                System.Console.WriteLine("The path encapsulated in the " +
                    "Directory object does not exist.");
            }
        }

        // Print out all logical drives on the system.
        void GetLogicalDrives()
        {
            try
            {
                string[] drives = System.IO.Directory.GetLogicalDrives();

                foreach (string str in drives)
                {
                    System.Console.WriteLine(str);
                }
            }
            catch (System.IO.IOException)
            {
                System.Console.WriteLine("An I/O error occurs.");
            }
            catch (System.Security.SecurityException)
            {
                System.Console.WriteLine("The caller does not have the " +
                    "required permission.");
            }
        }
        void GetParent(string path)
        {
            try
            {
                System.IO.DirectoryInfo directoryInfo =
                    System.IO.Directory.GetParent(path);

                System.Console.WriteLine(directoryInfo.FullName);
            }
            catch (ArgumentNullException)
            {
                System.Console.WriteLine("Path is a null reference.");
            }
            catch (ArgumentException)
            {
                System.Console.WriteLine("Path is an empty string, " +
                    "contains only white spaces, or " +
                    "contains invalid characters.");
            }
        }
        void Move(string sourcePath, string destinationPath)
        {
            try
            {
                System.IO.Directory.Move(sourcePath, destinationPath);
                System.Console.WriteLine("The directory move is complete.");
            }
            catch (ArgumentNullException)
            {
                System.Console.WriteLine("Path is a null reference.");
            }
            catch (System.Security.SecurityException)
            {
                System.Console.WriteLine("The caller does not have the " +
                    "required permission.");
            }
            catch (ArgumentException)
            {
                System.Console.WriteLine("Path is an empty string, " +
                    "contains only white spaces, " +
                    "or contains invalid characters.");	
            }
            catch (System.IO.IOException)
            {
                System.Console.WriteLine("An attempt was made to move a " +
                    "directory to a different " +
                    "volume, or destDirName " +
                    "already exists.");
            }
        }
    }
}
//</Snippet1>
//</Snippet2>
//</Snippet3>
//</Snippet4>
//</Snippet5>