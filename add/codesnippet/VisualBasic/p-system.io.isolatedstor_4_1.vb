        Private Function GetPrefsForUser() As Boolean
            Try
                ' Retrieve an IsolatedStorageFile for the current Domain and Assembly.
                Dim isoFile As IsolatedStorageFile = _
                    IsolatedStorageFile.GetStore(IsolatedStorageScope.User _
                    Or IsolatedStorageScope.Assembly _
                    Or IsolatedStorageScope.Domain, Nothing, Nothing)

                Dim isoStream As New IsolatedStorageFileStream("substituteUsername", System.IO.FileMode.Open, _
                    System.IO.FileAccess.Read, System.IO.FileShare.Read)
                ' farThe code executes to this point only if a file corresponding to the username exists.
                ' Though you can perform operations on the stream, you cannot get a handle to the file.
                Try

                    Dim aFileHandle As SafeFileHandle = isoStream.SafeFileHandle
                    Console.WriteLine(("A pointer to a file handle has been obtained. " & aFileHandle.ToString() & " " & aFileHandle.GetHashCode()))

                Catch ex As Exception
                    ' Handle the exception.
                    Console.WriteLine("Expected exception")
                    Console.WriteLine(ex.ToString())
                End Try

                Dim reader As New StreamReader(isoStream)
                ' Read the data.
                Me.NewsUrl = reader.ReadLine()
                Me.SportsUrl = reader.ReadLine()
                reader.Close()
                isoFile.Close()
                Return False
            Catch ex As System.IO.FileNotFoundException
                ' Expected exception if a file cannot be found. This indicates that we have a new user.
                Return True
            End Try
        End Function 'GetPrefsForUser
