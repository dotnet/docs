    public void DeleteFiles()
    {
        try
        {
            IsolatedStorageFile isoFile = IsolatedStorageFile.GetStore(IsolatedStorageScope.User |
                IsolatedStorageScope.Assembly |
                IsolatedStorageScope.Domain,
                typeof(System.Security.Policy.Url),
                typeof(System.Security.Policy.Url));

            String[] dirNames = isoFile.GetDirectoryNames("*");
            String[] fileNames = isoFile.GetFileNames("*");

            // List the files currently in this Isolated Storage.
            // The list represents all users who have personal
            // preferences stored for this application.
            if (fileNames.Length > 0)
            {
                for (int i = 0; i < fileNames.Length; ++i)
                {
                    // Delete the files.
                    isoFile.DeleteFile(fileNames[i]);
                }
                // Confirm that no files remain.
                fileNames = isoFile.GetFileNames("*");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }

    }