Try
    Dim filePath As String
    filePath = System.IO.Path.Combine(
               My.Computer.FileSystem.SpecialDirectories.MyDocuments, "test.txt")
            My.Computer.FileSystem.WriteAllText(filePath, "some text", False)
Catch fileException As Exception
    Throw fileException
End Try