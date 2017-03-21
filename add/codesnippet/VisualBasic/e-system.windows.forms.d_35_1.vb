Private Sub DataGridView1_ColumnMinimumWidthChanged(sender as Object, e as DataGridViewColumnEventArgs) _ 
     Handles DataGridView1.ColumnMinimumWidthChanged

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Column", e.Column)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"ColumnMinimumWidthChanged Event")

End Sub