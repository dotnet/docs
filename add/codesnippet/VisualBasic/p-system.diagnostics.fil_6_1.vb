    Private Sub GetFileMajorPart()
        ' Get the file version for the notepad.
        Dim myFileVersionInfo As FileVersionInfo = _
            FileVersionInfo.GetVersionInfo("%systemroot%\Notepad.exe")
        
        ' Print the file major part number.
        textBox1.Text = "File major part number: " & myFileVersionInfo.FileMajorPart
    End Sub 'GetFileMajorPart