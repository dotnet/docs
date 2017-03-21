private void ToolStripRenderer1_RenderToolStripPanelBackground(Object sender, ToolStripPanelRenderEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Graphics", e.Graphics );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ToolStripPanel", e.ToolStripPanel );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Handled", e.Handled );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "RenderToolStripPanelBackground Event" );
}