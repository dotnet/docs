Private Sub ToolStripRenderer1_RenderToolStripContentPanelBackground(sender as Object, e as ToolStripContentPanelRenderEventArgs) _ 
     Handles ToolStripRenderer1.RenderToolStripContentPanelBackground

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Graphics", e.Graphics)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Handled", e.Handled)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ToolStripContentPanel", e.ToolStripContentPanel)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"RenderToolStripContentPanelBackground Event")

End Sub