# When to Use Generic Collections

Using generic collections is generally recommended, because you gain the immediate benefit of type safety without having to derive from a base collection type and implement type-specific members. Generic collection types also generally perform better than the corresponding nongeneric collection types (and better than types that are derived from nongeneric base collection types) when the collection elements are value types, because with generics there is no need to box the elements. 

You should use the generic collection classes in the [System.Collections.Concurrent](https://dotnet.github.io/api/System.Collections.Concurrent.html) namespace when multiple threads might be adding or removing items from the collection concurrently.

The following generic types correspond to existing collection types: 

*   [List&lt;T&gt;](https://dotnet.github.io/api/System.Collections.Generic.List%601.html) is the generic class that corresponds to [ArrayList](https://dotnet.github.io/api/System.Collections.ArrayList.html).

*   [Dictionary&lt;TKey, TValue&gt;](https://dotnet.github.io/api/System.Collections.Generic.Dictionary%602.html) and [ConcurrentDictionary&lt;TKey, TValue&gt;](https://dotnet.github.io/api/System.Collections.Concurrent.ConcurrentDictionary%602.html) are the generic classes that correspond to [Hashtable](https://dotnet.github.io/api/System.Collections.Hashtable.html). 

*   [Collection&lt;T&gt;](https://dotnet.github.io/api/System.Collections.ObjectModel.Collection%601.html) is the generic class that corresponds to [CollectionBase](https://dotnet.github.io/api/System.Collections.CollectionBase.html). `Collection&lt<T>` can be used as a base class, but unlike `CollectionBase`, it is not abstract. This makes it much easier to use.

*   [ReadOnlyCollection&lt;T&gt;](https://dotnet.github.io/api/System.Collections.ObjectModel.ReadOnlyCollection%601.html) is the generic class that corresponds to [ReadOnlyCollectionBase](https://dotnet.github.io/api/System.Collections.ReadOnlyCollectionBase.html). `ReadOnlyCollection<T>` is not abstract, and has a constructor that makes it easy to expose an existing [List&lt;T&gt;](https://dotnet.github.io/api/System.Collections.Generic.List%601.html) as a read-only collection.

*   The [Queue&lt;T&gt;](https://dotnet.github.io/api/System.Collections.Generic.Queue%601.html), [ConcurrentQueue&lt;T&gt;](https://dotnet.github.io/api/System.Collections.Concurrent.ConcurrentQueue%601.html), [Stack&lt;T&gt;](https://dotnet.github.io/api/System.Collections.Generic.Stack%601.html), [ConcurrentStack&lt;T&gt;](https://dotnet.github.io/api/System.Collections.Concurrent.ConcurrentStack%601.html), and [SortedList&lt;TKey, TValue&gt;](https://dotnet.github.io/api/System.Collections.Generic.SortedList%602.html) generic classes correspond to the respective nongeneric classes with the same names.

## Additional Types

Several generic collection types do not have nongeneric counterparts. They include the following: 

*   [LinkedList&lt;T&gt;](https://dotnet.github.io/api/System.Collections.Generic.LinkedList%601.html) is a general-purpose linked list that provides O(1) insertion and removal operations.

*   [SortedDictionary&lt;TKey, TValue&gt;](https://dotnet.github.io/api/System.Collections.Generic.SortedDictionary%602.html) is a sorted dictionary with O(log n) insertion and retrieval operations, which makes it a useful alternative to [SortedList&lt;TKey, TValue&gt;](https://dotnet.github.io/api/System.Collections.Generic.SortedList%602.html). 

*   [KeyedCollection&lt;TKey, TItem&gt;](https://dotnet.github.io/api/System.Collections.ObjectModel.KeyedCollection%602.html) is a hybrid between a list and a dictionary, which provides a way to store objects that contain their own keys.

*   [BlockingCollection&lt;T&gt;](https://dotnet.github.io/api/System.Collections.Concurrent.BlockingCollection%601.html) implements a collection class with bounding and blocking functionality.

*   [ConcurrentBag&lt;T&gt;](https://dotnet.github.io/api/System.Collections.Concurrent.ConcurrentBag%601.html) provides fast insertion and removal of unordered elements.

## LINQ to Objects

The LINQ to Objects feature enables you to use LINQ queries to access in-memory objects as long as the object type implements the [System.Collections.IEnumerable](https://dotnet.github.io/api/System.Collections.IEnumerable.html) or [System.Collections.Generic.IEnumerable&lt;T&gt;](https://dotnet.github.io/api/System.Collections.Generic.IEnumerable%601.html) interface. LINQ queries provide a common pattern for accessing data; are typically more concise and readable than standard `foreach` loops; and provide filtering, ordering and grouping capabilities. LINQ queries can also improve performance.

## Additional Functionality

Some of the generic types have functionality that is not found in the nongeneric collection types. For example, the [List&lt;T&gt;](https://dotnet.github.io/api/System.Collections.Generic.List%601.html) class, which corresponds to the nongeneric [ArrayList](https://dotnet.github.io/api/System.Collections.ArrayList.html) class, has a number of methods that accept generic delegates, such as the [Predicate&lt;T&gt;](https://dotnet.github.io/api/System.Predicate%601.html) delegate that allows you to specify methods for searching the list, and the [Action&lt;T&gt;](https://dotnet.github.io/api/System.Action%601.html) delegate that represents methods that act on each element of the list.

The [List&lt;T&gt;](https://dotnet.github.io/api/System.Collections.Generic.List%601.html) class allows you to specify your own [IComparer&lt;T&gt;](https://dotnet.github.io/api/System.Collections.Generic.IComparer%601.html) generic interface implementations for sorting and searching the list. The [SortedDictionary&lt;TKey, TValue&gt;](https://dotnet.github.io/api/System.Collections.Generic.SortedDictionary%602.html) and [SortedList&lt;TKey, TValue&gt;](https://dotnet.github.io/api/System.Collections.Generic.SortedList%602.html) classes also have this capability. In addition, these classes let you specify comparers when the collection is created. In similar fashion, the [Dictionary&lt;TKey, TValue&gt;](https://dotnet.github.io/api/System.Collections.Generic.Dictionary%602.html) and [KeyedCollection&lt;TKey, TItem&gt;](https://dotnet.github.io/api/System.Collections.ObjectModel.KeyedCollection%602.html) classes let you specify your own equality comparers.

## See Also

[Collections and Data Structures](Collections-and-Data-Structures.md) 

[Commonly Used Collection Types](commonlyUsedCollectionTypes.md)
