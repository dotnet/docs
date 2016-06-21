# Commonly Used Collection Types

Collection types are the common variations of data collections, such as hash tables, queues, stacks, bags, dictionaries, and lists.

Collections are based on the [ICollection](https://docs.microsoft.com/dotnet/core/api/System.Collections.ICollection) interface, the [IList](https://docs.microsoft.com/dotnet/core/api/System.Collections.IList) interface, the [IDictionary](https://docs.microsoft.com/dotnet/core/api/System.Collections.IDictionary) interface, or their generic counterparts. The `IList` interface and the `IDictionary` interface are both derived from the `ICollection` interface; therefore, all collections are based on the `ICollection` interface either directly or indirectly. In collections based on the `IList` interface (such as [Array](https://docs.microsoft.com/dotnet/core/api/System.Array), [ArrayList](https://docs.microsoft.com/dotnet/core/api/System.Collections.ArrayList), or [List&lt;T&gt;)](https://docs.microsoft.com/dotnet/core/api/System.Collections.Generic.List%601) or directly on the `ICollection` interface (such as [Queue](https://docs.microsoft.com/dotnet/core/api/System.Collections.Queue), [ConcurrentQueue&lt;T&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Concurrent.ConcurrentQueue%601), [Stack](https://docs.microsoft.com/dotnet/core/api/System.Collections.Stack), [ConcurrentStack&lt;T&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Concurrent.ConcurrentStack%601) or [LinkedList&lt;T&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Generic.LinkedList%601)), every element contains only a value. In collections based on the `IDictionary` interface (such as the [Hashtable](https://docs.microsoft.com/dotnet/core/api/System.Collections.Hashtable) and [SortedList](https://docs.microsoft.com/dotnet/core/api/System.Collections.SortedList) classes, the [Dictionary&lt;TKey, TValue&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Generic.Dictionary%602) and [SortedList&lt;TKey, TValue&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Generic.SortedList%602) generic classes), or the [ConcurrentDictionary&lt;TKey, TValue&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Concurrent.ConcurrentDictionary%602) classes, every element contains both a key and a value. The [KeyedCollection&lt;TKey, TItem&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.ObjectModel.KeyedCollection%602) class is unique because it is a list of values with keys embedded within the values and, therefore, it behaves like a list and like a dictionary.

Generic collections are the best solution to strong typing. However, if your language does not support generics, the [System.Collections](https://docs.microsoft.com/dotnet/core/api/System.Collections) namespace includes base collections, such as [CollectionBase](https://docs.microsoft.com/dotnet/core/api/System.Collections.CollectionBase), [ReadOnlyCollectionBase](https://docs.microsoft.com/dotnet/core/api/System.Collections.ReadOnlyCollectionBase), and [DictionaryBase](https://docs.microsoft.com/dotnet/core/api/System.Collections.DictionaryBase), which are abstract base classes that can be extended to create collection classes that are strongly typed. When efficient multi-threaded collection access is required, use the generic collections in the [System.Collections.Concurrent](https://docs.microsoft.com/dotnet/core/api/System.Collections.Concurrent) namespace.

Collections can vary, depending on how the elements are stored, how they are sorted, how searches are performed, and how comparisons are made. The [Queue](https://docs.microsoft.com/dotnet/core/api/System.Collections.Queue) class and the [Queue&lt;T&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Generic.Queue%601) generic class provide first-in-first-out lists, while the [Stack](https://docs.microsoft.com/dotnet/core/api/System.Collections.Stack) class and the [Stack&lt;T&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Generic.Stack%601) generic class provide last-in-first-out lists. The [SortedList](https://docs.microsoft.com/dotnet/core/api/System.Collections.SortedList) class and the [SortedList&lt;TKey, TValue&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Generic.SortedList%602) generic class provide sorted versions of the [Hashtable](https://docs.microsoft.com/dotnet/core/api/System.Collections.Hashtable) class and the [Dictionary&lt;TKey, TValue&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Generic.Dictionary%602) generic class. The elements of a `Hashtable` or a `Dictionary&lt;TKey, TValue&gt;` are accessible only by the key of the element, but the elements of a `SortedList` or a [KeyedCollection&lt;TKey, TItem&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.ObjectModel.KeyedCollection%602) are accessible either by the key or by the index of the element. The indexes in all collections are zero-based, except [Array](https://docs.microsoft.com/dotnet/core/api/System.Array), which allows arrays that are not zero-based.

The LINQ to Objects feature allows you to use LINQ queries to access in-memory objects as long as the object type implements [IEnumerable](https://docs.microsoft.com/dotnet/core/api/System.Collections.IEnumerable) or [IEnumerable&lt;T&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Generic.IEnumerable%601). LINQ queries provide a common pattern for accessing data; are typically more concise and readable than standard foreach loops; and provide filtering, ordering and grouping capabilities. LINQ queries can also improve performance.

## Related Topics

Title | Description
----- | -----------
[Collections and Data Structures](collections-and-data-structures.md) | Discusses the various collection types available in the .NET Framework, including stacks, queues, lists, arrays, and dictionaries.
[Hashtable and Dictionary Collection Types](hashtable-and-dictionary-collection-types.md) | Describes the features of generic and non-generic hash-based dictionary types.
[Sorted Collection Types](sorted-collection-types.md) | Describes sorted collections performance and characteristics.

## Reference

[System.Collections](https://docs.microsoft.com/dotnet/core/api/System.Collections)

[System.Collections.Generic](https://docs.microsoft.com/dotnet/core/api/System.Collections.Generic)

[System.Collections.ICollection](https://docs.microsoft.com/dotnet/core/api/System.Collections.ICollection)

[System.Collections.Generic.ICollection&lt;T&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Generic.ICollection%601)

[System.Collections.IList](https://docs.microsoft.com/dotnet/core/api/System.Collections.IList)

[System.Collections.Generic.IList&lt;T&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Generic.IList%601)

[System.Collections.IDictionary](https://docs.microsoft.com/dotnet/core/api/System.Collections.IDictionary)

[System.Collections.Generic.IDictionary&lt;TKey, TValue&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Generic.IDictionary%602)

[System.Linq](https://docs.microsoft.com/dotnet/core/api/System.Linq)
