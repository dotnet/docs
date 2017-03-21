private void ToolStripRenderer1_RenderToolStripBackground(Object sender, ToolStripRenderEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "AffectedBounds", e.AffectedBounds );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "BackColor", e.BackColor );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Graphics", e.Graphics );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ToolStrip", e.ToolStrip );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ConnectedArea", e.ConnectedArea );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "RenderToolStripBackground Event" );
}