    public void Remove(object key)
    {
        if (key == null) throw new ArgumentNullException("key");
        // Try to find the key in the DictionaryEntry array
        Int32 index;
        if (TryGetIndexOfKey(key, out index))
        {
            // If the key is found, slide all the items up.
            Array.Copy(items, index + 1, items, index, ItemsInUse - index - 1);
            ItemsInUse--;
        } 
        else
        {
            // If the key is not in the dictionary, just return. 
        }
    }