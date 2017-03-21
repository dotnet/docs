        isoFile = IsolatedStorageFile.GetStore(IsolatedStorageScope.Assembly Or _
            IsolatedStorageScope.Domain Or IsolatedStorageScope.Machine, _
            Nothing, Nothing)