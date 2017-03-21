Private Sub DataGridView1_ColumnStateChanged(sender as Object, e as DataGridViewColumnStateChangedEventArgs) _ 
     Handles DataGridView1.ColumnStateChanged

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Column", e.Column)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "StateChanged", e.StateChanged)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"ColumnStateChanged Event")

End Sub