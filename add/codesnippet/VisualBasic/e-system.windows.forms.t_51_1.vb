Private Sub ToolStripItem1_Paint(sender as Object, e as PaintEventArgs) _ 
     Handles ToolStripItem1.Paint

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "ClipRectangle", e.ClipRectangle)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Graphics", e.Graphics)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"Paint Event")

End Sub