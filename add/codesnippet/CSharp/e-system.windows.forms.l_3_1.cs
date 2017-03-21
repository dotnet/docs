    //The basic VirtualMode function.  Dynamically returns a ListViewItem
    //with the required properties; in this case, the square of the index.
    void listView1_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
    {
        //Caching is not required but improves performance on large sets.
        //To leave out caching, don't connect the CacheVirtualItems event 
        //and make sure myCache is null.

        //check to see if the requested item is currently in the cache
        if (myCache != null && e.ItemIndex >= firstItem && e.ItemIndex < firstItem + myCache.Length)
        {
            //A cache hit, so get the ListViewItem from the cache instead of making a new one.
            e.Item = myCache[e.ItemIndex - firstItem];
        }
        else
        {
            //A cache miss, so create a new ListViewItem and pass it back.
            int x = e.ItemIndex * e.ItemIndex;
            e.Item = new ListViewItem(x.ToString());
        }
    }