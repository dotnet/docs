        FileOpen(1, "TESTFILE", OpenMode.Output) ' Open file for output.
        ' The second word prints at column 20.
        Print(1, "Hello", TAB(20), "World.")
        ' If the argument is omitted, cursor is moved to the next print zone.
        Print(1, "Hello", TAB(), "World")
        FileClose(1)