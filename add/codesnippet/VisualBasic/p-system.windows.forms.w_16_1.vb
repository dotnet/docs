Private Sub WebBrowser1_Navigating(sender as Object, e as WebBrowserNavigatingEventArgs) _ 
     Handles WebBrowser1.Navigating

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Url", e.Url)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "TargetFrameName", e.TargetFrameName)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Cancel", e.Cancel)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"Navigating Event")

End Sub