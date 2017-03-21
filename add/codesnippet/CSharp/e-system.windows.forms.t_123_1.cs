private void ToolStripItem1_DragOver(Object sender, DragEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Data", e.Data );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "KeyState", e.KeyState );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "X", e.X );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Y", e.Y );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "AllowedEffect", e.AllowedEffect );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Effect", e.Effect );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "DragOver Event" );
}