Private Sub ToolStripRenderer1_RenderGrip(sender as Object, e as ToolStripGripRenderEventArgs) _ 
     Handles ToolStripRenderer1.RenderGrip

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "GripBounds", e.GripBounds)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "GripDisplayStyle", e.GripDisplayStyle)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "GripStyle", e.GripStyle)
    messageBoxVB.AppendLine()
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
    MessageBox.Show(messageBoxVB.ToString(),"RenderGrip Event")

End Sub