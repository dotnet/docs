 Private Sub GetTable(ByVal row As DataRow)
    ' Get the DataTable of a DataRow
    Dim table As DataTable = row.Table

    ' Print the DataType of each column in the table.
    Dim column As DataColumn
    For Each column in table.Columns
       Console.WriteLine(column.DataType)
    Next
 End Sub