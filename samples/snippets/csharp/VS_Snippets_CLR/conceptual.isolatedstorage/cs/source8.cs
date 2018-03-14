//<snippet9>
using System;
using System.IO;
using System.IO.IsolatedStorage;
using System.Collections;
using System.Collections.Generic;

public class FindingExistingFilesAndDirectories
{
    // Retrieves an array of all directories in the store, and
    // displays the results.
    public static void Main()
    {
        // This part of the code sets up a few directories and files in the
        // store.
        IsolatedStorageFile isoStore = IsolatedStorageFile.GetStore(IsolatedStorageScope.User |
            IsolatedStorageScope.Assembly, null, null);
        isoStore.CreateDirectory("TopLevelDirectory");
        isoStore.CreateDirectory("TopLevelDirectory/SecondLevel");
        isoStore.CreateDirectory("AnotherTopLevelDirectory/InsideDirectory");
        isoStore.CreateFile("InTheRoot.txt");
        isoStore.CreateFile("AnotherTopLevelDirectory/InsideDirectory/HereIAm.txt");
        // End of setup.

        Console.WriteLine('\r');
        Console.WriteLine("Here is a list of all directories in this isolated store:");

        foreach (string directory in GetAllDirectories("*", isoStore))
        {
            Console.WriteLine(directory);
        }
        Console.WriteLine('\r');

        // Retrieve all the files in the directory by calling the GetFiles
        // method.

        Console.WriteLine("Here is a list of all the files in this isolated store:");
        foreach (string file in GetAllFiles("*", isoStore)){
            Console.WriteLine(file);
        }

    } // End of Main.

    // Method to retrieve all directories, recursively, within a store.
    public static List<String> GetAllDirectories(string pattern, IsolatedStorageFile storeFile)
    {
        // Get the root of the search string.
        string root = Path.GetDirectoryName(pattern);

        if (root != "")
        {
            root += "/";
        }

        // Retrieve directories.
        List<String> directoryList = new List<String>(storeFile.GetDirectoryNames(pattern));

        // Retrieve subdirectories of matches.
        for (int i = 0, max = directoryList.Count; i < max; i++)
        {
            string directory = directoryList[i] + "/";
            List<String> more = GetAllDirectories(root + directory + "*", storeFile);

            // For each subdirectory found, add in the base path.
            for (int j = 0; j < more.Count; j++)
            {
                more[j] = directory + more[j];
            }

            // Insert the subdirectories into the list and
            // update the counter and upper bound.
            directoryList.InsertRange(i + 1, more);
            i += more.Count;
            max += more.Count;
        }

        return directoryList;
    }

    public static List<String> GetAllFiles(string pattern, IsolatedStorageFile storeFile)
    {
        // Get the root and file portions of the search string.
        string fileString = Path.GetFileName(pattern);

        List<String> fileList = new List<String>(storeFile.GetFileNames(pattern));

        // Loop through the subdirectories, collect matches,
        // and make separators consistent.
        foreach (string directory in GetAllDirectories("*", storeFile))
        {
            foreach (string file in storeFile.GetFileNames(directory + "/" + fileString))
            {
                fileList.Add((directory + "/" + file));
            }
        }

        return fileList;
    } // End of GetFiles.
}
//</snippet9>
