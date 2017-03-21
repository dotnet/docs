Private Sub ListView1_CacheVirtualItems(sender as Object, e as CacheVirtualItemsEventArgs) _ 
     Handles ListView1.CacheVirtualItems

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "StartIndex", e.StartIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "EndIndex", e.EndIndex)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"CacheVirtualItems Event")

End Sub