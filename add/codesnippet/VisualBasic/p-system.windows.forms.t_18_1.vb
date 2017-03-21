Private Sub ToolStrip1_ItemClicked(sender as Object, e as ToolStripItemClickedEventArgs) _ 
     Handles ToolStrip1.ItemClicked

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "ClickedItem", e.ClickedItem)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"ItemClicked Event")

End Sub