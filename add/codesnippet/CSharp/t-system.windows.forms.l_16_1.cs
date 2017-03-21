private void RichTextBox1_LinkClicked(Object sender, LinkClickedEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "LinkText", e.LinkText );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "LinkClicked Event" );
}