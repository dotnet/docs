private void Binding1_BindingComplete(Object sender, BindingCompleteEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Binding", e.Binding );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "BindingCompleteState", e.BindingCompleteState );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "BindingCompleteContext", e.BindingCompleteContext );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ErrorText", e.ErrorText );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Exception", e.Exception );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Cancel", e.Cancel );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "BindingComplete Event" );
}