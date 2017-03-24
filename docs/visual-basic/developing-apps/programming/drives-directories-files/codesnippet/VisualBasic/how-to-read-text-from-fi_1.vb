Dim fileReader As System.IO.StreamReader
fileReader =
My.Computer.FileSystem.OpenTextFileReader("C:\\testfile.txt")
Dim stringReader As String
stringReader = fileReader.ReadLine()
MsgBox("The first line of the file is " & stringReader)