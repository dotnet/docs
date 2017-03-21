                ' Open or create a writable file with a maximum size of 10K.
                Dim isoStream As New IsolatedStorageFileStream(Me.userName, FileMode.OpenOrCreate, _
                    FileAccess.Write, FileShare.Write, 10240, isoFile)