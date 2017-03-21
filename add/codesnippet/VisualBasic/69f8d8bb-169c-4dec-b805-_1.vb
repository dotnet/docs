    Sub WriteData()
        Dim text As String = "test"
        FileOpen(1, "test.bin", OpenMode.Binary)
        FilePutObject(1, text)
        FileClose(1)
    End Sub