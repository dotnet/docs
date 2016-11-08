Dim file As System.IO.StreamWriter
file = My.Computer.FileSystem.OpenTextFileWriter("c:\test.txt", True)
file.WriteLine("Here is the first string.")
file.Close()