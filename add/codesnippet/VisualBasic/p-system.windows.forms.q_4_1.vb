Private Sub Control1_QueryAccessibilityHelp(sender as Object, e as QueryAccessibilityHelpEventArgs) _ 
     Handles Control1.QueryAccessibilityHelp

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "HelpNamespace", e.HelpNamespace)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "HelpString", e.HelpString)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "HelpKeyword", e.HelpKeyword)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"QueryAccessibilityHelp Event")

End Sub