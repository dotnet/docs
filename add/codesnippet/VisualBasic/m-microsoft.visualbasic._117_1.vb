        ' Open 5 files named TEST1, TEST2, etc.
        Dim fileNumber As Integer
        ' Open 5 files.
        For fileNumber = 1 To 5
            FileOpen(fileNumber, "TEST" & fileNumber, OpenMode.Output)
            PrintLine(fileNumber, "Hello World")
        Next fileNumber
        ' Close files and write contents to disk.
        Reset()