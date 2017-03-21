    static bool itemRemoved = false;
    static CacheItemRemovedReason reason;
    CacheItemRemovedCallback onRemove = null;

    public void RemovedCallback(String k, Object v, CacheItemRemovedReason r){
      itemRemoved = true;
      reason = r;
    }