        Dim reader = My.Computer.FileSystem.ReadAllText("C:\test.txt",
           System.Text.Encoding.ASCII)
        MsgBox(reader)