        isoFile = IsolatedStorageFile.GetStore(IsolatedStorageScope.Assembly |
            IsolatedStorageScope.Domain | IsolatedStorageScope.User,
            null, null);