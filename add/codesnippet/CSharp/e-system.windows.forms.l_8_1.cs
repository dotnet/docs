    //Manages the cache.  ListView calls this when it might need a 
    //cache refresh.
    void listView1_CacheVirtualItems(object sender, CacheVirtualItemsEventArgs e)
    {
        //We've gotten a request to refresh the cache.
        //First check if it's really neccesary.
        if (myCache != null && e.StartIndex >= firstItem && e.EndIndex <= firstItem + myCache.Length)
        {
            //If the newly requested cache is a subset of the old cache, 
            //no need to rebuild everything, so do nothing.
            return;
        }

        //Now we need to rebuild the cache.
        firstItem = e.StartIndex;
        int length = e.EndIndex - e.StartIndex + 1; //indexes are inclusive
        myCache = new ListViewItem[length];
        
        //Fill the cache with the appropriate ListViewItems.
        int x = 0;
        for (int i = 0; i < length; i++)
        {
            x = (i + firstItem) * (i + firstItem);
            myCache[i] = new ListViewItem(x.ToString());
        }

    }