    Private Sub GetTrademarks()
        ' Get the file version for the notepad.
        Dim myFileVersionInfo As FileVersionInfo = _
            FileVersionInfo.GetVersionInfo(Environment.SystemDirectory + "\Notepad.exe")
        
        ' Print the trademarks.
        textBox1.Text = "Trademarks: " & myFileVersionInfo.LegalTrademarks
    End Sub 'GetTrademarks