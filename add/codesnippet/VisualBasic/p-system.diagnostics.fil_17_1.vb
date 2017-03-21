    Private Sub GetProductName()
        ' Get the file version for the notepad.
        Dim myFileVersionInfo As FileVersionInfo = _
            FileVersionInfo.GetVersionInfo(Environment.SystemDirectory + "\Notepad.exe")
        
        ' Print the product name.
        textBox1.Text = "Product name: " & myFileVersionInfo.ProductName
    End Sub 'GetProductName