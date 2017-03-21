    // This method deletes directories in the specified Isolated Storage, after first 
    // deleting the files they contain. In this example, the Archive directory is deleted. 
    // There should be no other directories in this Isolated Storage.
    public void DeleteDirectories()
    {
        try
        {
            IsolatedStorageFile isoFile = IsolatedStorageFile.GetStore(IsolatedStorageScope.User |
                IsolatedStorageScope.Assembly |
                IsolatedStorageScope.Domain,
                typeof(System.Security.Policy.Url),
                typeof(System.Security.Policy.Url));
            String[] dirNames = isoFile.GetDirectoryNames("*");
            String[] fileNames = isoFile.GetFileNames("Archive\\*");

            // Delete all the files currently in the Archive directory.

            if (fileNames.Length > 0)
            {
                for (int i = 0; i < fileNames.Length; ++i)
                {
                    // Delete the files.
                    isoFile.DeleteFile("Archive\\" + fileNames[i]);
                }
                // Confirm that no files remain.
                fileNames = isoFile.GetFileNames("Archive\\*");
            }


            if (dirNames.Length > 0)
            {
                for (int i = 0; i < dirNames.Length; ++i)
                {
                    // Delete the Archive directory.
                }
            }
            dirNames = isoFile.GetDirectoryNames("*");
            isoFile.Remove();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }
    }