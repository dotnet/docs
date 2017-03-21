Private Sub DataGridView1_ColumnAdded(sender as Object, e as DataGridViewColumnEventArgs) _ 
     Handles DataGridView1.ColumnAdded

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Column", e.Column)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"ColumnAdded Event")

End Sub