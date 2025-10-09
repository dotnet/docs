using System.Collections.Generic;

namespace ca1001
{
    //<snippet1>
    // This class violates the rule.
    public class MutableItems
    {
        // CA1002: Change 'List<string>' in 'MutableItems.Items' to
        // use 'Collection<T>', 'ReadOnlyCollection<T>' or 'KeyedCollection<K,V>'.
        public List<string> Items { get; } = [];

        public void Add(string item)
        {
            Items.Add(item);
        }
    }

    // This class satisfies the rule.
    public class ReadOnlyItems
    {
        private readonly List<string> _items = [];

        public IReadOnlyCollection<string> Items => _items.AsReadOnly();

        public void Add(string item)
        {
            _items.Add(item);
        }
    }
    //</snippet1>
}
