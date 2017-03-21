Private Sub HtmlWindow1_Error(sender as Object, e as HtmlElementErrorEventArgs) _ 
     Handles HtmlWindow1.Error

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Description", e.Description)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Handled", e.Handled)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "LineNumber", e.LineNumber)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Url", e.Url)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"Error Event")

End Sub