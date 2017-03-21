        FileOpen(1, "TESTFILE", OpenMode.Input)
        ' Close before reopening in another mode.
        FileClose(1)