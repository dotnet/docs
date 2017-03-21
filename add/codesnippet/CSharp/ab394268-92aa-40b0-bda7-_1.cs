
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