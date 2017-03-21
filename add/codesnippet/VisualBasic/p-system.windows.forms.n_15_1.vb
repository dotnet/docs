Private Sub DataGrid1_Navigate(sender as Object, e as NavigateEventArgs) _ 
     Handles DataGrid1.Navigate

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Forward", e.Forward)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"Navigate Event")

End Sub