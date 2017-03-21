 Private Sub ContainsArray()
    ' This example assumes that the DataTable object contains two
    ' DataColumn objects designated as primary keys.
    ' The table has two primary key columns.
    Dim arrKeyVals(1) As Object
    Dim table As DataTable = CType(DataGrid1.DataSource, DataTable)
    Dim rowCollection As DataRowCollection = table.Rows
    arrKeyVals(0) = "Hello"
    arrKeyVals(1) = "World"
    label1.Text = rowCollection.Contains(arrKeyVals).ToString()
 End Sub