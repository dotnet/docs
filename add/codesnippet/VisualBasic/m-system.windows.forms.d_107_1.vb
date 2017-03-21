Private Sub GetRect()
    Dim rect As Rectangle
    Dim dgc As DataGridCell
    dgc.ColumnNumber = 0
    dgc.RowNumber = 0
    rect = DataGrid1.GetCellBounds(dgc)
    Console.WriteLine(rect.ToString())
 End Sub
 