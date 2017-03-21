        Dim getInfo = My.Computer.FileSystem.GetDirectoryInfo(
            My.Computer.FileSystem.SpecialDirectories.MyDocuments)
        MsgBox("The directory was created at " & getInfo.CreationTime)
        MsgBox("The directory was last accessed at " & getInfo.LastAccessTime)
        MsgBox("The directory was last written to at " & getInfo.LastWriteTime)