Private Sub Form1_InputLanguageChanging(sender as Object, e as InputLanguageChangingEventArgs) _ 
     Handles Form1.InputLanguageChanging

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "InputLanguage", e.InputLanguage)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Culture", e.Culture)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "SysCharSet", e.SysCharSet)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Cancel", e.Cancel)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"InputLanguageChanging Event")

End Sub