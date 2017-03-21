private void ToolTip1_Draw(Object sender, DrawToolTipEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Graphics", e.Graphics );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "AssociatedWindow", e.AssociatedWindow );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "AssociatedControl", e.AssociatedControl );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Bounds", e.Bounds );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ToolTipText", e.ToolTipText );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Font", e.Font );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "Draw Event" );
}