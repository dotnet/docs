Private Sub SetCell()
   ' Set the focus to the cell specified by the DataGridCell.
   Dim dc As DataGridCell
   dc.RowNumber = 1
   dc.ColumnNumber = 1
   DataGrid1.CurrentCell = dc
End Sub
