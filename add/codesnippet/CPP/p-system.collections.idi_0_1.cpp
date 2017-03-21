public:
    virtual property ICollection^ Values
    {
        ICollection^ get()
        {
            // Return an array where each item is a value.
            array<Object^>^ values = gcnew array<Object^>(itemsInUse);
            for (int i = 0; i < itemsInUse; i++)
            {
                values[i] = items[i]->Value;
            }
            return values;
        }
    }