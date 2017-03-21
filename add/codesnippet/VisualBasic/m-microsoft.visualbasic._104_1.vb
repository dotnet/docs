        Dim count As Integer
        Dim fileNumber As Integer
        For count = 1 To 5
            fileNumber = FreeFile()
            FileOpen(fileNumber, "TEST" & count & ".TXT", OpenMode.Output)
            PrintLine(fileNumber, "This is a sample.")
            FileClose(fileNumber)
        Next