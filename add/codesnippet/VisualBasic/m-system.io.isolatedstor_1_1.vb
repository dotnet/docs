        isoFile = IsolatedStorageFile.GetStore(IsolatedStorageScope.Assembly Or _
            IsolatedStorageScope.Domain Or IsolatedStorageScope.User, _
             Nothing, Nothing)