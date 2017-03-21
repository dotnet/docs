        If My.Computer.FileSystem.DirectoryExists("C:\backup\logs") Then
            Dim logInfo = My.Computer.FileSystem.GetDirectoryInfo(
                "C:\backup\logs")
        End If