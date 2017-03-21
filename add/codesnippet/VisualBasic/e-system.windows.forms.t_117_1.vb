Private Sub ToolStrip1_ItemRemoved(sender as Object, e as ToolStripItemEventArgs) _ 
     Handles ToolStrip1.ItemRemoved

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Item", e.Item)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"ItemRemoved Event")

End Sub