    interface IMyInterface
    {
    }

    class Dictionary<TKey, TVal>
        where TKey : IComparable, IEnumerable
        where TVal : IMyInterface
    {
        public void Add(TKey key, TVal val)
        {
        }
    }