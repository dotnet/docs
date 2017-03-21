private void HtmlWindow1_Error(Object sender, HtmlElementErrorEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Description", e.Description );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Handled", e.Handled );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "LineNumber", e.LineNumber );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Url", e.Url );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "Error Event" );
}