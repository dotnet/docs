Private Sub DataGridView1_RowErrorTextNeeded(sender as Object, e as DataGridViewRowErrorTextNeededEventArgs) _ 
     Handles DataGridView1.RowErrorTextNeeded

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "ErrorText", e.ErrorText)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"RowErrorTextNeeded Event")

End Sub