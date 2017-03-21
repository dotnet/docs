Private Sub DataGridView1_RowContextMenuStripChanged(sender as Object, e as DataGridViewRowEventArgs) _ 
     Handles DataGridView1.RowContextMenuStripChanged

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Row", e.Row)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"RowContextMenuStripChanged Event")

End Sub