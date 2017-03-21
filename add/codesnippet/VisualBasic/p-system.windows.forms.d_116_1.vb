Private Sub ToolTip1_Draw(sender as Object, e as DrawToolTipEventArgs) _ 
     Handles ToolTip1.Draw

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Graphics", e.Graphics)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "AssociatedWindow", e.AssociatedWindow)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "AssociatedControl", e.AssociatedControl)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Bounds", e.Bounds)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ToolTipText", e.ToolTipText)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Font", e.Font)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"Draw Event")

End Sub