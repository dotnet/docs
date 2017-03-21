Private Sub DataGridView1_ColumnDividerWidthChanged(sender as Object, e as DataGridViewColumnEventArgs) _ 
     Handles DataGridView1.ColumnDividerWidthChanged

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Column", e.Column)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"ColumnDividerWidthChanged Event")

End Sub