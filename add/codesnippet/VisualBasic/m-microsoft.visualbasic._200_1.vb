        Using FileReader As New Microsoft.VisualBasic.FileIO.
            TextFieldParser("C:\ParserText.txt")

            Dim allText As String = FileReader.ReadToEnd
            My.Computer.FileSystem.WriteAllText("C://testfile.txt", allText, True)
        End Using