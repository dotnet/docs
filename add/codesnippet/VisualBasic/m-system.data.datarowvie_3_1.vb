Private Sub DeleteRow()
     Dim row As DataRowView
     Dim view As DataView = CType(dataGrid1.DataSource, DataView)
     row = view(dataGrid1.CurrentCell.RowNumber)
     row.Delete()
End Sub