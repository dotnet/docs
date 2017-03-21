Private Sub DataGridView1_RowStateChanged(sender as Object, e as DataGridViewRowStateChangedEventArgs) _ 
     Handles DataGridView1.RowStateChanged

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Row", e.Row)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "StateChanged", e.StateChanged)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"RowStateChanged Event")

End Sub