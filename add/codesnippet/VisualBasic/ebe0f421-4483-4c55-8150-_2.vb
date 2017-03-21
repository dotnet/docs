        FileOpen(1, "TESTFILE", OpenMode.Binary, OpenAccess.Write)
        ' Close before reopening in another mode.
        FileClose(1)