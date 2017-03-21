Private Sub PrintCells(ByVal myGrid As DataGrid)
    Dim iRow As Integer
    Dim iCol As Integer
    Dim myTable As DataTable
    ' Assumes the DataGrid is bound to a DataTable.
    myTable = CType(DataGrid1.DataSource, DataTable)
    For iRow = 0 To myTable.Rows.Count - 1
       For iCol = 0 To myTable.Columns.Count - 1
          Console.WriteLine(myGrid(iRow, iCol))
       Next iCol
    Next iRow
 End Sub
    