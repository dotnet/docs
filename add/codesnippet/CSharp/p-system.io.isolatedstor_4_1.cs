    private bool GetPrefsForUser()
    {
        try
        {

            // Retrieve an IsolatedStorageFile for the current Domain and Assembly.
            IsolatedStorageFile isoFile =
                IsolatedStorageFile.GetStore(IsolatedStorageScope.User |
                IsolatedStorageScope.Assembly |
                IsolatedStorageScope.Domain,
                null,
                null);

            IsolatedStorageFileStream isoStream =
                new IsolatedStorageFileStream("substituteUsername",
                System.IO.FileMode.Open,
                System.IO.FileAccess.Read,
                 System.IO.FileShare.Read);

            // The code executes to this point only if a file corresponding to the username exists.
            // Though you can perform operations on the stream, you cannot get a handle to the file.

            try
            {

                SafeFileHandle aFileHandle = isoStream.SafeFileHandle;
                Console.WriteLine("A pointer to a file handle has been obtained. "
                    + aFileHandle.ToString() + " "
                    + aFileHandle.GetHashCode());
            }

            catch (Exception e)
            {
                // Handle the exception.
                Console.WriteLine("Expected exception");
                Console.WriteLine(e);
            }

            StreamReader reader = new StreamReader(isoStream);
            // Read the data.
            this.NewsUrl = reader.ReadLine();
            this.SportsUrl = reader.ReadLine();
            reader.Close();
            isoFile.Close();
            return false;
        }
        catch (System.IO.FileNotFoundException)
        {
            // Expected exception if a file cannot be found. This indicates that we have a new user.
            return true;
        }
    }