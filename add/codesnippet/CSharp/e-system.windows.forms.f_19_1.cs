private void Form1_HelpButtonClicked(Object sender, CancelEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Cancel", e.Cancel );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "HelpButtonClicked Event" );
}