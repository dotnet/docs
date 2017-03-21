Private Sub GetDataTableByIndex()
    ' Presuming a DataGrid is displaying more than one table, get its DataSet.
    Dim thisDataSet As DataSet = CType(DataGrid1.DataSource, DataSet)

    ' Get the DataTableCollection.
    Dim tablesCollection As DataTableCollection = thisDataSet.Tables

    ' Iterate through the collection to get each table name.
    Dim i As Integer
    For i = 0 To tablesCollection.Count - 1
       Console.WriteLine(tablesCollection(i).TableName)
    Next
End Sub