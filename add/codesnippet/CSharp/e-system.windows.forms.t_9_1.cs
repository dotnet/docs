private void ToolStripRenderer1_RenderItemText(Object sender, ToolStripItemTextRenderEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Text", e.Text );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "TextColor", e.TextColor );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "TextFont", e.TextFont );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "TextRectangle", e.TextRectangle );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "TextFormat", e.TextFormat );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "TextDirection", e.TextDirection );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Graphics", e.Graphics );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Item", e.Item );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ToolStrip", e.ToolStrip );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "RenderItemText Event" );
}