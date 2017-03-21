Private Sub DataGridView1_RowHeightInfoPushed(sender as Object, e as DataGridViewRowHeightInfoPushedEventArgs) _ 
     Handles DataGridView1.RowHeightInfoPushed

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Height", e.Height)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "MinimumHeight", e.MinimumHeight)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Handled", e.Handled)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"RowHeightInfoPushed Event")

End Sub