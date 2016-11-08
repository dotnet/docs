Dim fileReader As String
fileReader = My.Computer.FileSystem.ReadAllText("C:\test.txt",
   System.Text.Encoding.UTF32)
MsgBox(fileReader)