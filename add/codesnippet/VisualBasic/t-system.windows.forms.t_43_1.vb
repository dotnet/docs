Private Sub ToolStripRenderer1_RenderToolStripPanelBackground(sender as Object, e as ToolStripPanelRenderEventArgs) _ 
     Handles ToolStripRenderer1.RenderToolStripPanelBackground

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Graphics", e.Graphics)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ToolStripPanel", e.ToolStripPanel)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Handled", e.Handled)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"RenderToolStripPanelBackground Event")

End Sub