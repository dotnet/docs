    public object this[object key]
    {
        get
        {   
            // If this key is in the dictionary, return its value.
            Int32 index;
            if (TryGetIndexOfKey(key, out index))
            {
                // The key was found; return its value.
                return items[index].Value;
            } 
            else
            {
                // The key was not found; return null.
                return null;
            }
        }

        set
        {
            // If this key is in the dictionary, change its value. 
            Int32 index;
            if (TryGetIndexOfKey(key, out index))
            {
                // The key was found; change its value.
                items[index].Value = value;
            } 
            else
            {
                // This key is not in the dictionary; add this key/value pair.
                Add(key, value);
            }
        }
    }