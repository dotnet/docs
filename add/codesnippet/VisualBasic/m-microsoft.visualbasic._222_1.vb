        ' The SPC function can be used with the Print function.
        FileOpen(1, "TESTFILE", OpenMode.Output)   ' Open file for output.
        Print(1, "10 spaces between here", SPC(10), "and here.")
        FileClose(1)   ' Close file.