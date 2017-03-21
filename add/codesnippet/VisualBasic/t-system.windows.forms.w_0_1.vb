Private Sub WebBrowser1_ProgressChanged(sender as Object, e as WebBrowserProgressChangedEventArgs) _ 
     Handles WebBrowser1.ProgressChanged

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "CurrentProgress", e.CurrentProgress)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "MaximumProgress", e.MaximumProgress)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"ProgressChanged Event")

End Sub