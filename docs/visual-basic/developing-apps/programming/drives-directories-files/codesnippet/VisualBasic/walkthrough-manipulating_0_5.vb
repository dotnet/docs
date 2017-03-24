        If saveCheckBox.Checked = True Then
            ' Place the log file in the same folder as the examined file.
            Dim logFolder As String = My.Computer.FileSystem.GetFileInfo(filePath).DirectoryName
            Dim logFilePath = My.Computer.FileSystem.CombinePath(logFolder, "log.txt")

            Dim logText As String = "Logged: " & Date.Now.ToString &
                vbCrLf & fileInfoText & vbCrLf & vbCrLf

            ' Append text to the log file.
            My.Computer.FileSystem.WriteAllText(logFilePath, logText, append:=True)
        End If