Private Function GetDataSetFromTable() As DataSet
    Dim table As DataTable

    ' Check to see if the DataGrid's DataSource property
    ' is a DataTable.
    If TypeOf dataGrid1.DataSource Is DataTable Then
        table = CType(DataGrid1.DataSource, DataTable)
        GetDataSetFromTable = table.DataSet
    Else
        return Nothing
    End If
End Function