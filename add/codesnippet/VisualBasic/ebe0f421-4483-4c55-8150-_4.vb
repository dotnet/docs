        FileOpen(1, "TESTFILE", OpenMode.Output, OpenAccess.Default, OpenShare.Shared)
        ' Close before reopening in another mode.
        FileClose(1)