Private Sub ToolStrip1_ItemAdded(sender as Object, e as ToolStripItemEventArgs) _ 
     Handles ToolStrip1.ItemAdded

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Item", e.Item)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"ItemAdded Event")

End Sub