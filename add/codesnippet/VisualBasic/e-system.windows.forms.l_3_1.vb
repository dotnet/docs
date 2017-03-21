    'The basic VirtualMode function.  Dynamically returns a ListViewItem
    'with the required properties; in this case, the square of the index.
    Private Sub listView1_RetrieveVirtualItem(ByVal sender As Object, ByVal e As RetrieveVirtualItemEventArgs) Handles listView1.RetrieveVirtualItem
        'Caching is not required but improves performance on large sets.
        'To leave out caching, don't connect the CacheVirtualItems event 
        'and make sure myCache is null.
        'check to see if the requested item is currently in the cache
        If Not (myCache Is Nothing) AndAlso e.ItemIndex >= firstItem AndAlso e.ItemIndex < firstItem + myCache.Length Then
            'A cache hit, so get the ListViewItem from the cache instead of making a new one.
            e.Item = myCache((e.ItemIndex - firstItem))
        Else
            'A cache miss, so create a new ListViewItem and pass it back.
            Dim x As Integer = e.ItemIndex * e.ItemIndex
            e.Item = New ListViewItem(x.ToString())
        End If


    End Sub