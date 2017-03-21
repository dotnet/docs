private void LinkLabel1_LinkClicked(Object sender, LinkLabelLinkClickedEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Button", e.Button );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Link", e.Link );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "LinkClicked Event" );
}