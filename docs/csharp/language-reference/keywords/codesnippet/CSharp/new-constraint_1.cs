    class ItemFactory<T> where T : new()
    {
        public T GetNewItem()
        {
            return new T();
        }
    }
