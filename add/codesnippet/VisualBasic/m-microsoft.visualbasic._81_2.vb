        FileOpen(1, "TESTFILE", OpenMode.Random)
        Do While Not EOF(1)
            WriteLine(1, Seek(1))   ' Write record number.
            FileGet(1, MyRecord, -1)   ' Read next record.
        Loop
        FileClose(1)