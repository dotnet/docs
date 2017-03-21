        Dim i As Integer
        FileOpen(1, "TESTFILE", OpenMode.Output) ' Open file for output.
        FileWidth(1, 5)   ' Set output line width to 5.
        For i = 0 To 9   ' Loop 10 times.
            Print(1, Chr(48 + I))   ' Prints five characters per line.
        Next
        FileClose(1)   ' Close file.