Private Sub GetTable(ByVal column As DataColumn)
    ' Get the Table of the column.
    Dim table As DataTable = column.Table
    Console.WriteLine("columns", table.Columns.Count)
    Console.WriteLine("rows", table.Rows.Count)
End Sub