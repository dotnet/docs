        Dim TextLine As String
        FileOpen(1, "TESTFILE", OpenMode.Input)   ' Open file.
        Do While Not EOF(1)   ' Loop until end of file.
            TextLine = LineInput(1)   ' Read line into variable.
            MsgBox(TextLine)   ' Display the line
        Loop
        FileClose(1)   ' Close file.