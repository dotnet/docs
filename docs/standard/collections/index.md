---
title: Collections and Data Structures
description: Collections and Data Structures
keywords: .NET, .NET Core
author: mairaw
ms.author: mairaw
ms.date: 06/20/2016
ms.topic: article
ms.prod: .net
ms.technology: dotnet-standard
ms.devlang: dotnet
ms.assetid: 9e70255a-c02a-4046-86b7-10c84bab2d38
---

# Collections and Data Structures

Similar data can often be handled more efficiently when stored and manipulated as a collection. You can use the [System.Array](https://docs.microsoft.com/dotnet/core/api/System.Array) class or the classes in the [System.Collections](https://docs.microsoft.com/dotnet/core/api/System.Collections), [System.Collections.Generic](https://docs.microsoft.com/dotnet/core/api/System.Collections.Generic), or [System.Collections.Concurrent](https://docs.microsoft.com/dotnet/core/api/System.Collections.Concurrent) namespaces to add, remove, and modify either individual elements or a range of elements in a collection.

There are two main types of collections; generic collections and non-generic collections. Generic collections are type-safe at compile time. Because of this, generic collections typically offer better performance. Generic collections accept a type parameter when they are constructed and do not require that you cast to and from the [Object](https://docs.microsoft.com/dotnet/core/api/System.Object) type when you add or remove items from the collection. Non-generic collections store items as [Object](https://docs.microsoft.com/dotnet/core/api/System.Object) and require casting. You may see non-generic collections in older code.

The collections in the [System.Collections.Concurrent](https://docs.microsoft.com/dotnet/core/api/System.Collections.Concurrent) namespace provide efficient thread-safe operations for accessing collection items from multiple threads.

## Common collection features

All collections provide methods for adding, removing or finding items in the collection. In addition, all collections that directly or indirectly implement the [ICollection](https://docs.microsoft.com/dotnet/core/api/System.Collections.ICollection) interface or the [ICollection&lt;T&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Generic.ICollection-1) interface share these features: 

* **The ability to enumerate the collection**

   .NET Framework collections either implement [System.Collections.IEnumerable](https://docs.microsoft.com/dotnet/core/api/System.Collections.IEnumerable) or [System.Collections.Generic.IEnumerable&lt;T&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Generic.IEnumerable-1) to enable the collection to be iterated through. An enumerator can be thought of as a movable pointer to any element in the collection. The `foreach, in` statement (C#) uses the enumerator exposed by the `GetEnumerator` method and hides the complexity of manipulating the enumerator. In addition, any collection that implements [System.Collections.Generic.IEnumerable&lt;T&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Generic.IEnumerable-1) is considered a queryable type and can be queried with LINQ. LINQ queries provide a common pattern for accessing data. They are typically more concise and readable than standard for each loops, and provide filtering, ordering and grouping capabilities. LINQ queries can also improve performance.
    
* **The ability to copy the collection contents to an array**

   All collections can be copied to an array using the `CopyTo` method; however, the order of the elements in the new array is based on the sequence in which the enumerator returns them. The resulting array is always one-dimensional with a lower bound of zero.
    
In addition, many collection classes contain the following features:

* **Capacity and Count properties**

   The capacity of a collection is the number of elements it can contain. The count of a collection is the number of elements it actually contains. Some collections hide the capacity or the count or both.
    
   Most collections automatically expand in capacity when the current capacity is reached. The memory is reallocated, and the elements are copied from the old collection to the new one. This reduces the code required to use the collection; however, the performance of the collection might be negatively affected. For example, for [List&lt;T&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Generic.List-1), if `Count` is less than `Capacity`, adding an item is an O(1) operation. If the capacity needs to be increased to accommodate the new element, adding an item becomes an O(n) operation, where n is `Count`. The best way to avoid poor performance caused by multiple reallocations is to set the initial capacity to be the estimated size of the collection. 
    
   A [BitArray](https://docs.microsoft.com/dotnet/core/api/System.Collections.BitArray) is a special case; its capacity is the same as its length, which is the same as its count.
    
*   **A consistent lower bound**

   The lower bound of a collection is the index of its first element. All indexed collections in the [System.Collections](https://docs.microsoft.com/dotnet/core/api/System.Collections) namespaces have a lower bound of zero, meaning they are 0-indexed. [Array](https://docs.microsoft.com/dotnet/core/api/System.Array) has a lower bound of zero by default, but a different lower bound can be defined when creating an instance of the `Array` class using `Array.CreateInstance`.

*   **Synchronization for access from multiple threads** ([System.Collections](https://docs.microsoft.com/dotnet/core/api/System.Collections) classes only).

   Non-generic collection types in the [System.Collections](https://docs.microsoft.com/dotnet/core/api/System.Collections) namespace provide some thread safety with synchronization; typically exposed through the `SyncRoot` and `IsSynchronized` members. These collections are not thread-safe by default. If you require scalable and efficient multi-threaded access to a collection, use one of the classes in the [System.Collections.Concurrent](https://docs.microsoft.com/dotnet/core/api/System.Collections.Concurrent) namespace or consider using an immutable collection. For more information, see [Thread-Safe Collections](threadsafe/index.md).    
    
## Choosing a collection 

In general, you should use generic collections. The following table describes some common collection scenarios and the collection classes you can use for those scenarios. If you are new to generic collections, this table will help you choose the generic collection that works the best for your task.

I want to… | Generic collection option(s) | Non-generic collection option(s)
---------- | ---------------------------- | --------------------------------
Store items as key/value pairs for quick look-up by key | [System.Collections.Generic.Dictionary&lt;TKey, TValue&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Generic.Dictionary-2) | [Hashtable](https://docs.microsoft.com/dotnet/core/api/System.Collections.Hashtable)
Access items by index | [System.Collections.Generic.List&lt;T&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Generic.List-1) | [System.Array](https://docs.microsoft.com/dotnet/core/api/System.Array), [System.Collections.ArrayList](https://docs.microsoft.com/dotnet/core/api/System.Collections.ArrayList)
Use items first-in-first-out (FIFO) | [System.Collections.Generic.Queue&lt;T&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Generic.Queue-1) | [System.Collections.Queue](https://docs.microsoft.com/dotnet/core/api/System.Collections.Queue)
Use data Last-In-First-Out (LIFO) | [System.Collections.Generic.Stack&lt;T&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Generic.Stack-1) | [System.Collections.Stack](https://docs.microsoft.com/dotnet/core/api/System.Collections.Stack)
Access items sequentially | [System.Collections.Generic.LinkedList&lt;T&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Generic.LinkedList-1) | No recommendation
Receive notifications when items are removed or added to the collection. (implements [INotifyPropertyChanged](https://docs.microsoft.com/dotnet/core/api/System.ComponentModel.INotifyPropertyChanged) and [INotifyCollectionChanged](https://docs.microsoft.com/dotnet/core/api/System.Collections.Specialized.INotifyCollectionChanged)) | [System.Collections.ObjectModel.ObservableCollection&lt;T&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.ObjectModel.ObservableCollection-1) | No recommendation
Use a sorted collection | [System.Collections.Generic.SortedList&lt;TKey, TValue&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Generic.SortedList-2) | [System.Collections.SortedList](https://docs.microsoft.com/dotnet/core/api/System.Collections.SortedList)
Manage efficient storage and access of unique elements | [System.Collections.Generic.HashSet&lt;T&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Generic.HashSet-1), [System.Collections.Generic.SortedSet&lt;T&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Generic.SortedSet-1) | No recommendation

## Related Topics

Title | Description
----- | -----------
[Selecting a Collection Class](selecting-a-collection-class.md) | Describes the different collections and helps you select one for your scenario.
[Commonly Used Collection Types](commonly-used-collection-types.md) | Describes commonly used generic and nongeneric collection types such as [System.Array](https://docs.microsoft.com/dotnet/core/api/System.Array), [System.Collections.Generic.List&lt;T&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Generic.List-1), and [System.Collections.Generic.Dictionary&lt;TKey, TValue&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Generic.Dictionary-2). 
[When to Use Generic Collections](when-to-use-generic-collections.md) | Discusses the use of generic collection types.
[Comparisons and Sorts Within Collections](comparisons-and-sorts-within-collections.md) | Discusses the use of equality comparisons and sorting comparisons in collections.
[Sorted Collection Types](sorted-collection-types.md) | Describes sorted collections performance and characteristics.
[Hashtable and Dictionary Collection Types](hashtable-and-dictionary-collection-types.md) | Describes the features of generic and non-generic hash-based dictionary types.
[Thread-Safe Collections](threadsafe/index.md) | Describes collection types such as [System.Collections.Concurrent.BlockingCollection&lt;T&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Concurrent.BlockingCollection-1) and [System.Collections.Concurrent.ConcurrentBag&lt;T&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Concurrent.ConcurrentBag-1) that support safe and efficient concurrent access from multiple threads.

## Reference

[System.Array](https://docs.microsoft.com/dotnet/core/api/System.Array)

[System.Collections](https://docs.microsoft.com/dotnet/core/api/System.Collections)

[System.Collections.Concurrent](https://docs.microsoft.com/dotnet/core/api/System.Collections.Concurrent)

[System.Collections.Generic](https://docs.microsoft.com/dotnet/core/api/System.Collections.Generic)

[System.Collections.Specialized](https://docs.microsoft.com/dotnet/core/api/System.Collections.Specialized)

[System.Linq](https://docs.microsoft.com/dotnet/core/api/System.Linq)
  
