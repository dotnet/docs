Private Sub AddTable()
    ' Presuming a DataGrid is displaying more than one table, 
    ' get its DataSet.
    Dim thisDataSet As DataSet = _
        CType(DataGrid1.DataSource, DataSet)

    ' Use the Add method to add a new table with a given name.
    Dim table As DataTable = thisDataSet.Tables.Add("NewTable")

    ' Code to add columns and rows not shown here.

    Console.WriteLine(table.TableName)
    Console.WriteLine(thisDataSet.Tables.Count.ToString())
End Sub