Private Sub DataGridView1_RowErrorTextChanged(sender as Object, e as DataGridViewRowEventArgs) _ 
     Handles DataGridView1.RowErrorTextChanged

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Row", e.Row)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"RowErrorTextChanged Event")

End Sub