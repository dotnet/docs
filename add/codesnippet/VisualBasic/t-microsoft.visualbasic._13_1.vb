        Dim logInfo As System.IO.DirectoryInfo
        If My.Computer.FileSystem.DirectoryExists("C:\backup\logs") Then
            logInfo = My.Computer.FileSystem.GetDirectoryInfo(
              "C:\backup\logs")
        End If