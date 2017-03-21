        Public Function SetNewPrefsForUser() As Double
            Try
                Dim inputChar As Byte
                Dim isoFile As IsolatedStorageFile = IsolatedStorageFile.GetStore(IsolatedStorageScope.User Or _
                    IsolatedStorageScope.Assembly Or IsolatedStorageScope.Domain, _
                    GetType(System.Security.Policy.Url), GetType(System.Security.Policy.Url))

                ' If this is not a new user, archive the old preferences and 
                ' overwrite them using the new preferences.
                If Not Me.myNewPrefs Then
                    If isoFile.GetDirectoryNames("Archive").Length = 0 Then
                        isoFile.CreateDirectory("Archive")
                    Else

                        Dim source As New IsolatedStorageFileStream(Me.userName, FileMode.OpenOrCreate, isoFile)
                        Dim canWrite, canRead As Boolean
                        ' This is the stream from which data will be read.
                        If source.CanRead Then canRead = True Else canRead = False
                        Console.WriteLine("Is the source file readable? " & canRead)
                        Console.WriteLine("Creating new IsolatedStorageFileStream for Archive.")
                        ' Open or create a writable file.
                        Dim target As New IsolatedStorageFileStream("Archive\ " & Me.userName, _
                             FileMode.OpenOrCreate, FileAccess.Write, FileShare.Write, isoFile)
                        ' This is the stream to which data will be written.
                        If target.CanWrite Then canWrite = True Else canWrite = False
                        Console.WriteLine("Is the target file writable? " & canWrite)
                        target.SetLength(0)  'rewind the target file

                        ' Stream the old file to a new file in the Archive directory.
                        If source.IsAsync And target.IsAsync Then
                            ' IsolatedStorageFileStreams cannot be asynchronous.  However, you
                            ' can use the asynchronous BeginRead and BeginWrite functions
                            ' with some possible performance penalty.
                            Console.WriteLine("IsolatedStorageFileStreams cannot be asynchronous.")
                        Else
                            Console.WriteLine("Writing data to the new file.")
                            While source.Position < source.Length
                                inputChar = CByte(source.ReadByte())
                                target.WriteByte(inputChar)
                            End While

                            ' Determine the size of the IsolatedStorageFileStream
                            ' by checking its Length property.
                            Console.WriteLine(("Total Bytes Read: " & source.Length))
                        End If

                        ' After you have read and written to the streams, close them.	
                        target.Close()
                        source.Close()
                    End If
                End If
                ' Open or create a writable file with a maximum size of 10K.
                Dim isoStream As New IsolatedStorageFileStream(Me.userName, FileMode.OpenOrCreate, _
                    FileAccess.Write, FileShare.Write, 10240, isoFile)
                isoStream.SetLength(0) 'Position to overwrite the old data.