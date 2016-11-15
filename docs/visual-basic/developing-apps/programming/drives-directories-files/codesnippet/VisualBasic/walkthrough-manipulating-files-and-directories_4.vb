    Private Function GetTextForOutput(ByVal filePath As String) As String
        ' Verify that the file exists.
        If My.Computer.FileSystem.FileExists(filePath) = False Then
            Throw New Exception("File Not Found: " & filePath)
        End If

        ' Create a new StringBuilder, which is used
        ' to efficiently build strings.
        Dim sb As New System.Text.StringBuilder()

        ' Obtain file information.
        Dim thisFile As System.IO.FileInfo = My.Computer.FileSystem.GetFileInfo(filePath)

        ' Add file attributes.
        sb.Append("File: " & thisFile.FullName)
        sb.Append(vbCrLf)
        sb.Append("Modified: " & thisFile.LastWriteTime.ToString)
        sb.Append(vbCrLf)
        sb.Append("Size: " & thisFile.Length.ToString & " bytes")
        sb.Append(vbCrLf)

        ' Open the text file.
        Dim sr As System.IO.StreamReader =
            My.Computer.FileSystem.OpenTextFileReader(filePath)

        ' Add the first line from the file.
        If sr.Peek() >= 0 Then
            sb.Append("First Line: " & sr.ReadLine())
        End If
        sr.Close()

        Return sb.ToString
    End Function