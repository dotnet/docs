    public bool Contains(object key)
    {
       Int32 index;
       return TryGetIndexOfKey(key, out index);
    }