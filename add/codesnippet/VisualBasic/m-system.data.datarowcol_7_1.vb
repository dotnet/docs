 Private Sub ColContains()
    Dim table As DataTable = CType(DataGrid1.DataSource, DataTable)
    Dim rowCollection As DataRowCollection = table.Rows
    If rowCollection.Contains(Edit1.Text) Then
       Label1.Text = "At least one row contains " & Edit1.Text 
    Else
       Label1.Text = "No row contains the value in its primary key field"
    End If
End Sub