Private Sub ListView1_SearchForVirtualItem(sender as Object, e as SearchForVirtualItemEventArgs) _ 
     Handles ListView1.SearchForVirtualItem

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "IsTextSearch", e.IsTextSearch)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "IncludeSubItemsInSearch", e.IncludeSubItemsInSearch)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Index", e.Index)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "IsPrefixSearch", e.IsPrefixSearch)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Text", e.Text)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "StartingPoint", e.StartingPoint)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Direction", e.Direction)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "StartIndex", e.StartIndex)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"SearchForVirtualItem Event")

End Sub