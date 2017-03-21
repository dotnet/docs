Private Sub ToolStrip1_PaintGrip(sender as Object, e as PaintEventArgs) _ 
     Handles ToolStrip1.PaintGrip

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "ClipRectangle", e.ClipRectangle)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Graphics", e.Graphics)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"PaintGrip Event")

End Sub