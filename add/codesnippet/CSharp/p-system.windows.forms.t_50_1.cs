private void ToolStripRenderer1_RenderArrow(Object sender, ToolStripArrowRenderEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "ArrowRectangle", e.ArrowRectangle );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ArrowColor", e.ArrowColor );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Direction", e.Direction );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Graphics", e.Graphics );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Item", e.Item );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "RenderArrow Event" );
}