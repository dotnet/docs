Private Sub MenuItem1_MeasureItem(sender as Object, e as MeasureItemEventArgs) _ 
     Handles MenuItem1.MeasureItem

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Graphics", e.Graphics)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Index", e.Index)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ItemHeight", e.ItemHeight)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ItemWidth", e.ItemWidth)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"MeasureItem Event")

End Sub