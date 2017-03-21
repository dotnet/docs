    public ICollection Keys
    {
        get
        {
            // Return an array where each item is a key.
            Object[] keys = new Object[ItemsInUse];
            for (Int32 n = 0; n < ItemsInUse; n++)
                keys[n] = items[n].Key;
            return keys;
        }
    }