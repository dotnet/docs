Private Sub GetTableByName()
    ' Presuming a DataGrid is displaying more than one table, 
    ' get its DataSet.
    Dim thisDataSet As DataSet = CType(DataGrid1.DataSource, DataSet)

    ' Get the DataTableCollection.
    Dim tablesCollection As DataTableCollection = thisDataSet.Tables

    ' Get a specific table by name.
    Dim table As DataTable = tablesCollection("Suppliers")
    Console.WriteLine(table.TableName)
End Sub