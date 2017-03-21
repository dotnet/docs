Private Sub GetDefaultDataViewManager()
    ' Get a DataSet object's DefaultViewManager.
     Dim view As DataViewManager = DataSet1.DefaultViewManager

    ' Add a DataTable to the DataTableCollection.
    Dim table As DataTable
    table = New DataTable("TableName")
    view.DataSet.Tables.Add(table)
End Sub