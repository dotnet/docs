Private Sub Control1_PreviewKeyDown(sender as Object, e as PreviewKeyDownEventArgs) _ 
     Handles Control1.PreviewKeyDown

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Alt", e.Alt)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Control", e.Control)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "KeyCode", e.KeyCode)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "KeyValue", e.KeyValue)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "KeyData", e.KeyData)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Modifiers", e.Modifiers)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Shift", e.Shift)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "IsInputKey", e.IsInputKey)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"PreviewKeyDown Event")

End Sub