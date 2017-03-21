        ' This method deletes directories in the specified Isolated Storage, after first 
        ' deleting the files they contain. In this example, the Archive directory is deleted. 
        ' There should be no other directories in this Isolated Storage.
        Public Sub DeleteDirectories()
            Try
                Dim isoFile As IsolatedStorageFile = IsolatedStorageFile.GetStore(IsolatedStorageScope.User _
                    Or IsolatedStorageScope.Assembly Or IsolatedStorageScope.Domain, _
                    GetType(System.Security.Policy.Url), GetType(System.Security.Policy.Url))
                Dim name As String
                Dim dirNames As String() = isoFile.GetDirectoryNames("*")
                Dim fileNames As String() = isoFile.GetFileNames("Archive\*")
                ' Delete all the files currently in the Archive directory.
                If fileNames.Length > 0 Then
                    For Each name In fileNames
                        isoFile.DeleteFile(("Archive\" & name))
                    Next name
                    'Confirm no files are left.
                    fileNames = isoFile.GetFileNames("Archive\*")
                End If
                If dirNames.Length > 0 Then
                    For Each name In dirNames
                        ' Delete the Archive directory.
                        isoFile.DeleteDirectory(name)
                    Next name
                End If
                dirNames = isoFile.GetDirectoryNames("*")
                isoFile.Remove()
            Catch ex As Exception
                Console.WriteLine(ex.ToString())
            End Try
        End Sub 'DeleteDirectories
