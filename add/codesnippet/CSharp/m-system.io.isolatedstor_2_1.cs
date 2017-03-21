            IsolatedStorageFile isoFile;
            isoFile = IsolatedStorageFile.GetUserStoreForDomain();

            // Open or create a writable file.
            IsolatedStorageFileStream isoStream =
                new IsolatedStorageFileStream(this.userName,
                FileMode.OpenOrCreate,
                FileAccess.Write,
                isoFile);

            StreamWriter writer = new StreamWriter(isoStream);
            writer.WriteLine(this.NewsUrl);
            writer.WriteLine(this.SportsUrl);
            // Calculate the amount of space used to record the user's preferences.
            double d = isoFile.CurrentSize / isoFile.MaximumSize;
            Console.WriteLine("CurrentSize = " + isoFile.CurrentSize.ToString());
            Console.WriteLine("MaximumSize = " + isoFile.MaximumSize.ToString());
            // StreamWriter.Close implicitly closes isoStream.
            writer.Close();
            isoFile.Dispose();
            isoFile.Close();
            return d;