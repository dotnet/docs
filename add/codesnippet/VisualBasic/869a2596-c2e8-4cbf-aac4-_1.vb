Private Sub ListView1_VirtualItemsSelectionRangeChanged(sender as Object, e as ListViewVirtualItemsSelectionRangeChangedEventArgs) _ 
     Handles ListView1.VirtualItemsSelectionRangeChanged

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "EndIndex", e.EndIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "IsSelected", e.IsSelected)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "StartIndex", e.StartIndex)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"VirtualItemsSelectionRangeChanged Event")

End Sub