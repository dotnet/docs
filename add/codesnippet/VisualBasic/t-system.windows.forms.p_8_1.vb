Private Sub ToolTip1_Popup(sender as Object, e as PopupEventArgs) _ 
     Handles ToolTip1.Popup

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "AssociatedWindow", e.AssociatedWindow)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "AssociatedControl", e.AssociatedControl)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "IsBalloon", e.IsBalloon)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ToolTipSize", e.ToolTipSize)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Cancel", e.Cancel)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"Popup Event")

End Sub