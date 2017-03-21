Private Sub DataGridView1_ColumnDividerDoubleClick(sender as Object, e as DataGridViewColumnDividerDoubleClickEventArgs) _ 
     Handles DataGridView1.ColumnDividerDoubleClick

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Handled", e.Handled)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Button", e.Button)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Clicks", e.Clicks)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "X", e.X)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Y", e.Y)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Delta", e.Delta)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Location", e.Location)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"ColumnDividerDoubleClick Event")

End Sub