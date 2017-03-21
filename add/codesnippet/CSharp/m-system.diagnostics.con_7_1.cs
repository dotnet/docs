    int IArray.Add(Object value)
    {
        // Returns the index in which an item was inserted.
        Contract.Ensures(Contract.Result<int>() >= -1);
        Contract.Ensures(Contract.Result<int>() < ((IArray)this).Count);
        return default(int);
    }