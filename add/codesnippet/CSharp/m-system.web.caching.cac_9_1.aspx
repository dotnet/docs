    public void RemoveItemFromCache(Object sender, EventArgs e) {
        if(Cache["Key1"] != null)
          Cache.Remove("Key1");
    }