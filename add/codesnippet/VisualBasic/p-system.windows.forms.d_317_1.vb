Private Sub DataGridView1_AutoSizeColumnModeChanged(sender as Object, e as DataGridViewAutoSizeColumnModeEventArgs) _ 
     Handles DataGridView1.AutoSizeColumnModeChanged

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Column", e.Column)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "PreviousMode", e.PreviousMode)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"AutoSizeColumnModeChanged Event")

End Sub