                        ' Open or create a writable file.
                        Dim target As New IsolatedStorageFileStream("Archive\ " & Me.userName, _
                             FileMode.OpenOrCreate, FileAccess.Write, FileShare.Write, isoFile)