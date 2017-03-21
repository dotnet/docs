        ' If the collection contains the specified ToolboxItem, 
        ' retrieve the collection index of the specified item.
        Dim indx As Integer = -1
        If collection.Contains(item) Then
            indx = collection.IndexOf(item)
        End If