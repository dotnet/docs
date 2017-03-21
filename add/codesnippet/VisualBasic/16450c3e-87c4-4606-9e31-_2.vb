        Dim c As Object = "test"
        FileSystem.FileOpen(1, "test.dat", OpenMode.Binary)
        FileSystem.FilePutObject(1, "ABCDEF")
        FileSystem.Seek(1, 1)
        FileSystem.FileGetObject(1, c)
        MsgBox(c)
        FileSystem.FileClose(1)