Private Sub DataGridView1_CellStyleChanged(sender as Object, e as DataGridViewCellEventArgs) _ 
     Handles DataGridView1.CellStyleChanged

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"CellStyleChanged Event")

End Sub