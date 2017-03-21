    Private Sub getExcel()
        Dim fileName As String = "c:\vb\test.xls"

        If Not My.Computer.FileSystem.FileExists(fileName) Then
            MsgBox(fileName & " does not exist")
            Exit Sub
        End If

        ' Set the object variable to refer to the file you want to use.
        Dim excelObj As Object = GetObject(fileName)
        ' Show Excel through its Application property. 
        excelObj.Application.Visible = True
        ' Show the window containing the file.
        Dim winCount As Integer = excelObj.Parent.Windows.Count()
        excelObj.Parent.Windows(winCount).Visible = True

        ' Insert additional code to manipulate the test.xls file here.
        ' ...

        excelObj = Nothing
    End Sub