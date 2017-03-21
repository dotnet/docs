Private Sub ClearTables()
   ' Get the DataSet of a DataGrid control.
   Dim dataSet As DataSet = CType(DataGrid1.DataSource, DataSet)
   Dim tables As DataTableCollection = dataSet.Tables

   ' Clear the collection.
   tables.Clear
End Sub