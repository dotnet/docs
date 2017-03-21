Private Sub ListView1_RetrieveVirtualItem(sender as Object, e as RetrieveVirtualItemEventArgs) _ 
     Handles ListView1.RetrieveVirtualItem

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "ItemIndex", e.ItemIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Item", e.Item)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"RetrieveVirtualItem Event")

End Sub