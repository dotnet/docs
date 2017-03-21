    public void AddItemToCache(Object sender, EventArgs e) {
        itemRemoved = false;

        onRemove = new CacheItemRemovedCallback(this.RemovedCallback);

        if (Cache["Key1"] == null)
          Cache.Add("Key1", "Value 1", null, DateTime.Now.AddSeconds(60), Cache.NoSlidingExpiration, CacheItemPriority.High, onRemove);
    }