        Dim oneChar As String
        ' Open file.
        FileOpen(1, "MYFILE.TXT", OpenMode.Input)
        ' Loop until end of file.
        While Not EOF(1)
            ' Get one character.
            oneChar = (InputString(1, 1))
            ' Print to the output window.
            System.Console.Out.WriteLine(oneChar)
        End While
        FileClose(1)