                Dim isoFile As IsolatedStorageFile
                isoFile = IsolatedStorageFile.GetUserStoreForDomain()

                ' Open or create a writable file.
                Dim isoStream As New IsolatedStorageFileStream(Me.userName, FileMode.OpenOrCreate, _
                    FileAccess.Write, isoFile)

                Dim writer As New StreamWriter(isoStream)
                writer.WriteLine(Me.NewsUrl)
                writer.WriteLine(Me.SportsUrl)
                ' Calculate the amount of space used to record the user's preferences.
                Dim d As Double = Convert.ToDouble(isoFile.CurrentSize) / Convert.ToDouble(isoFile.MaximumSize)
                Console.WriteLine(("CurrentSize = " & isoFile.CurrentSize.ToString()))
                Console.WriteLine(("MaximumSize = " & isoFile.MaximumSize.ToString()))
                ' StreamWriter.Close implicitly closes isoStream.
                writer.Close()
                isoFile.Dispose()
                isoFile.Close()
                Return d