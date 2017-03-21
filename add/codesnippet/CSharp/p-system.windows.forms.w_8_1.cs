private void WebBrowser1_ProgressChanged(Object sender, WebBrowserProgressChangedEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "CurrentProgress", e.CurrentProgress );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "MaximumProgress", e.MaximumProgress );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "ProgressChanged Event" );
}