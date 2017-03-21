private void ToolStripItem1_QueryContinueDrag(Object sender, QueryContinueDragEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "KeyState", e.KeyState );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "EscapePressed", e.EscapePressed );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Action", e.Action );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "QueryContinueDrag Event" );
}