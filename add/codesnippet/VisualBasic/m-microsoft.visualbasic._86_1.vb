        Dim fileReader =
          My.Computer.FileSystem.OpenTextFileReader("C:\testfile.txt")
        Dim stringReader = fileReader.ReadLine()
        MsgBox("The first line of the file is " & stringReader)