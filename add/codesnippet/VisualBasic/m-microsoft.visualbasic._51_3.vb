        ' Report character position at beginning of each line.
        Dim TextLine As String
        FileOpen(1, "TESTFILE", OpenMode.Input)   ' Open file for reading.
        While Not EOF(1)
            ' Read next line.
            TextLine = LineInput(1)
            ' Position of next line.
            MsgBox(Seek(1))
        End While
        FileClose(1)