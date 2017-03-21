Private Sub ListView1_ColumnWidthChanging(sender as Object, e as ColumnWidthChangingEventArgs) _ 
     Handles ListView1.ColumnWidthChanging

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "NewWidth", e.NewWidth)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Cancel", e.Cancel)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"ColumnWidthChanging Event")

End Sub