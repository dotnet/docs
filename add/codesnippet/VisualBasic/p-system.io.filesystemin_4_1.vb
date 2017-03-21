    Sub DisplayFileSystemInfoAttributes(ByVal fsi As IO.FileSystemInfo)
        ' Assume that this entry is a file.
        Dim entryType As String = "File"

        ' Determine if this entry is really a directory.
        If (fsi.Attributes And FileAttributes.Directory) = FileAttributes.Directory Then
            entryType = "Directory"
        End If

        ' Show this entry's type, name, and creation date.
        Console.WriteLine("{0} entry {1} was created on {2:D}", _
            entryType, fsi.FullName, fsi.CreationTime)
    End Sub