Private Sub ListView1_ItemDrag(sender as Object, e as ItemDragEventArgs) _ 
     Handles ListView1.ItemDrag

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Button", e.Button)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Item", e.Item)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"ItemDrag Event")

End Sub