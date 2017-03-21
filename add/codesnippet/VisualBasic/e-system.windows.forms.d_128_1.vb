Private Sub DataGridView1_ColumnRemoved(sender as Object, e as DataGridViewColumnEventArgs) _ 
     Handles DataGridView1.ColumnRemoved

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Column", e.Column)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"ColumnRemoved Event")

End Sub