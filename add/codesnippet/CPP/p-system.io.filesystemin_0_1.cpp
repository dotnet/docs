        static void DisplayFileSystemInfoAttributes(FileSystemInfo^ fsi)
        {
            //  Assume that this entry is a file.
            String^ entryType = "File";

            // Determine if entry is really a directory
            if ((fsi->Attributes & FileAttributes::Directory) == FileAttributes::Directory)
            {
                entryType = "Directory";
            }
            //  Show this entry's type, name, and creation date.
            Console::WriteLine("{0} entry {1} was created on {2:D}", entryType, fsi->FullName, fsi->CreationTime);
        }