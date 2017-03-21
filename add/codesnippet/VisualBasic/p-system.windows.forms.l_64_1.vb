Private Sub ListView1_ItemSelectionChanged(sender as Object, e as ListViewItemSelectionChangedEventArgs) _ 
     Handles ListView1.ItemSelectionChanged

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "IsSelected", e.IsSelected)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Item", e.Item)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ItemIndex", e.ItemIndex)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"ItemSelectionChanged Event")

End Sub