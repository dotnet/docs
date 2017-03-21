private void ToolStripRenderer1_RenderItemImage(Object sender, ToolStripItemImageRenderEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Image", e.Image );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ImageRectangle", e.ImageRectangle );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Graphics", e.Graphics );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Item", e.Item );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ToolStrip", e.ToolStrip );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "RenderItemImage Event" );
}