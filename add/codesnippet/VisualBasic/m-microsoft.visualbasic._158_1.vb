        Dim TextLine As String
        ' Open file.
        FileOpen(1, "TESTFILE", OpenMode.Input)
        ' Loop until end of file.
        While Not EOF(1)
            ' Read line into variable.
            TextLine = LineInput(1)
            ' Print to the console.
            Console.WriteLine("1", TextLine)
        End While
        FileClose(1)