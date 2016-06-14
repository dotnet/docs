# Commonly Used Collection Types

Collection types are the common variations of data collections, such as hash tables, queues, stacks, bags, dictionaries, and lists.

Collections are based on the [ICollection](https://dotnet.github.io/api/System.Collections.ICollection.html) interface, the [IList](https://dotnet.github.io/api/System.Collections.IList.html) interface, the [IDictionary](https://dotnet.github.io/api/System.Collections.IDictionary.html) interface, or their generic counterparts. The `IList` interface and the `IDictionary` interface are both derived from the `ICollection` interface; therefore, all collections are based on the `ICollection` interface either directly or indirectly. In collections based on the `IList` interface (such as [Array](https://dotnet.github.io/api/System.Array.html), [ArrayList](https://dotnet.github.io/api/System.Collections.ArrayList.html), or [List&lt;T&gt;)](https://dotnet.github.io/api/System.Collections.Generic.List%601.html) or directly on the `ICollection` interface (such as [Queue](https://dotnet.github.io/api/System.Collections.Queue.html), [ConcurrentQueue&lt;T&gt;](https://dotnet.github.io/api/System.Collections.Concurrent.ConcurrentQueue%601.html), [Stack](https://dotnet.github.io/api/System.Collections.Stack.html), [ConcurrentStack&lt;T&gt;](https://dotnet.github.io/api/System.Collections.Concurrent.ConcurrentStack%601.html) or [LinkedList&lt;T&gt;](https://dotnet.github.io/api/System.Collections.Generic.LinkedList%601.html)), every element contains only a value. In collections based on the `IDictionary` interface (such as the [Hashtable](https://dotnet.github.io/api/System.Collections.Hashtable.html) and [SortedList](https://dotnet.github.io/api/System.Collections.SortedList.html) classes, the [Dictionary&lt;TKey, TValue&gt;](https://dotnet.github.io/api/System.Collections.Generic.Dictionary%602.html) and [SortedList&lt;TKey, TValue&gt;](https://dotnet.github.io/api/System.Collections.Generic.SortedList%602.html) generic classes), or the [ConcurrentDictionary&lt;TKey, TValue&gt;](https://dotnet.github.io/api/System.Collections.Concurrent.ConcurrentDictionary%602.html) classes, every element contains both a key and a value. The [KeyedCollection&lt;TKey, TItem&gt;](https://dotnet.github.io/api/System.Collections.ObjectModel.KeyedCollection%602.html) class is unique because it is a list of values with keys embedded within the values and, therefore, it behaves like a list and like a dictionary.

Generic collections are the best solution to strong typing. However, if your language does not support generics, the [System.Collections](https://dotnet.github.io/api/System.Collections.html) namespace includes base collections, such as [CollectionBase](https://dotnet.github.io/api/System.Collections.CollectionBase.html), [ReadOnlyCollectionBase](https://dotnet.github.io/api/System.Collections.ReadOnlyCollectionBase.html), and [DictionaryBase](https://dotnet.github.io/api/System.Collections.DictionaryBase.html), which are abstract base classes that can be extended to create collection classes that are strongly typed. When efficient multi-threaded collection access is required, use the generic collections in the [System.Collections.Concurrent](https://dotnet.github.io/api/System.Collections.Concurrent.html) namespace.

Collections can vary, depending on how the elements are stored, how they are sorted, how searches are performed, and how comparisons are made. The [Queue](https://dotnet.github.io/api/System.Collections.Queue.html) class and the [Queue&lt;T&gt;](https://dotnet.github.io/api/System.Collections.Generic.Queue%601.html) generic class provide first-in-first-out lists, while the [Stack](https://dotnet.github.io/api/System.Collections.Stack.html) class and the [Stack&lt;T&gt;](https://dotnet.github.io/api/System.Collections.Generic.Stack%601.html) generic class provide last-in-first-out lists. The [SortedList](https://dotnet.github.io/api/System.Collections.SortedList.html) class and the [SortedList&lt;TKey, TValue&gt;](https://dotnet.github.io/api/System.Collections.Generic.SortedList%602.html) generic class provide sorted versions of the [Hashtable](https://dotnet.github.io/api/System.Collections.Hashtable.html) class and the [Dictionary&lt;TKey, TValue&gt;](https://dotnet.github.io/api/System.Collections.Generic.Dictionary%602.html) generic class. The elements of a `Hashtable` or a `Dictionary&lt;TKey, TValue&gt;` are accessible only by the key of the element, but the elements of a `SortedList` or a [KeyedCollection&lt;TKey, TItem&gt;](https://dotnet.github.io/api/System.Collections.ObjectModel.KeyedCollection%602.html) are accessible either by the key or by the index of the element. The indexes in all collections are zero-based, except [Array](https://dotnet.github.io/api/System.Array.html), which allows arrays that are not zero-based.

The LINQ to Objects feature allows you to use LINQ queries to access in-memory objects as long as the object type implements [IEnumerable](https://dotnet.github.io/api/System.Collections.IEnumerable.html) or [IEnumerable&lt;T&gt;](https://dotnet.github.io/api/System.Collections.Generic.IEnumerable%601.html). LINQ queries provide a common pattern for accessing data; are typically more concise and readable than standard foreach loops; and provide filtering, ordering and grouping capabilities. LINQ queries can also improve performance.

## Related Topics

Title | Description
----- | -----------
[Collections and Data Structures](Collections-and-Data-Structures.md) | Discusses the various collection types available in the .NET Framework, including stacks, queues, lists, arrays, and dictionaries.
[Hashtable and Dictionary Collection Types](hashtableandDictionaryCollectionTypes.md) | Describes the features of generic and non-generic hash-based dictionary types.
[Sorted Collection Types](sortedCollectionTypes.md) | Describes sorted collections performance and characteristics.

## Reference

[System.Collections](http://dotnet.github.io/api/System.Collections.html)

[System.Collections.Generic](http://dotnet.github.io/api/System.Collections.Generic.html)

[System.Collections.ICollection](https://dotnet.github.io/api/System.Collections.ICollection.html)

[System.Collections.Generic.ICollection&lt;T&gt;](https://dotnet.github.io/api/System.Collections.Generic.ICollection%601.html)

[System.Collections.IList](https://dotnet.github.io/api/System.Collections.IList.html)

[System.Collections.Generic.IList&lt;T&gt;](https://dotnet.github.io/api/System.Collections.Generic.IList%601.html)

[System.Collections.IDictionary](https://dotnet.github.io/api/System.Collections.IDictionary.html)

[System.Collections.Generic.IDictionary&lt;TKey, TValue&gt;](https://dotnet.github.io/api/System.Collections.Generic.IDictionary%602.html)

[System.Linq](http://dotnet.github.io/api/System.Linq.html)
