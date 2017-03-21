Private Sub DataGridView1_RowsAdded(sender as Object, e as DataGridViewRowsAddedEventArgs) _ 
     Handles DataGridView1.RowsAdded

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "RowCount", e.RowCount)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"RowsAdded Event")

End Sub