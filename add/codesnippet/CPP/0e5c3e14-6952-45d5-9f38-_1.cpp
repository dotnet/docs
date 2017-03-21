public:
    virtual void Remove(Object^ key)
    {
        if (key == nullptr)
        {
            throw gcnew ArgumentNullException("key");
        }
        // Try to find the key in the DictionaryEntry array
        int index;
        if (TryGetIndexOfKey(key, &index))
        {
            // If the key is found, slide all the items down.
            Array::Copy(items, index + 1, items, index, itemsInUse -
                index - 1);
            itemsInUse--;
        }
        else
        {
            // If the key is not in the dictionary, just return.
            return;
        }
    }