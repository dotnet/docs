private void ToolTip1_Popup(Object sender, PopupEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "AssociatedWindow", e.AssociatedWindow );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "AssociatedControl", e.AssociatedControl );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "IsBalloon", e.IsBalloon );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ToolTipSize", e.ToolTipSize );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Cancel", e.Cancel );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "Popup Event" );
}