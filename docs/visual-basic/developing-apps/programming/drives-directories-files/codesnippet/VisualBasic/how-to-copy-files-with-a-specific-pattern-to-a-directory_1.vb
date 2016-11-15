        For Each foundFile As String In My.Computer.FileSystem.GetFiles(
            My.Computer.FileSystem.SpecialDirectories.MyDocuments,
            Microsoft.VisualBasic.FileIO.SearchOption.SearchTopLevelOnly, "*.rtf")