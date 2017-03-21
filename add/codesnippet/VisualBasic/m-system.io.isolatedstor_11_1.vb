        Public Sub DeleteFiles()
            Try
                Dim isoFile As IsolatedStorageFile = IsolatedStorageFile.GetStore(IsolatedStorageScope.User Or _
                    IsolatedStorageScope.Assembly Or IsolatedStorageScope.Domain, _
                    GetType(System.Security.Policy.Url), GetType(System.Security.Policy.Url))
                Dim name As String
                Dim dirNames As String() = isoFile.GetDirectoryNames("*")
                Dim fileNames As String() = isoFile.GetFileNames("*")
                ' List the files currently in this Isolated Storage.
                ' The list represents all users who have personal
                ' preferences stored for this application.
                If fileNames.Length > 0 Then
                    For Each name In fileNames
                        ' Delete the files.
                        isoFile.DeleteFile(name)
                    Next name
                    'Confirm no files are left.
                    fileNames = isoFile.GetFileNames("*")
                End If
            Catch ex As Exception
                Console.WriteLine(ex.ToString())
            End Try
        End Sub 'DeleteFiles
