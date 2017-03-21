public:
    virtual bool Contains(Object^ key)
    {
        int index;
        return TryGetIndexOfKey(key, &index);
    }