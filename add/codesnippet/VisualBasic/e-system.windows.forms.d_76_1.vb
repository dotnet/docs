Private Sub DataGridView1_CellContentDoubleClick(sender as Object, e as DataGridViewCellEventArgs) _ 
     Handles DataGridView1.CellContentDoubleClick

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"CellContentDoubleClick Event")

End Sub