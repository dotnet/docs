        Dim TextLine As String
        ' Open file.
        FileOpen(1, "TESTFILE", OpenMode.Input)
        ' Loop until end of file.
        Do Until EOF(1)
            ' Read the line into a variable.
            TextLine = LineInput(1)
            ' Display the line in a message box.
            MsgBox(TextLine)
        Loop
        FileClose(1)