Private Sub Control1_ChangeUICues(sender as Object, e as UICuesEventArgs) _ 
     Handles Control1.ChangeUICues

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "ShowFocus", e.ShowFocus)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ShowKeyboard", e.ShowKeyboard)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ChangeFocus", e.ChangeFocus)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ChangeKeyboard", e.ChangeKeyboard)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Changed", e.Changed)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"ChangeUICues Event")

End Sub