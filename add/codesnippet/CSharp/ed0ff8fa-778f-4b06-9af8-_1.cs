
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