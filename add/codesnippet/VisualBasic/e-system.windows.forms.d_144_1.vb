Private Sub DataGridView1_RowMinimumHeightChanged(sender as Object, e as DataGridViewRowEventArgs) _ 
     Handles DataGridView1.RowMinimumHeightChanged

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Row", e.Row)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"RowMinimumHeightChanged Event")

End Sub