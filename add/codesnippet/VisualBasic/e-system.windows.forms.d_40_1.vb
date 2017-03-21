Private Sub DataGridView1_CellContextMenuStripChanged(sender as Object, e as DataGridViewCellEventArgs) _ 
     Handles DataGridView1.CellContextMenuStripChanged

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"CellContextMenuStripChanged Event")

End Sub