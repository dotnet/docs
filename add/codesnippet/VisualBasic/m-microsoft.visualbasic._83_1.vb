        Dim length As Long
        FileOpen(1, "C:\TESTFILE.TXT", OpenMode.Input) ' Open file.
        length = LOF(1)   ' Get length of file.
        MsgBox(length)
        FileClose(1)   ' Close file.