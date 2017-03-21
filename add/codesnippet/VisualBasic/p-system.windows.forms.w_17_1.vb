Private Sub WebBrowser1_Navigated(sender as Object, e as WebBrowserNavigatedEventArgs) _ 
     Handles WebBrowser1.Navigated

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Url", e.Url)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"Navigated Event")

End Sub