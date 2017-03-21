Private Sub ListView1_ColumnReordered(sender as Object, e as ColumnReorderedEventArgs) _ 
     Handles ListView1.ColumnReordered

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "OldDisplayIndex", e.OldDisplayIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "NewDisplayIndex", e.NewDisplayIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Header", e.Header)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Cancel", e.Cancel)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"ColumnReordered Event")

End Sub