Private Sub Binding1_BindingComplete(sender as Object, e as BindingCompleteEventArgs) _ 
     Handles Binding1.BindingComplete

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Binding", e.Binding)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "BindingCompleteState", e.BindingCompleteState)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "BindingCompleteContext", e.BindingCompleteContext)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ErrorText", e.ErrorText)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Exception", e.Exception)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Cancel", e.Cancel)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"BindingComplete Event")

End Sub