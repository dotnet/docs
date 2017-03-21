    ' Creates a Hashtable object with one entry for each unique
    ' subitem value (or initial letter for the parent item)
    ' in the specified column.
    Private Function CreateGroupsTable(column As Integer) As Hashtable
        ' Create a Hashtable object.
        Dim groups As New Hashtable()
        
        ' Iterate through the items in myListView.
        Dim item As ListViewItem
        For Each item In myListView.Items
            ' Retrieve the text value for the column.
            Dim subItemText As String = item.SubItems(column).Text
            
            ' Use the initial letter instead if it is the first column.
            If column = 0 Then
                subItemText = subItemText.Substring(0, 1)
            End If 

            ' If the groups table does not already contain a group
            ' for the subItemText value, add a new group using the 
            ' subItemText value for the group header and Hashtable key.
            If Not groups.Contains(subItemText) Then
                groups.Add( subItemText, New ListViewGroup(subItemText, _
                    HorizontalAlignment.Left) )
            End If
        Next item
        
        ' Return the Hashtable object.
        Return groups
    End Function 'CreateGroupsTable