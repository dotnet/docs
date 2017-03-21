
            // Open or create a writable file with a maximum size of 10K.
            IsolatedStorageFileStream isoStream =
                new IsolatedStorageFileStream(this.userName,
                FileMode.OpenOrCreate,
                FileAccess.Write,
                FileShare.Write,
                10240,
                isoFile);