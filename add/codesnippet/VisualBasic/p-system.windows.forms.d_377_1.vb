Private Sub ListView1_DrawSubItem(sender as Object, e as DrawListViewSubItemEventArgs) _ 
     Handles ListView1.DrawSubItem

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "DrawDefault", e.DrawDefault)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Graphics", e.Graphics)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Bounds", e.Bounds)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Item", e.Item)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "SubItem", e.SubItem)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ItemIndex", e.ItemIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Header", e.Header)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ItemState", e.ItemState)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"DrawSubItem Event")

End Sub