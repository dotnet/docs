Private Sub ToolStripRenderer1_RenderItemText(sender as Object, e as ToolStripItemTextRenderEventArgs) _ 
     Handles ToolStripRenderer1.RenderItemText

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Text", e.Text)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "TextColor", e.TextColor)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "TextFont", e.TextFont)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "TextRectangle", e.TextRectangle)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "TextFormat", e.TextFormat)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "TextDirection", e.TextDirection)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Graphics", e.Graphics)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Item", e.Item)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ToolStrip", e.ToolStrip)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"RenderItemText Event")

End Sub