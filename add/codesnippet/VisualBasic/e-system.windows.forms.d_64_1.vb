Private Sub DataGridView1_RowUnshared(sender as Object, e as DataGridViewRowEventArgs) _ 
     Handles DataGridView1.RowUnshared

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Row", e.Row)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"RowUnshared Event")

End Sub