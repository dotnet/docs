 Private Sub ClearColumnsCollection(table As DataTable)
     Dim columns As DataColumnCollection
     ' Get the DataColumnCollection from a 
     ' DataTable in a DataSet.
     columns = table.Columns
     columns.Clear()
End Sub