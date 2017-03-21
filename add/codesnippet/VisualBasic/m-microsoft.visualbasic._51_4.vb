        Dim someText As String = "This is a test string."
        ' Open file for output.
        FileOpen(1, "TESTFILE", OpenMode.Input)
        ' Move to the third character.
        Seek(1, 3)
        Input(1, someText)
        Console.WriteLine(someText)
        FileClose(1)