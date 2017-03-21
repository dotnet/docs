Private Sub ListView1_ItemMouseHover(sender as Object, e as ListViewItemMouseHoverEventArgs) _ 
     Handles ListView1.ItemMouseHover

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Item", e.Item)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"ItemMouseHover Event")

End Sub