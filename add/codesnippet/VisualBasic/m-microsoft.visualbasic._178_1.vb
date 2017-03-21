        Dim location As Long
        Dim oneChar As Char
        FileOpen(1, "C:\TESTFILE.TXT", OpenMode.Binary)
        While location < LOF(1)
            Input(1, oneChar)
            location = Loc(1)
            WriteLine(1, location & ControlChars.CrLf)
        End While
        FileClose(1)