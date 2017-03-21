    'Manages the cache.  ListView calls this when it might need a 
    'cache refresh.
    Private Sub listView1_CacheVirtualItems(ByVal sender As Object, ByVal e As CacheVirtualItemsEventArgs) Handles listView1.CacheVirtualItems
        'We've gotten a request to refresh the cache.
        'First check if it's really neccesary.
        If Not (myCache Is Nothing) AndAlso e.StartIndex >= firstItem AndAlso e.EndIndex <= firstItem + myCache.Length Then
            'If the newly requested cache is a subset of the old cache, 
            'no need to rebuild everything, so do nothing.
            Return
        End If

        'Now we need to rebuild the cache.
        firstItem = e.StartIndex
        Dim length As Integer = e.EndIndex - e.StartIndex + 1 'indexes are inclusive
        myCache = New ListViewItem(length) {}

        'Fill the cache with the appropriate ListViewItems.
        Dim x As Integer = 0
        Dim i As Integer
        For i = 0 To length
            x = (i + firstItem) * (i + firstItem)
            myCache(i) = New ListViewItem(x.ToString())
        Next i

    End Sub