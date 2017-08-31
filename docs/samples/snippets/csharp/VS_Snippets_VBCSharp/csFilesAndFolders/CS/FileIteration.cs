using System;
using System.Collections.Generic;
using System.Linq;
//using System.Text;
//using System.IO;
using System.Diagnostics;


namespace FileIteration
{
    //How to: Iterate Through Folders  Recursively (C# Programming Guide)
    //add starting tag 1 here
    #region snip1
    //<snippet1>
    public class RecursiveFileSearch
    {
        static System.Collections.Specialized.StringCollection log = new System.Collections.Specialized.StringCollection();

        static void Main()
        {
            // Start with drives if you have to search the entire computer.
            string[] drives = System.Environment.GetLogicalDrives();

            foreach (string dr in drives)
            {
                System.IO.DriveInfo di = new System.IO.DriveInfo(dr);

                // Here we skip the drive if it is not ready to be read. This
                // is not necessarily the appropriate action in all scenarios.
                if (!di.IsReady)
                {
                    Console.WriteLine("The drive {0} could not be read", di.Name);
                    continue;
                }
                System.IO.DirectoryInfo rootDir = di.RootDirectory;
                WalkDirectoryTree(rootDir);
            }

            // Write out all the files that could not be processed.
            Console.WriteLine("Files with restricted access:");
            foreach (string s in log)
            {
                Console.WriteLine(s);
            }
            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key");
            Console.ReadKey();
        }

        static void WalkDirectoryTree(System.IO.DirectoryInfo root)
        {
            System.IO.FileInfo[] files = null;
            System.IO.DirectoryInfo[] subDirs = null;

            // First, process all the files directly under this folder
            try
            {
                files = root.GetFiles("*.*");
            }
            // This is thrown if even one of the files requires permissions greater
            // than the application provides.
            catch (UnauthorizedAccessException e)
            {
                // This code just writes out the message and continues to recurse.
                // You may decide to do something different here. For example, you
                // can try to elevate your privileges and access the file again.
                log.Add(e.Message);
            }

            catch (System.IO.DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            
            if (files != null)
            {
                foreach (System.IO.FileInfo fi in files)
                {
                    // In this example, we only access the existing FileInfo object. If we
                    // want to open, delete or modify the file, then
                    // a try-catch block is required here to handle the case
                    // where the file has been deleted since the call to TraverseTree().
                    Console.WriteLine(fi.FullName);
                }

                // Now find all the subdirectories under this directory.
                subDirs = root.GetDirectories();

                foreach (System.IO.DirectoryInfo dirInfo in subDirs)
                {
                    // Resursive call for each subdirectory.
                    WalkDirectoryTree(dirInfo);
                }
            }            
        }
    }
    //</snippet1>
    #endregion

    // How to: Iterate Through Folders without Using Recursion (C# Programming Guide)
    //<snippet2>
    public class StackBasedIteration
    {
        static void Main(string[] args)
        {
            // Specify the starting folder on the command line, or in 
            // Visual Studio in the Project > Properties > Debug pane.
            TraverseTree(args[0]);

            Console.WriteLine("Press any key");
            Console.ReadKey();
        }

        public static void TraverseTree(string root)
        {
            // Data structure to hold names of subfolders to be
            // examined for files.
            Stack<string> dirs = new Stack<string>(20);

            if (!System.IO.Directory.Exists(root))
            {
                throw new ArgumentException();
            }
            dirs.Push(root);

            while (dirs.Count > 0)
            {
                string currentDir = dirs.Pop();
                string[] subDirs;
                try
                {
                    subDirs = System.IO.Directory.GetDirectories(currentDir);
                }
                // An UnauthorizedAccessException exception will be thrown if we do not have
                // discovery permission on a folder or file. It may or may not be acceptable 
                // to ignore the exception and continue enumerating the remaining files and 
                // folders. It is also possible (but unlikely) that a DirectoryNotFound exception 
                // will be raised. This will happen if currentDir has been deleted by
                // another application or thread after our call to Directory.Exists. The 
                // choice of which exceptions to catch depends entirely on the specific task 
                // you are intending to perform and also on how much you know with certainty 
                // about the systems on which this code will run.
                catch (UnauthorizedAccessException e)
                {                    
                    Console.WriteLine(e.Message);
                    continue;
                }
                catch (System.IO.DirectoryNotFoundException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }

                string[] files = null;
                try
                {
                    files = System.IO.Directory.GetFiles(currentDir);
                }

                catch (UnauthorizedAccessException e)
                {
                    
                    Console.WriteLine(e.Message);
                    continue;
                }

                catch (System.IO.DirectoryNotFoundException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
                // Perform the required action on each file here.
                // Modify this block to perform your required task.
                foreach (string file in files)
                {
                    try
                    {
                        // Perform whatever action is required in your scenario.
                        System.IO.FileInfo fi = new System.IO.FileInfo(file);
                        Console.WriteLine("{0}: {1}, {2}", fi.Name, fi.Length, fi.CreationTime);
                    }
                    catch (System.IO.FileNotFoundException e)
                    {
                        // If file was deleted by a separate application
                        //  or thread since the call to TraverseTree()
                        // then just continue.
                        Console.WriteLine(e.Message);
                        continue;
                    }
                }

                // Push the subdirectories onto the stack for traversal.
                // This could also be done before handing the files.
                foreach (string str in subDirs)
                    dirs.Push(str);
            }
        }
    }
    //</snippet2>

    // How to: Write to a Text File 
    //<snippet3>
class WriteTextFile
{
    static void Main()
    {

        // These examples assume a "C:\Users\Public\TestFolder" folder on your machine.
        // You can modify the path if necessary.
        

        // Example #1: Write an array of strings to a file.
        // Create a string array that consists of three lines.
        string[] lines = { "First line", "Second line", "Third line" };
        // WriteAllLines creates a file, writes a collection of strings to the file,
        // and then closes the file.  You do NOT need to call Flush() or Close().
        System.IO.File.WriteAllLines(@"C:\Users\Public\TestFolder\WriteLines.txt", lines);


        // Example #2: Write one string to a text file.
        string text = "A class is the most powerful data type in C#. Like a structure, " +
                       "a class defines the data and behavior of the data type. ";
        // WriteAllText creates a file, writes the specified string to the file,
        // and then closes the file.    You do NOT need to call Flush() or Close().
        System.IO.File.WriteAllText(@"C:\Users\Public\TestFolder\WriteText.txt", text);

        // Example #3: Write only some strings in an array to a file.
        // The using statement automatically flushes AND CLOSES the stream and calls 
        // IDisposable.Dispose on the stream object.
        // NOTE: do not use FileStream for text files because it writes bytes, but StreamWriter
        // encodes the output as text.
        using (System.IO.StreamWriter file = 
            new System.IO.StreamWriter(@"C:\Users\Public\TestFolder\WriteLines2.txt"))
        {
            foreach (string line in lines)
            {
                // If the line doesn't contain the word 'Second', write the line to the file.
                if (!line.Contains("Second"))
                {
                    file.WriteLine(line);
                }
            }
        }

        // Example #4: Append new text to an existing file.
        // The using statement automatically flushes AND CLOSES the stream and calls 
        // IDisposable.Dispose on the stream object.
        using (System.IO.StreamWriter file = 
            new System.IO.StreamWriter(@"C:\Users\Public\TestFolder\WriteLines2.txt", true))
        {
            file.WriteLine("Fourth line");
        }
    }
}
 //Output (to WriteLines.txt):
 //   First line
 //   Second line
 //   Third line
     
 //Output (to WriteText.txt):
 //   A class is the most powerful data type in C#. Like a structure, a class defines the data and behavior of the data type.
     
 //Output to WriteLines2.txt after Example #3:
 //   First line
 //   Third line
      
 //Output to WriteLines2.txt after Example #4:
 //   First line
 //   Third line
 //   Fourth line
    //</snippet3>


    // How to: Read From a Text File
    //<snippet4>
    class ReadFromFile
    {
        static void Main()
        {
            // The files used in this example are created in the topic
            // How to: Write to a Text File. You can change the path and
            // file name to substitute text files of your own.

            // Example #1
            // Read the file as one string.
            string text = System.IO.File.ReadAllText(@"C:\Users\Public\TestFolder\WriteText.txt");

            // Display the file contents to the console. Variable text is a string.
            System.Console.WriteLine("Contents of WriteText.txt = {0}", text);

            // Example #2
            // Read each line of the file into a string array. Each element
            // of the array is one line of the file.
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Public\TestFolder\WriteLines2.txt");

            // Display the file contents by using a foreach loop.
            System.Console.WriteLine("Contents of WriteLines2.txt = ");
            foreach (string line in lines)
            {
                // Use a tab to indent each line of the file.
                Console.WriteLine("\t" + line);
            }

            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
        }
    }
    //</snippet4>

    //<snippet5>
    class FileTest
    {
        static void Main()
        {
            bool exists;
            string fileName = @"c:\users\public\TestFolder\test.txt";
            exists = System.IO.File.Exists(fileName);
            System.Console.Write(exists);

            string s = System.IO.File.ReadAllText(fileName);

            System.IO.StreamWriter sw = System.IO.File.AppendText(fileName);
            sw.WriteLine("new text");
            sw.Close();

            Console.WriteLine(s);

            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();

        }
    }
    //</snippet5>

    //<snippet6>
    class FileSysInfo
    {
        static void Main()
        {
            // You can also use System.Environment.GetLogicalDrives to
            // obtain names of all logical drives on the computer.
            System.IO.DriveInfo di = new System.IO.DriveInfo(@"C:\");
            Console.WriteLine(di.TotalFreeSpace);
            Console.WriteLine(di.VolumeLabel);

            // Get the root directory and print out some information about it.
            System.IO.DirectoryInfo dirInfo = di.RootDirectory;
            Console.WriteLine(dirInfo.Attributes.ToString());

            // Get the files in the directory and print out some information about them.
            System.IO.FileInfo[] fileNames = dirInfo.GetFiles("*.*");


            foreach (System.IO.FileInfo fi in fileNames)
            {
                Console.WriteLine("{0}: {1}: {2}", fi.Name, fi.LastAccessTime, fi.Length);
            }

            // Get the subdirectories directly that is under the root.
            // See "How to: Iterate Through a Directory Tree" for an example of how to
            // iterate through an entire tree.
            System.IO.DirectoryInfo[] dirInfos = dirInfo.GetDirectories("*.*");

            foreach (System.IO.DirectoryInfo d in dirInfos)
            {
                Console.WriteLine(d.Name);
            }

            // The Directory and File classes provide several static methods
            // for accessing files and directories.

            // Get the current application directory.
            string currentDirName = System.IO.Directory.GetCurrentDirectory();
            Console.WriteLine(currentDirName);           

            // Get an array of file names as strings rather than FileInfo objects.
            // Use this method when storage space is an issue, and when you might
            // hold on to the file name reference for a while before you try to access
            // the file.
            string[] files = System.IO.Directory.GetFiles(currentDirName, "*.txt");

            foreach (string s in files)
            {
                // Create the FileInfo object only when needed to ensure
                // the information is as current as possible.
                System.IO.FileInfo fi = null;
                try
                {
                     fi = new System.IO.FileInfo(s);
                }
                catch (System.IO.FileNotFoundException e)
                {
                    // To inform the user and continue is
                    // sufficient for this demonstration.
                    // Your application may require different behavior.
                    Console.WriteLine(e.Message);
                    continue;
                }
                Console.WriteLine("{0} : {1}",fi.Name, fi.Directory);
            }

            // Change the directory. In this case, first check to see
            // whether it already exists, and create it if it does not.
            // If this is not appropriate for your application, you can
            // handle the System.IO.IOException that will be raised if the
            // directory cannot be found.
            if (!System.IO.Directory.Exists(@"C:\Users\Public\TestFolder\"))
            {
                System.IO.Directory.CreateDirectory(@"C:\Users\Public\TestFolder\");
            }

            System.IO.Directory.SetCurrentDirectory(@"C:\Users\Public\TestFolder\");

            currentDirName = System.IO.Directory.GetCurrentDirectory();
            Console.WriteLine(currentDirName);

            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
    //</snippet6>

    //<snippet7>
    // Simple synchronous file copy operations with no user interface.
    // To run this sample, first create the following directories and files:
    // C:\Users\Public\TestFolder
    // C:\Users\Public\TestFolder\test.txt
    // C:\Users\Public\TestFolder\SubDir\test.txt
    public class SimpleFileCopy
    {
        static void Main()
        {
            string fileName = "test.txt";
            string sourcePath = @"C:\Users\Public\TestFolder";
            string targetPath =  @"C:\Users\Public\TestFolder\SubDir";

            // Use Path class to manipulate file and directory paths.
            string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
            string destFile = System.IO.Path.Combine(targetPath, fileName);

            // To copy a folder's contents to a new location:
            // Create a new target folder, if necessary.
            if (!System.IO.Directory.Exists(targetPath))
            {
                System.IO.Directory.CreateDirectory(targetPath);
            }

            // To copy a file to another location and 
            // overwrite the destination file if it already exists.
            System.IO.File.Copy(sourceFile, destFile, true);
            
            // To copy all the files in one directory to another directory.
            // Get the files in the source folder. (To recursively iterate through
            // all subfolders under the current directory, see
            // "How to: Iterate Through a Directory Tree.")
            // Note: Check for target path was performed previously
            //       in this code example.
            if (System.IO.Directory.Exists(sourcePath))
            {
                string[] files = System.IO.Directory.GetFiles(sourcePath);

                // Copy the files and overwrite destination files if they already exist.
                foreach (string s in files)
                {
                    // Use static Path methods to extract only the file name from the path.
                    fileName = System.IO.Path.GetFileName(s);
                    destFile = System.IO.Path.Combine(targetPath, fileName);
                    System.IO.File.Copy(s, destFile, true);
                }
            }
            else
            {
                Console.WriteLine("Source path does not exist!");
            }

            // Keep console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
    //</snippet7>

    //<snippet8>
    // Simple synchronous file move operations with no user interface.
    public class SimpleFileMove
    {
        static void Main()
        {
            string sourceFile = @"C:\Users\Public\public\test.txt";
            string destinationFile = @"C:\Users\Public\private\test.txt";

            // To move a file or folder to a new location:
            System.IO.File.Move(sourceFile, destinationFile);

            // To move an entire directory. To programmatically modify or combine
            // path strings, use the System.IO.Path class.
            System.IO.Directory.Move(@"C:\Users\Public\public\test\", @"C:\Users\Public\private");
        }
    }
    //</snippet8>

    //<snippet9>
    // Simple synchronous file deletion operations with no user interface.
    // To run this sample, create the following files on your drive:
    // C:\Users\Public\DeleteTest\test1.txt
    // C:\Users\Public\DeleteTest\test2.txt
    // C:\Users\Public\DeleteTest\SubDir\test2.txt

    public class SimpleFileDelete
    {
        static void Main()
        {
            // Delete a file by using File class static method...
            if(System.IO.File.Exists(@"C:\Users\Public\DeleteTest\test.txt"))
            {
                // Use a try block to catch IOExceptions, to
                // handle the case of the file already being
                // opened by another process.
                try
                {
                    System.IO.File.Delete(@"C:\Users\Public\DeleteTest\test.txt");
                }
                catch (System.IO.IOException e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
            }

            // ...or by using FileInfo instance method.
            System.IO.FileInfo fi = new System.IO.FileInfo(@"C:\Users\Public\DeleteTest\test2.txt");
            try
            {
                fi.Delete();
            }
            catch (System.IO.IOException e)
            {
                Console.WriteLine(e.Message);
            }

            // Delete a directory. Must be writable or empty.
            try
            {
                System.IO.Directory.Delete(@"C:\Users\Public\DeleteTest");
            }
            catch (System.IO.IOException e)
            {
                Console.WriteLine(e.Message);
            }
            // Delete a directory and all subdirectories with Directory static method...
            if(System.IO.Directory.Exists(@"C:\Users\Public\DeleteTest"))
            {
                try
                {
                    System.IO.Directory.Delete(@"C:\Users\Public\DeleteTest", true);
                }

                catch (System.IO.IOException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            // ...or with DirectoryInfo instance method.
            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(@"C:\Users\Public\public");
            // Delete this dir and all subdirs.
            try
            {
                di.Delete(true);
            }
            catch (System.IO.IOException e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
    //</snippet9>

    //<snippet10>
public class CreateFileOrFolder
{
    static void Main()
    {
        // Specify a name for your top-level folder.
        string folderName = @"c:\Top-Level Folder";

        // To create a string that specifies the path to a subfolder under your 
        // top-level folder, add a name for the subfolder to folderName.
        string pathString = System.IO.Path.Combine(folderName, "SubFolder");

        // You can write out the path name directly instead of using the Combine
        // method. Combine just makes the process easier.
        string pathString2 = @"c:\Top-Level Folder\SubFolder2";

        // You can extend the depth of your path if you want to.
        //pathString = System.IO.Path.Combine(pathString, "SubSubFolder");

        // Create the subfolder. You can verify in File Explorer that you have this
        // structure in the C: drive.
        //    Local Disk (C:)
        //        Top-Level Folder
        //            SubFolder
        System.IO.Directory.CreateDirectory(pathString);

        // Create a file name for the file you want to create. 
        string fileName = System.IO.Path.GetRandomFileName();

        // This example uses a random string for the name, but you also can specify
        // a particular name.
        //string fileName = "MyNewFile.txt";

        // Use Combine again to add the file name to the path.
        pathString = System.IO.Path.Combine(pathString, fileName);

        // Verify the path that you have constructed.
        Console.WriteLine("Path to my file: {0}\n", pathString);

        // Check that the file doesn't already exist. If it doesn't exist, create
        // the file and write integers 0 - 99 to it.
        // DANGER: System.IO.File.Create will overwrite the file if it already exists.
        // This could happen even with random file names, although it is unlikely.
        if (!System.IO.File.Exists(pathString))
        {
            using (System.IO.FileStream fs = System.IO.File.Create(pathString))
            {
                for (byte i = 0; i < 100; i++)
                {
                    fs.WriteByte(i);
                }
            }
        }
        else
        {
            Console.WriteLine("File \"{0}\" already exists.", fileName);
            return;
        }

        // Read and display the data from your file.
        try
        {
            byte[] readBuffer = System.IO.File.ReadAllBytes(pathString);
            foreach (byte b in readBuffer)
            {
                Console.Write(b + " ");
            }
            Console.WriteLine();
        }
        catch (System.IO.IOException e)
        {
            Console.WriteLine(e.Message);
        }

        // Keep the console window open in debug mode.
        System.Console.WriteLine("Press any key to exit.");
        System.Console.ReadKey();
    }
    // Sample output:

    // Path to my file: c:\Top-Level Folder\SubFolder\ttxvauxe.vv0

    //0 1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29
    //30 31 32 33 34 35 36 37 38 39 40 41 42 43 44 45 46 47 48 49 50 51 52 53 54 55 56
    // 57 58 59 60 61 62 63 64 65 66 67 68 69 70 71 72 73 74 75 76 77 78 79 80 81 82 8
    //3 84 85 86 87 88 89 90 91 92 93 94 95 96 97 98 99
}
    //</snippet10>

    namespace FileProgressNamespace
    {
        
        //<snippet11>
        // The following using directive requires a project reference to Microsoft.VisualBasic.
        using Microsoft.VisualBasic.FileIO;

        class FileProgress
        {
            static void Main()
            {
                // Specify the path to a folder that you want to copy. If the folder is small, 
                // you won't have time to see the progress dialog box.
                string sourcePath = @"C:\Windows\symbols\";
                // Choose a destination for the copied files.
                string destinationPath = @"C:\TestFolder";

                FileSystem.CopyDirectory(sourcePath, destinationPath,
                    UIOption.AllDialogs);
            }
        }
        //</snippet11>
    }

    #region NOT IN USE
    //// This contains code pulled from FileList
    //// for iterating through folders.
    //public class FolderIteration
    //{
    //    public static List<System.IO.DirectoryInfo> GetFolders(string root)
    //    {
    //        List<System.IO.DirectoryInfo> folderList = new List<System.IO.DirectoryInfo>();
    //        List<string> errList = new List<string>();

    //        FillDirectoryInfoList(folderList, errList, root);

    //        // Do something with the error list if necessary here, for example write it to disk,
    //        // or try other techniques to access files that failed on the initial attempt. 
    //        foreach (string currentDir in errList)
    //            Console.WriteLine(currentDir);

    //        return folderList;
    //    }

    //    // Called from GetFolders. This method creates a flat list of
    //    // DirectoryInfo objects that represent all the folders under the 
    //    // specified root folder.
    //    static void FillDirectoryInfoList(List<System.IO.DirectoryInfo> folderList, List<String> errorList, string startPath)
    //    {
    //        System.IO.DirectoryInfo[] dinfos;
    //        System.IO.DirectoryInfo root = new System.IO.DirectoryInfo(startPath);
    //        try
    //        {
    //            dinfos = root.GetDirectories();
    //        }

    //        // This code catches two common exceptions. The choice
    //        // of which exceptions to catch depends on how much you
    //        // know with certainty about the systems on which this code will run.
    //        catch (UnauthorizedAccessException e)
    //        {
    //            errorList.Add(e.Message);
    //            return;
    //        }
    //        catch (System.IO.DirectoryNotFoundException e)
    //        {
    //            errorList.Add(e.Message);
    //            return;
    //        }
    //        foreach (System.IO.DirectoryInfo di in dinfos)
    //        {
    //            // Never attempt to recurse through reparse points.
    //            if ((di.Attributes & System.IO.FileAttributes.ReparsePoint) != System.IO.FileAttributes.ReparsePoint)
    //            {
    //                folderList.Add(di);
    //                FillDirectoryInfoList(folderList, errorList, di.FullName);
    //            }
    //            else
    //            {
    //                errorList.Add(String.Format("{0} is a reparse point", di.Name));
    //            }
    //        }
    //    }

    //}

    ////NOT IN BUILD How to: Iterate Through Folders  Recursively (C# Programming Guide)
    //// this version makes a copy of everything.
   

    //public class RecursiveFileSearch2
    //{
    //    static void Main()
    //    {
    //        RecursiveFileSearch files = new RecursiveFileSearch();

    //        List<System.IO.FileInfo> list = files.TraverseTree(@"c:\");
    //        foreach (System.IO.FileInfo fi in list)
    //            Console.WriteLine(fi.FullName);

    //        Console.WriteLine("Press any key");
    //        Console.ReadKey();
    //    }

    //    void FillFileInfoList(List<System.IO.FileInfo> fileList, string startPath)
    //    {
    //        System.IO.DirectoryInfo[] dinfos;
    //        System.IO.DirectoryInfo root = new System.IO.DirectoryInfo(startPath);

    //        // This code catches two common exceptions. The choice
    //        // of which exceptions to catch depends on how much you
    //        // know with certainty about the systems on which this code will run.
    //        try
    //        {
    //            dinfos = root.GetDirectories();
    //        }
    //        catch (UnauthorizedAccessException e)
    //        {
    //            // This code just writes out the message and continues to recurse.
    //            // You may decide to do something different here.
    //            Console.WriteLine(e.Message);
    //            return;
    //        }
    //        catch (System.IO.DirectoryNotFoundException e)
    //        {
    //            // This code just writes out the message and continues to recurse.
    //            // You may decide to do something different here.
    //            Console.WriteLine(e.Message);
    //            return;
    //        }

    //        foreach (System.IO.DirectoryInfo di in dinfos)
    //        {
    //            System.IO.FileInfo[] fileInfos;
    //            try
    //            {
    //                fileInfos = di.TraverseTree();
    //            }
    //            catch (UnauthorizedAccessException e)
    //            {
    //                // This code just writes out the message and continues to recurse.
    //                // You may decide to do something different here.
    //                Console.WriteLine(e.Message);
    //                continue;
    //            }

    //            foreach (System.IO.FileInfo fi in fileInfos)
    //            {
    //                fileList.Add(fi);
    //            }
    //            //Now recurse through the subfolders under this directory
    //            FillFileInfoList(fileList, di.FullName);
    //        }
    //    }


    //    public List<System.IO.FileInfo> TraverseTree(string root)
    //    {
    //        // List to store the returned FileInfo objects
    //        List<System.IO.FileInfo> list = new List<System.IO.FileInfo>();

    //        //Get the files in the start folder first
    //        foreach (string name in System.IO.Directory.TraverseTree(root))
    //        {
    //            System.IO.FileInfo fi = new System.IO.FileInfo(name);
    //            list.Add(fi);
    //        }

    //        FillFileInfoList(list, root);
    //        return list;
    //    }
    //}
    
    #endregion
}
