    public double SetNewPrefsForUser()
    {
        try
        {
            byte inputChar;
            IsolatedStorageFile isoFile = IsolatedStorageFile.GetStore(IsolatedStorageScope.User |
                IsolatedStorageScope.Assembly |
                IsolatedStorageScope.Domain,
                typeof(System.Security.Policy.Url),
                typeof(System.Security.Policy.Url));

            // If this is not a new user, archive the old preferences and 
            // overwrite them using the new preferences.
            if (!this.myNewPrefs)
            {
                if (isoFile.GetDirectoryNames("Archive").Length == 0)
                    isoFile.CreateDirectory("Archive");
                else
                {

                    IsolatedStorageFileStream source =
                        new IsolatedStorageFileStream(this.userName, FileMode.OpenOrCreate,
                        isoFile);
                    // This is the stream from which data will be read.
                    Console.WriteLine("Is the source file readable? " + (source.CanRead ? "true" : "false"));
                    Console.WriteLine("Creating new IsolatedStorageFileStream for Archive.");

                    // Open or create a writable file.
                    IsolatedStorageFileStream target =
                        new IsolatedStorageFileStream("Archive\\ " + this.userName,
                        FileMode.OpenOrCreate,
                        FileAccess.Write,
                        FileShare.Write,
                        isoFile);
                    Console.WriteLine("Is the target file writable? " + (target.CanWrite ? "true" : "false"));
                    // Stream the old file to a new file in the Archive directory.
                    if (source.IsAsync && target.IsAsync)
                    {
                        // IsolatedStorageFileStreams cannot be asynchronous.  However, you
                        // can use the asynchronous BeginRead and BeginWrite functions
                        // with some possible performance penalty.

                        Console.WriteLine("IsolatedStorageFileStreams cannot be asynchronous.");
                    }

                    else
                    {
                        Console.WriteLine("Writing data to the new file.");
                        while (source.Position < source.Length)
                        {
                            inputChar = (byte)source.ReadByte();
                            target.WriteByte(inputChar);
                        }

                        // Determine the size of the IsolatedStorageFileStream
                        // by checking its Length property.
                        Console.WriteLine("Total Bytes Read: " + source.Length);

                    }

                    // After you have read and written to the streams, close them.
                    target.Close();
                    source.Close();
                }
            }

            // Open or create a writable file with a maximum size of 10K.
            IsolatedStorageFileStream isoStream =
                new IsolatedStorageFileStream(this.userName,
                FileMode.OpenOrCreate,
                FileAccess.Write,
                FileShare.Write,
                10240,
                isoFile);
            isoStream.Position = 0;  // Position to overwrite the old data.