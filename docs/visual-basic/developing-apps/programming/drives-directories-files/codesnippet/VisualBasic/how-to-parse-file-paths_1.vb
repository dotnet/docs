        Dim testFile As System.IO.FileInfo
        testFile = My.Computer.FileSystem.GetFileInfo("C:\TestFolder1\test1.txt")
        Dim folderPath As String = testFile.DirectoryName
        MsgBox(folderPath)
        Dim fileName As String = testFile.Name
        MsgBox(fileName)