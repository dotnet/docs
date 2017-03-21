Private Sub ToolStripItem1_DragOver(sender as Object, e as DragEventArgs) _ 
     Handles ToolStripItem1.DragOver

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Data", e.Data)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "KeyState", e.KeyState)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "X", e.X)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Y", e.Y)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "AllowedEffect", e.AllowedEffect)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Effect", e.Effect)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"DragOver Event")

End Sub