[ContractClassFor(typeof(IArray))]
internal abstract class IArrayContract : IArray
{
    int IArray.Add(Object value)
    {
        // Returns the index in which an item was inserted.
        Contract.Ensures(Contract.Result<int>() >= -1);
        Contract.Ensures(Contract.Result<int>() < ((IArray)this).Count);
        return default(int);
    }
    Object IArray.this[int index]
    {
        get
        {
            Contract.Requires(index >= 0);
            Contract.Requires(index < ((IArray)this).Count);
            return default(int);
        }
        set
        {
            Contract.Requires(index >= 0);
            Contract.Requires(index < ((IArray)this).Count);
        }
    }
    public int Count
    {
        get
        {
            Contract.Requires(Count >= 0);
            Contract.Requires(Count <= ((IArray)this).Count);
            return default(int);
        }
    }

    void IArray.Clear()
    {
        Contract.Ensures(((IArray)this).Count == 0);
    }

    void IArray.Insert(int index, Object value)
    {
        Contract.Requires(index >= 0);
        Contract.Requires(index <= ((IArray)this).Count);  // For inserting immediately after the end.
        Contract.Ensures(((IArray)this).Count == Contract.OldValue(((IArray)this).Count) + 1);
    }

    void IArray.RemoveAt(int index)
    {
        Contract.Requires(index >= 0);
        Contract.Requires(index < ((IArray)this).Count);
        Contract.Ensures(((IArray)this).Count == Contract.OldValue(((IArray)this).Count) - 1);
    }
}