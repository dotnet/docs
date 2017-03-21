    Private Sub GetFilePrivatePart()
        ' Get the file version for the notepad.
        Dim myFileVersionInfo As FileVersionInfo = _
            FileVersionInfo.GetVersionInfo(Environment.SystemDirectory + "\Notepad.exe")
        
        ' Print the file private part number.
        textBox1.Text = "File private part number: " & myFileVersionInfo.FilePrivatePart
    End Sub 'GetFilePrivatePart