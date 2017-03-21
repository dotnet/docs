private void WebBrowser1_NewWindow(Object sender, CancelEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Cancel", e.Cancel );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "NewWindow Event" );
}