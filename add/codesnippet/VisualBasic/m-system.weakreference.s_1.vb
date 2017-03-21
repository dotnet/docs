        ' Add data objects with a short weak reference to the cache. 
        For ctr = 0 To count - 1
            _cache.Add(ctr, New WeakReference(New Data(ctr)))
        Next