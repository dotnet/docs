        // Add objects with a short weak reference to the cache.
       for (int i = 0; i < count; i++) {
            _cache.Add(i, new WeakReference(new Data(i), false));
        }