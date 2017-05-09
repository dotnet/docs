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

            Console.WriteLine("Enter a search string (for example *p*):");

            string searchString = Console.ReadLine();

            // Create a new DirectoryInfo object.
            DirectoryInfo dir = new DirectoryInfo(directory);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException("The directory does not exist.");
            }

            // Call the GetFileSystemInfos method.
            FileSystemInfo[] infos = dir.GetFileSystemInfos(searchString);

            Console.WriteLine("Working...");

            // Pass the result to the ListDirectoriesAndFiles
            // method defined below.
            ListDirectoriesAndFiles(infos, searchString);

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

    static void ListDirectoriesAndFiles(FileSystemInfo[] FSInfo, string SearchString)
    {
        // Check the parameters.
        if (FSInfo == null)
        {
            throw new ArgumentNullException("FSInfo");
        }
        if (SearchString == null || SearchString.Length == 0)
        {
            throw new ArgumentNullException("SearchString");
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
                ListDirectoriesAndFiles(dInfo.GetFileSystemInfos(SearchString), SearchString);
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