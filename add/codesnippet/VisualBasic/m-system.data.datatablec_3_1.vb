Private Sub GetIndexes()
    ' Get the DataSet of a DataGrid.
    Dim thisDataSet As DataSet = CType(DataGrid1.DataSource, DataSet)

    ' Get the DataTableCollection through the Tables property.
    Dim tables As DataTableCollection = thisDataSet.Tables
    Dim table As DataTable

    ' Get the index of each table in the collection.
    For Each table In tables
       System.Diagnostics.Debug.WriteLine(tables.IndexOf(table))
    Next
End Sub