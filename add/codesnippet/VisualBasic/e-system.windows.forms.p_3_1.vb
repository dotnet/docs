Private Sub PropertyGrid1_KeyDown(sender as Object, e as KeyEventArgs) _ 
     Handles PropertyGrid1.KeyDown

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Alt", e.Alt)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Control", e.Control)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Handled", e.Handled)
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
    messageBoxVB.AppendFormat("{0} = {1}", "SuppressKeyPress", e.SuppressKeyPress)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"KeyDown Event")

End Sub