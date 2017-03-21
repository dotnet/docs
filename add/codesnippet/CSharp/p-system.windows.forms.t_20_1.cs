private void MaskedTextBox1_TypeValidationCompleted(Object sender, TypeValidationEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Cancel", e.Cancel );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "IsValidInput", e.IsValidInput );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Message", e.Message );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ReturnValue", e.ReturnValue );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ValidatingType", e.ValidatingType );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "TypeValidationCompleted Event" );
}