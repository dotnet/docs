private void Control1_ChangeUICues(Object sender, UICuesEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "ShowFocus", e.ShowFocus );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ShowKeyboard", e.ShowKeyboard );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ChangeFocus", e.ChangeFocus );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ChangeKeyboard", e.ChangeKeyboard );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Changed", e.Changed );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "ChangeUICues Event" );
}