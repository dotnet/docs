Private Sub DataGridView1_ColumnHeadersHeightSizeModeChanged(sender as Object, e as DataGridViewAutoSizeModeEventArgs) _ 
     Handles DataGridView1.ColumnHeadersHeightSizeModeChanged

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "PreviousModeAutoSized", e.PreviousModeAutoSized)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"ColumnHeadersHeightSizeModeChanged Event")

End Sub