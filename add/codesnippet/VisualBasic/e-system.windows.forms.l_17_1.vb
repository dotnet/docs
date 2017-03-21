Private Sub ListView1_ColumnWidthChanged(sender as Object, e as ColumnWidthChangedEventArgs) _ 
     Handles ListView1.ColumnWidthChanged

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"ColumnWidthChanged Event")

End Sub