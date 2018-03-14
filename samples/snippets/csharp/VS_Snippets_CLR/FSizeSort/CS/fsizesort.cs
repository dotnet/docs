// <Snippet1>
using System;
using System.IO;

class DirectoryFileCount
{

    static long files = 0;
    static long directories = 0;


    static void Main()
    {
        try
        {
            Console.WriteLine("Enter the path to a directory:");

            string directory = Console.ReadLine();

            // Create a new DirectoryInfo object.
            DirectoryInfo dir = new DirectoryInfo(directory);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException("The directory does not exist.");
            }

            // Call the GetFileSystemInfos method.
            FileSystemInfo[] infos = dir.GetFileSystemInfos();

            Console.WriteLine("Working...");

            // Pass the result to the ListDirectoriesAndFiles
            // method defined below.
            ListDirectoriesAndFiles(infos);

            // Display the results to the console. 
            Console.WriteLine("Directories: {0}", directories);
            Console.WriteLine("Files: {0}", files);

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {

            Console.ReadLine();
        }
    }

    static void ListDirectoriesAndFiles(FileSystemInfo[] FSInfo)
    {
        // Check the FSInfo parameter.
        if (FSInfo == null)
        {
            throw new ArgumentNullException("FSInfo");
        }

        // Iterate through each item.
        foreach (FileSystemInfo i in FSInfo)
        {
            // Check to see if this is a DirectoryInfo object.
            if (i is DirectoryInfo)
            {
                // Add one to the directory count.
                directories++;

                // Cast the object to a DirectoryInfo object.
                DirectoryInfo dInfo = (DirectoryInfo)i;

                // Iterate through all sub-directories.
                ListDirectoriesAndFiles(dInfo.GetFileSystemInfos());
            }
            // Check to see if this is a FileInfo object.
            else if (i is FileInfo)
            {
                // Add one to the file count.
                files++;

            }

        }
    }
}
// </Snippet1>