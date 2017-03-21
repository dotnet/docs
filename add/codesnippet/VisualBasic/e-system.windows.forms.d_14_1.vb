Private Sub DataGridView1_ColumnContextMenuStripChanged(sender as Object, e as DataGridViewColumnEventArgs) _ 
     Handles DataGridView1.ColumnContextMenuStripChanged

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Column", e.Column)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"ColumnContextMenuStripChanged Event")

End Sub