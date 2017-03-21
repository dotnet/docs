        Dim mode As OpenMode
        FileOpen(1, "c:\TESTFILE.TXT", OpenMode.Input)
        mode = FileAttr(1)
        MsgBox("The file mode is " & mode.ToString())
        FileClose(1)