private void Control1_HelpRequested(Object sender, HelpEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "MousePos", e.MousePos );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Handled", e.Handled );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "HelpRequested Event" );
}