Private Sub DataGridView1_RowHeadersWidthSizeModeChanged(sender as Object, e as DataGridViewAutoSizeModeEventArgs) _ 
     Handles DataGridView1.RowHeadersWidthSizeModeChanged

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "PreviousModeAutoSized", e.PreviousModeAutoSized)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"RowHeadersWidthSizeModeChanged Event")

End Sub