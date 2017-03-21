Private Sub ToolStripRenderer1_RenderItemImage(sender as Object, e as ToolStripItemImageRenderEventArgs) _ 
     Handles ToolStripRenderer1.RenderItemImage

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Image", e.Image)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ImageRectangle", e.ImageRectangle)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Graphics", e.Graphics)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Item", e.Item)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ToolStrip", e.ToolStrip)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"RenderItemImage Event")

End Sub