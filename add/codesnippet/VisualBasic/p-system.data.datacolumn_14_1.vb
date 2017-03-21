Private Sub PrintDataType(table As DataTable)
     ' Get the DataColumnCollection from a DataTable in a DataSet.
     Dim columns As DataColumnCollection = table.Columns

     ' Print the column's data type.
     Console.WriteLine(columns("id").DataType)
End Sub