Private Sub PrintColumns(table As DataTable)
    ' Print the default string of each column in a collection.
    Dim column As DataColumn
    For Each column In table.Columns
       Console.WriteLine(column.ToString())
    Next
End Sub