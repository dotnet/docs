Private Sub DataGridView1_RowsRemoved(sender as Object, e as DataGridViewRowsRemovedEventArgs) _ 
     Handles DataGridView1.RowsRemoved

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "RowCount", e.RowCount)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"RowsRemoved Event")

End Sub