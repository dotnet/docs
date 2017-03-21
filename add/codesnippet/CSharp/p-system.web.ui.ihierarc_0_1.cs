        // DirectoryInfo returns the OriginalPath, while FileInfo returns
        // a fully qualified path.
        public string Path
        {
            get
            {
                return fileSystemObject.ToString();
            }
        }