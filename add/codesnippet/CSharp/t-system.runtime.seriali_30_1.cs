    [CollectionDataContract(Name = "Custom{0}List", ItemName = "CustomItem")]
    public class CustomList<T> : List<T>
    {
        public CustomList()
            : base()
        {
        }

        public CustomList(T[] items)
            : base()
        {
            foreach (T item in items)
            {
                Add(item);
            }
        }
    }