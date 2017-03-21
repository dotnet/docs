 Private Sub RemoveRowByIndex()
    Dim table As DataTable = CType(DataGrid1.DataSource, DataTable)
    Dim rowCollection As DataRowCollection = table.Rows
    If rowCollection.Count = 0 Then 
        Exit Sub
    End If
    rowCollection.RemoveAt(rowCollection.Count - 1)
End Sub