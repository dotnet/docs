public:
    virtual void Add(Object^ key, Object^ value)
    {
        // Add the new key/value pair even if this key already exists
        // in the dictionary.
        if (itemsInUse == items->Length)
        {
            throw gcnew InvalidOperationException
                ("The dictionary cannot hold any more items.");
        }
        items[itemsInUse++] = gcnew DictionaryEntry(key, value);
    }