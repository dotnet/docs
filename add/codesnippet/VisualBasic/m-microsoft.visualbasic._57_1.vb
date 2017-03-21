        Dim information = My.Computer.FileSystem.GetFileInfo("C:\MyLogFile.log")
        MsgBox("The file's full name is " & information.FullName & ".")
        MsgBox("Last access time is " & information.LastAccessTime & ".")
        MsgBox("The length is " & information.Length & ".")