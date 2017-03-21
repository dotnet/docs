private void Form1_InputLanguageChanged(Object sender, InputLanguageChangedEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "InputLanguage", e.InputLanguage );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Culture", e.Culture );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "CharSet", e.CharSet );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "InputLanguageChanged Event" );
}