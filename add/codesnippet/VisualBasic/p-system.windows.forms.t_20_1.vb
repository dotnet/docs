Private Sub MaskedTextBox1_TypeValidationCompleted(sender as Object, e as TypeValidationEventArgs) _ 
     Handles MaskedTextBox1.TypeValidationCompleted

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Cancel", e.Cancel)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "IsValidInput", e.IsValidInput)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Message", e.Message)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ReturnValue", e.ReturnValue)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ValidatingType", e.ValidatingType)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"TypeValidationCompleted Event")

End Sub