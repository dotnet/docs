    void IArray.Insert(int index, Object value)
    {
        Contract.Requires(index >= 0);
        Contract.Requires(index <= ((IArray)this).Count);  // For inserting immediately after the end.
        Contract.Ensures(((IArray)this).Count == Contract.OldValue(((IArray)this).Count) + 1);
    }