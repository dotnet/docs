Private Sub WebBrowser1_NewWindow(sender as Object, e as CancelEventArgs) _ 
     Handles WebBrowser1.NewWindow

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Cancel", e.Cancel)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"NewWindow Event")

End Sub