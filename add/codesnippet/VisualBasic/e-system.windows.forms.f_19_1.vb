Private Sub Form1_HelpButtonClicked(sender as Object, e as CancelEventArgs) _ 
     Handles Form1.HelpButtonClicked

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Cancel", e.Cancel)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"HelpButtonClicked Event")

End Sub