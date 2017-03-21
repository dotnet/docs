Private Sub DataGridView1_RowHeightInfoNeeded(sender as Object, e as DataGridViewRowHeightInfoNeededEventArgs) _ 
     Handles DataGridView1.RowHeightInfoNeeded

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Height", e.Height)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "MinimumHeight", e.MinimumHeight)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"RowHeightInfoNeeded Event")

End Sub