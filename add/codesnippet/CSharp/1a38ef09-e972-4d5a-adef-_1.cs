    public void Add(object key, object value) 
    {
        // Add the new key/value pair even if this key already exists in the dictionary.
        if (ItemsInUse == items.Length)
            throw new InvalidOperationException("The dictionary cannot hold any more items.");
        items[ItemsInUse++] = new DictionaryEntry(key, value);
    }