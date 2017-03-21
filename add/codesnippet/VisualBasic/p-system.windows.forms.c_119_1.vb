Private Sub ListView1_ColumnClick(sender as Object, e as ColumnClickEventArgs) _ 
     Handles ListView1.ColumnClick

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Column", e.Column)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"ColumnClick Event")

End Sub