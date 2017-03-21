public:
    virtual property ICollection^ Keys
    {
        ICollection^ get()
        {
            // Return an array where each item is a key.
            array<Object^>^ keys = gcnew array<Object^>(itemsInUse);
            for (int i = 0; i < itemsInUse; i++)
            {
                keys[i] = items[i]->Key;
            }
            return keys;
        }
    }