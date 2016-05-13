# Collections and Data Structures

Similar data can often be handled more efficiently when stored and manipulated as a collection. You can use the [System.Array](http://dotnet.github.io/api/System.Array.html) class or the classes in the [System.Collections](http://dotnet.github.io/api/System.Collections), [System.Collections.Generic](http://dotnet.github.io/api/System.Collections.Generic.html), or [System.Collections.Concurrent](http://dotnet.github.io/api/System.Collections.Concurrent.html) namespaces to add, remove, and modify either individual elements or a range of elements in a collection.

There are two main types of collections; generic collections and non-generic collections. Generic collections are type-safe at compile time. Because of this, generic collections typically offer better performance. Generic collections accept a type parameter when they are constructed and do not require that you cast to and from the [Object](http://dotnet.github.io/api/System.Object.html) type when you add or remove items from the collection. Non-generic collections store items as [Object](http://dotnet.github.io/api/System.Object.html) and require casting. You may see non-generic collections in older code.

The collections in the [System.Collections.Concurrent](http://dotnet.github.io/api/System.Collections.Concurrent.html) namespace provide efficient thread-safe operations for accessing collection items from multiple threads.

## Common collection features

All collections provide methods for adding, removing or finding items in the collection. In addition, all collections that directly or indirectly implement the [ICollection](http://dotnet.github.io/api/System.Collections.ICollection.html) interface or the [ICollection&lt;T&gt;](http://dotnet.github.io/api/System.Collections.Generic.ICollection%601.html) interface share these features: 

* **The ability to enumerate the collection**

    .NET Framework collections either implement [System.Collections.IEnumerable](http://dotnet.github.io/api/System.Collections.IEnumerable.html) or [System.Collections.Generic.IEnumerable&lt;T&gt;](http://dotnet.github.io/api/System.Collections.Generic.IEnumerable%601.html) to enable the collection to be iterated through. An enumerator can be thought of as a movable pointer to any element in the collection. The `foreach, in` statement (C#) uses the enumerator exposed by the `GetEnumerator` method and hides the complexity of manipulating the enumerator. In addition, any collection that implements [System.Collections.Generic.IEnumerable&lt;T&gt;](http://dotnet.github.io/api/System.Collections.Generic.IEnumerable%601.html) is considered a queryable type and can be queried with LINQ. LINQ queries provide a common pattern for accessing data. They are typically more concise and readable than standard for each loops, and provide filtering, ordering and grouping capabilities. LINQ queries can also improve performance.
    
* **The ability to copy the collection contents to an array**

    All collections can be copied to an array using the `CopyTo` method; however, the order of the elements in the new array is based on the sequence in which the enumerator returns them. The resulting array is always one-dimensional with a lower bound of zero.
    
In addition, many collection classes contain the following features:

* **Capacity and Count properties**

    The capacity of a collection is the number of elements it can contain. The count of a collection is the number of elements it actually contains. Some collections hide the capacity or the count or both.
    
    Most collections automatically expand in capacity when the current capacity is reached. The memory is reallocated, and the elements are copied from the old collection to the new one. This reduces the code required to use the collection; however, the performance of the collection might be negatively affected. For example, for [List&lt;T&gt;](http://dotnet.github.io/api/System.Collections.Generic.List%601.html), if `Count` is less than `Capacity`, adding an item is an O(1) operation. If the capacity needs to be increased to accommodate the new element, adding an item becomes an O(n) operation, where n is `Count`. The best way to avoid poor performance caused by multiple reallocations is to set the initial capacity to be the estimated size of the collection. 
    
    A [BitArray](http://dotnet.github.io/api/System.Collections.BitArray.html) is a special case; its capacity is the same as its length, which is the same as its count.
    
*   **A consistent lower bound**

    The lower bound of a collection is the index of its first element. All indexed collections in the [System.Collections](http://dotnet.github.io/api/System.Collections) namespaces have a lower bound of zero, meaning they are 0-indexed. [Array](http://dotnet.github.io/api/System.Array.html) has a lower bound of zero by default, but a different lower bound can be defined when creating an instance of the `Array` class using `Array.CreateInstance`.

*   **Synchronization for access from multiple threads** ([System.Collections](http://dotnet.github.io/api/System.Collections) classes only).

    Non-generic collection types in the [System.Collections](http://dotnet.github.io/api/System.Collections) namespace provide some thread safety with synchronization; typically exposed through the `SyncRoot` and `IsSynchronized` members. These collections are not thread-safe by default. If you require scalable and efficient multi-threaded access to a collection, use one of the classes in the [System.Collections.Concurrent](http://dotnet.github.io/api/System.Collections.Concurrent.html) namespace or consider using an immutable collection. For more information, see [Thread-Safe Collections](thread-safeCollections.md).    
    
## Choosing a collection 

In general, you should use generic collections. The following table describes some common collection scenarios and the collection classes you can use for those scenarios. If you are new to generic collections, this table will help you choose the generic collection that works the best for your task.

I want to… | Generic collection option(s) | Non-generic collection option(s)
---------- | ---------------------------- | --------------------------------
Store items as key/value pairs for quick look-up by key | [System.Collections.Generic.Dictionary&lt;TKey, TValue&gt;](http://dotnet.github.io/api/System.Collections.Generic.Dictionary%602.html) | [Hashtable](http://dotnet.github.io/api/System.Collections.Hashtable.html) (A collection of key/value pairs that are organize based on the hash code of the key.)
Access items by index | [System.Collections.Generic.List&lt;T&gt;](http://dotnet.github.io/api/System.Collections.Generic.List%601.html) | [System.Array](http://dotnet.github.io/api/System.Array.html), [System.Collections.ArrayList](http://dotnet.github.io/api/System.Collections.ArrayList.html)
Use items first-in-first-out (FIFO) | [System.Collections.Generic.Queue&lt;T&gt;](http://dotnet.github.io/api/System.Collections.Generic.Queue%601.html) | [System.Collections.Queue](http://dotnet.github.io/api/System.Collections.Queue.html)
Use data Last-In-First-Out (LIFO) | [System.Collections.Generic.Stack&lt;T&gt;](http://dotnet.github.io/api/System.Collections.Generic.Stack%601.html) | [System.Collections.Stack](http://dotnet.github.io/api/System.Collections.Stack.html)
Access items sequentially | [System.Collections.Generic.LinkedList&lt;T&gt;](http://dotnet.github.io/api/System.Collections.Generic.LinkedList%601.html) | No recommendation
Receive notifications when items are removed or added to the collection. (implements [INotifyPropertyChanged](http://dotnet.github.io/api/System.ComponentModel.INotifyPropertyChanged.html) and [System.Collections.Specialized.INotifyCollectionChanged](http://dotnet.github.io/api/System.Collections.Specialized.INotifyCollectionChanged.html)) | [System.Collections.ObjectModel.ObservableCollection&lt;T&gt;](http://dotnet.github.io/api/System.Collections.ObjectModel.ObservableCollection%601.html) | No recommendation
Use a sorted collection | [System.Collections.Generic.SortedList&lt;TKey, TValue&gt;](http://dotnet.github.io/api/System.Collections.Generic.SortedList%602.html) | [System.Collections.SortedList](http://dotnet.github.io/api/System.Collections.SortedList.html)
Manage efficient storage and access of unique elements | [System.Collections.Generic.HashSet&lt;T&gt;](http://dotnet.github.io/api/System.Collections.Generic.HashSet%601.html), [System.Collections.Generic.SortedSet&lt;T&gt;](http://dotnet.github.io/api/System.Collections.Generic.SortedSet%601.html) | No recommendation

## Related Topics

Title | Description
----- | -----------
[Selecting a Collection Class](selectingaCollectionClass.md) | Describes the different collections and helps you select one for your scenario.
[Commonly Used Collection Types](commonlyUsedCollectionTypes.md) | Describes commonly used generic and nongeneric collection types such as [System.Array](http://dotnet.github.io/api/System.Array.html), [System.Collections.Generic.List&lt;T&gt;](http://dotnet.github.io/api/System.Collections.Generic.List%601.html), and [System.Collections.Generic.Dictionary&lt;TKey, TValue&gt;](http://dotnet.github.io/api/System.Collections.Generic.Dictionary%602.html). 
[When to Use Generic Collections](whentoUseGenericCollections.md) | Discusses the use of generic collection types.
[Comparisons and Sorts Within Collections](comparisonsandSortsWithinCollections.md) | Discusses the use of equality comparisons and sorting comparisons in collections.
[Sorted Collection Types](sortedCollectionTypes.md) | Describes sorted collections performance and characteristics.
[Hashtable and Dictionary Collection Types](hashtableandDictionaryCollectionTypes.md) | Describes the features of generic and non-generic hash-based dictionary types.
[Thread-Safe Collections](thread-safeCollections.md) | Describes collection types such as [System.Collections.Concurrent.BlockingCollection&lt;T&gt;](http://dotnet.github.io/api/System.Collections.Concurrent.BlockingCollection%601.html) and [System.Collections.Concurrent.ConcurrentBag&lt;T&gt;](http://dotnet.github.io/api/System.Collections.Concurrent.ConcurrentBag%601.html) that support safe and efficient concurrent access from multiple threads.

## Reference

[System.Array](http://dotnet.github.io/api/System.Array.html)

[System.Collections](http://dotnet.github.io/api/System.Collections.html)

[System.Collections.Concurrent](http://dotnet.github.io/api/System.Collections.Concurrent.html)

[System.Collections.Generic](http://dotnet.github.io/api/System.Collections.Generic.html)

[System.Collections.Specialized](http://dotnet.github.io/api/System.Collections.Specialized.html)

[System.Linq](http://dotnet.github.io/api/System.Linq.html)
  
