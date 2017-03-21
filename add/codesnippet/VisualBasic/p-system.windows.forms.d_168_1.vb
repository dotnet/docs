Private Sub ListView1_DrawItem(sender as Object, e as DrawListViewItemEventArgs) _ 
     Handles ListView1.DrawItem

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "DrawDefault", e.DrawDefault)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Graphics", e.Graphics)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Item", e.Item)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Bounds", e.Bounds)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ItemIndex", e.ItemIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "State", e.State)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"DrawItem Event")

End Sub