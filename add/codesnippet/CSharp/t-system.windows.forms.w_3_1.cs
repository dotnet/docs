private void WebBrowser1_DocumentCompleted(Object sender, WebBrowserDocumentCompletedEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Url", e.Url );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "DocumentCompleted Event" );
}