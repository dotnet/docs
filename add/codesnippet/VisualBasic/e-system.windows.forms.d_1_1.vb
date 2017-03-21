Private Sub DataGridView1_RowHeaderCellChanged(sender as Object, e as DataGridViewRowEventArgs) _ 
     Handles DataGridView1.RowHeaderCellChanged

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Row", e.Row)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"RowHeaderCellChanged Event")

End Sub