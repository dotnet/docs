Private Sub ToolStripRenderer1_RenderSeparator(sender as Object, e as ToolStripSeparatorRenderEventArgs) _ 
     Handles ToolStripRenderer1.RenderSeparator

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Vertical", e.Vertical)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Graphics", e.Graphics)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Item", e.Item)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ToolStrip", e.ToolStrip)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"RenderSeparator Event")

End Sub