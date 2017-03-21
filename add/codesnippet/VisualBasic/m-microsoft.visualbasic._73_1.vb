        FileOpen(1, "TESTFILE", OpenMode.Output)
        Write(1, "hello")
        Write(1, 14)
        FileClose(1)
        Dim s As String = "teststring"
        Dim i As Integer
        FileOpen(1, "TESTFILE", OpenMode.Input)
        Input(1, s)
        MsgBox(s)
        Input(1, i)
        MsgBox(i)
        FileClose(1)