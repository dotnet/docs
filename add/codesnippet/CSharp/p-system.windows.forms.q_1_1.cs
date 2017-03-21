private void Control1_QueryAccessibilityHelp(Object sender, QueryAccessibilityHelpEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "HelpNamespace", e.HelpNamespace );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "HelpString", e.HelpString );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "HelpKeyword", e.HelpKeyword );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "QueryAccessibilityHelp Event" );
}