Private Sub ToolStripRenderer1_RenderToolStripBackground(sender as Object, e as ToolStripRenderEventArgs) _ 
     Handles ToolStripRenderer1.RenderToolStripBackground

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "AffectedBounds", e.AffectedBounds)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "BackColor", e.BackColor)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Graphics", e.Graphics)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ToolStrip", e.ToolStrip)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ConnectedArea", e.ConnectedArea)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"RenderToolStripBackground Event")

End Sub