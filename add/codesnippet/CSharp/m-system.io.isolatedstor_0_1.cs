        isoFile = IsolatedStorageFile.GetStore(IsolatedStorageScope.Assembly |
            IsolatedStorageScope.Domain | IsolatedStorageScope.Machine,
            null, null);