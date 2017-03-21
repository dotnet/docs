Private Sub DataGridView1_RowDefaultCellStyleChanged(sender as Object, e as DataGridViewRowEventArgs) _ 
     Handles DataGridView1.RowDefaultCellStyleChanged

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Row", e.Row)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"RowDefaultCellStyleChanged Event")

End Sub