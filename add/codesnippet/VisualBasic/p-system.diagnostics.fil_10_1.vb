    Private Sub GetProductBuildPart()
        ' Get the file version for the notepad.
        Dim myFileVersionInfo As FileVersionInfo = _
            FileVersionInfo.GetVersionInfo(Environment.SystemDirectory + "\Notepad.exe")
        
        ' Print the product build part number.
        textBox1.Text = "Product build part number: " & myFileVersionInfo.ProductBuildPart
    End Sub 'GetProductBuildPart