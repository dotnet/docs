Private Sub DataGridView1_AutoSizeColumnsModeChanged(sender as Object, e as DataGridViewAutoSizeColumnsModeEventArgs) _ 
     Handles DataGridView1.AutoSizeColumnsModeChanged

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "PreviousModes", e.PreviousModes)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"AutoSizeColumnsModeChanged Event")

End Sub