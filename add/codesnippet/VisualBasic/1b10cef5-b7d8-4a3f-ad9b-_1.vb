    ' Sets myListView to the groups created for the specified column.
    Private Sub SetGroups(column As Integer)
        ' Remove the current groups.
        myListView.Groups.Clear()
        
        ' Retrieve the hash table corresponding to the column.
        Dim groups As Hashtable = CType(groupTables(column), Hashtable)
        
        ' Copy the groups for the column to an array.
        Dim groupsArray(groups.Count - 1) As ListViewGroup
        groups.Values.CopyTo(groupsArray, 0)
        
        ' Sort the groups and add them to myListView.
        Array.Sort(groupsArray, New ListViewGroupSorter(myListView.Sorting))
        myListView.Groups.AddRange(groupsArray)
        
        ' Iterate through the items in myListView, assigning each 
        ' one to the appropriate group.
        Dim item As ListViewItem
        For Each item In myListView.Items
            ' Retrieve the subitem text corresponding to the column.
            Dim subItemText As String = item.SubItems(column).Text
            
            ' For the Title column, use only the first letter.
            If column = 0 Then
                subItemText = subItemText.Substring(0, 1)
            End If 

            ' Assign the item to the matching group.
            item.Group = CType(groups(subItemText), ListViewGroup)
        Next item
    End Sub 'SetGroups