private void Form1_InputLanguageChanging(Object sender, InputLanguageChangingEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "InputLanguage", e.InputLanguage );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Culture", e.Culture );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "SysCharSet", e.SysCharSet );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Cancel", e.Cancel );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "InputLanguageChanging Event" );
}