private void WebBrowser1_Navigating(Object sender, WebBrowserNavigatingEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Url", e.Url );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "TargetFrameName", e.TargetFrameName );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Cancel", e.Cancel );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "Navigating Event" );
}