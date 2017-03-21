    Private Sub GetCompanyName()
        ' Get the file version for the notepad.
        Dim myFileVersionInfo As FileVersionInfo = _
            FileVersionInfo.GetVersionInfo(Environment.SystemDirectory + "\Notepad.exe")

        ' Print the company name.
        textBox1.Text = "The company name: " & myFileVersionInfo.CompanyName
    End Sub 'GetCompanyName