private void ToolStripRenderer1_RenderToolStripContentPanelBackground(Object sender, ToolStripContentPanelRenderEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Graphics", e.Graphics );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Handled", e.Handled );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ToolStripContentPanel", e.ToolStripContentPanel );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "RenderToolStripContentPanelBackground Event" );
}