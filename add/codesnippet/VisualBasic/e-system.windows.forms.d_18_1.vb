Private Sub DataGridView1_ColumnNameChanged(sender as Object, e as DataGridViewColumnEventArgs) _ 
     Handles DataGridView1.ColumnNameChanged

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Column", e.Column)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"ColumnNameChanged Event")

End Sub