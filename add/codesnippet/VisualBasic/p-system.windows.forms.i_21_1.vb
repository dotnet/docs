Private Sub Form1_InputLanguageChanged(sender as Object, e as InputLanguageChangedEventArgs) _ 
     Handles Form1.InputLanguageChanged

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "InputLanguage", e.InputLanguage)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Culture", e.Culture)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "CharSet", e.CharSet)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"InputLanguageChanged Event")

End Sub