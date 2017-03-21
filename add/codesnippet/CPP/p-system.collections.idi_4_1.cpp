public:
    virtual property Object^ default[Object^]
    {
        Object^ get(Object^ key)
        {
            // If this key is in the dictionary, return its value.
            int index;
            if (TryGetIndexOfKey(key, &index))
            {
                // The key was found; return its value.
                return items[index]->Value;
            }
            else
            {
                // The key was not found; return null.
                return nullptr;
            }
        }

        void set(Object^ key, Object^ value)
        {
            // If this key is in the dictionary, change its value.
            int index;
            if (TryGetIndexOfKey(key, &index))
            {
                // The key was found; change its value.
                items[index]->Value = value;
            }
            else
            {
                // This key is not in the dictionary; add this
                // key/value pair.
                Add(key, value);
            }
        }
    }