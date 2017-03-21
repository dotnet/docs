                ' Retrieve an IsolatedStorageFile for the current Domain and Assembly.
                Dim isoFile As IsolatedStorageFile = _
                    IsolatedStorageFile.GetStore(IsolatedStorageScope.User _
                    Or IsolatedStorageScope.Assembly _
                    Or IsolatedStorageScope.Domain, Nothing, Nothing)

                Dim isoStream As New IsolatedStorageFileStream("substituteUsername", System.IO.FileMode.Open, _
                    System.IO.FileAccess.Read, System.IO.FileShare.Read)