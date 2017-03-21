private void ToolStripItem1_GiveFeedback(Object sender, GiveFeedbackEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Effect", e.Effect );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "UseDefaultCursors", e.UseDefaultCursors );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "GiveFeedback Event" );
}