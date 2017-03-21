Private Sub WebBrowser1_DocumentCompleted(sender as Object, e as WebBrowserDocumentCompletedEventArgs) _ 
     Handles WebBrowser1.DocumentCompleted

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Url", e.Url)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"DocumentCompleted Event")

End Sub