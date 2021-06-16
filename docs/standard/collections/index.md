---
title: "Collections and Data Structures"
description: Learn how to use collections and data structures in .NET. Use generic and non-generic collections in thread-safe operations.
ms.date: 04/30/2020
helpviewer_keywords: 
  - "grouping data in collections"
  - "objects [.NET], grouping in collections"
  - "Array class, grouping data in collections"
  - "threading [.NET], safety"
  - "Collections classes"
  - "collections [.NET]"
ms.assetid: 60cc581f-1db5-445b-ba04-a173396bf872
---

# Collections and Data Structures

Similar data can often be handled more efficiently when stored and manipulated as a collection. You can use the <xref:System.Array?displayProperty=nameWithType> class or the classes in the <xref:System.Collections>, <xref:System.Collections.Generic>, <xref:System.Collections.Concurrent>, and <xref:System.Collections.Immutable> namespaces to add, remove, and modify either individual elements or a range of elements in a collection.

There are two main types of collections; generic collections and non-generic collections. Generic collections are type-safe at compile time. Because of this, generic collections typically offer better performance. Generic collections accept a type parameter when they are constructed and do not require that you cast to and from the <xref:System.Object> type when you add or remove items from the collection.  In addition, most generic collections are supported in Windows Store apps. Non-generic collections store items as <xref:System.Object>, require casting, and most are not supported for Windows Store app development. However, you may see non-generic collections in older code.

Starting with .NET Framework 4, the collections in the <xref:System.Collections.Concurrent> namespace provide efficient thread-safe operations for accessing collection items from multiple threads. The immutable collection classes in the <xref:System.Collections.Immutable> namespace ([NuGet package](https://www.nuget.org/packages/System.Collections.Immutable)) are inherently thread-safe because operations are performed on a copy of the original collection and the original collection cannot be modified.

<a name="BKMK_Commoncollectionfeatures"></a>

## Common collection features

All collections provide methods for adding, removing, or finding items in the collection. In addition, all collections that directly or indirectly implement the <xref:System.Collections.ICollection> interface or the <xref:System.Collections.Generic.ICollection%601> interface share these features:

- **The ability to enumerate the collection**

    .NET collections either implement <xref:System.Collections.IEnumerable?displayProperty=nameWithType> or <xref:System.Collections.Generic.IEnumerable%601?displayProperty=nameWithType> to enable the collection to be iterated through. An enumerator can be thought of as a movable pointer to any element in the collection. The [foreach, in](../../csharp/language-reference/statements/iteration-statements.md#the-foreach-statement) statement  and the [For Each...Next Statement](../../visual-basic/language-reference/statements/for-each-next-statement.md) use the enumerator exposed by the <xref:System.Collections.IEnumerable.GetEnumerator%2A> method and hide the complexity of manipulating the enumerator. In addition, any collection that implements <xref:System.Collections.Generic.IEnumerable%601?displayProperty=nameWithType> is considered a *queryable type* and can be queried with LINQ. LINQ queries provide a common pattern for accessing data. They are typically more concise and readable than standard `foreach` loops, and provide filtering, ordering and grouping capabilities. LINQ queries can also improve performance. For more information, see [LINQ to Objects (C#)](../../csharp/programming-guide/concepts/linq/linq-to-objects.md), [LINQ to Objects (Visual Basic)](../../visual-basic/programming-guide/concepts/linq/linq-to-objects.md), [Parallel LINQ (PLINQ)](../parallel-programming/introduction-to-plinq.md), [Introduction to LINQ Queries (C#)](../../csharp/programming-guide/concepts/linq/introduction-to-linq-queries.md), and [Basic Query Operations (Visual Basic)](../../visual-basic/programming-guide/concepts/linq/basic-query-operations.md).

- **The ability to copy the collection contents to an array**

    All collections can be copied to an array using the **CopyTo** method; however, the order of the elements in the new array is based on the sequence in which the enumerator returns them. The resulting array is always one-dimensional with a lower bound of zero.

In addition, many collection classes contain the following features:

- **Capacity and Count properties**

    The capacity of a collection is the number of elements it can contain. The count of a collection is the number of elements it actually contains. Some collections hide the capacity or the count or both.

    Most collections automatically expand in capacity when the current capacity is reached. The memory is reallocated, and the elements are copied from the old collection to the new one. This reduces the code required to use the collection; however, the performance of the collection might be negatively affected. For example, for <xref:System.Collections.Generic.List%601>, if <xref:System.Collections.Generic.List%601.Count%2A> is less than <xref:System.Collections.Generic.List%601.Capacity%2A>, adding an item is an O(1) operation. If the capacity needs to be increased to accommodate the new element, adding an item becomes an O(`n`) operation, where `n` is <xref:System.Collections.Generic.List%601.Count%2A>. The best way to avoid poor performance caused by multiple reallocations is to set the initial capacity to be the estimated size of the collection.

    A <xref:System.Collections.BitArray> is a special case; its capacity is the same as its length, which is the same as its count.

- **A consistent lower bound**

    The lower bound of a collection is the index of its first element. All indexed collections in the <xref:System.Collections> namespaces have a lower bound of zero, meaning they are 0-indexed. <xref:System.Array> has a lower bound of zero by default, but a different lower bound can be defined when creating an instance of the **Array** class using <xref:System.Array.CreateInstance%2A?displayProperty=nameWithType>.

- **Synchronization for access from multiple threads** (<xref:System.Collections> classes only).

    Non-generic collection types in the <xref:System.Collections> namespace provide some thread safety with synchronization; typically exposed through the <xref:System.Collections.ICollection.SyncRoot%2A> and  <xref:System.Collections.ICollection.IsSynchronized%2A> members. These collections are not thread-safe by default. If you require scalable and efficient multi-threaded access to a collection, use one of the classes in the <xref:System.Collections.Concurrent> namespace or consider using an immutable collection. For more information, see [Thread-Safe Collections](thread-safe/index.md).

<a name="BKMK_Choosingacollection"></a>

## Choose a collection

In general, you should use generic collections. The following table describes some common collection scenarios and the collection classes you can use for those scenarios. If you are new to generic collections, this table will help you choose the generic collection that works the best for your task.

|I want to…|Generic collection options|Non-generic collection options|Thread-safe or immutable collection options|
|-|-|-|-|
|Store items as key/value pairs for quick look-up by key|<xref:System.Collections.Generic.Dictionary%602>|<xref:System.Collections.Hashtable><br /><br /> (A collection of key/value pairs that are organized based on the hash code of the key.)|<xref:System.Collections.Concurrent.ConcurrentDictionary%602><br /><br /> <xref:System.Collections.ObjectModel.ReadOnlyDictionary%602><br /><br /> <xref:System.Collections.Immutable.ImmutableDictionary%602>|
|Access items by index|<xref:System.Collections.Generic.List%601>|<xref:System.Array><br /><br /> <xref:System.Collections.ArrayList>|<xref:System.Collections.Immutable.ImmutableList%601><br /><br /> <xref:System.Collections.Immutable.ImmutableArray>|
|Use items first-in-first-out (FIFO)|<xref:System.Collections.Generic.Queue%601>|<xref:System.Collections.Queue>|<xref:System.Collections.Concurrent.ConcurrentQueue%601><br /><br /> <xref:System.Collections.Immutable.ImmutableQueue%601>|
|Use data Last-In-First-Out (LIFO)|<xref:System.Collections.Generic.Stack%601>|<xref:System.Collections.Stack>|<xref:System.Collections.Concurrent.ConcurrentStack%601><br /><br /> <xref:System.Collections.Immutable.ImmutableStack%601>|
|Access items sequentially|<xref:System.Collections.Generic.LinkedList%601>|No recommendation|No recommendation|
|Receive notifications when items are removed or added to the collection. (implements <xref:System.ComponentModel.INotifyPropertyChanged> and <xref:System.Collections.Specialized.INotifyCollectionChanged>)|<xref:System.Collections.ObjectModel.ObservableCollection%601>|No recommendation|No recommendation|
|A sorted collection|<xref:System.Collections.Generic.SortedList%602>|<xref:System.Collections.SortedList>|<xref:System.Collections.Immutable.ImmutableSortedDictionary%602><br /><br /> <xref:System.Collections.Immutable.ImmutableSortedSet%601>|
|A set for mathematical functions|<xref:System.Collections.Generic.HashSet%601><br /><br /> <xref:System.Collections.Generic.SortedSet%601>|No recommendation|<xref:System.Collections.Immutable.ImmutableHashSet%601><br /><br /> <xref:System.Collections.Immutable.ImmutableSortedSet%601>|

### Algorithmic complexity of collections

When choosing a [collection class](selecting-a-collection-class.md), it is worth considering potential tradeoffs in performance. Use the following table to reference how various mutable collection types compare in algorithmic complexity to their corresponding immutable counterparts. Often immutable collection types are less performant but provide immutability - which is often a valid comparative benefit.

| Mutable                   | Amortized  | Worst Case                | Immutable                          | Complexity |
|---------------------------|------------|---------------------------|------------------------------------|------------|
| `Stack<T>.Push`           | O(1)       | O(`n`)                    | `ImmutableStack<T>.Push`           | O(1)       |
| `Queue<T>.Enqueue`        | O(1)       | O(`n`)                    | `ImmutableQueue<T>.Enqueue`        | O(1)       |
| `List<T>.Add`             | O(1)       | O(`n`)                    | `ImmutableList<T>.Add`             | O(log `n`) |
| `List<T>.Item[Int32]`     | O(1)       | O(1)                      | `ImmutableList<T>.Item[Int32]`     | O(log `n`) |
| `List<T>.Enumerator`      | O(`n`)     | O(`n`)                    | `ImmutableList<T>.Enumerator`      | O(`n`)     |
| `HashSet<T>.Add`, lookup  | O(1)       | O(`n`)                    | `ImmutableHashSet<T>.Add`          | O(log `n`) |
| `SortedSet<T>.Add`        | O(log `n`) | O(`n`)                    | `ImmutableSortedSet<T>.Add`        | O(log `n`) |
| `Dictionary<T>.Add`       | O(1)       | O(`n`)                    | `ImmutableDictionary<T>.Add`       | O(log `n`) |
| `Dictionary<T>` lookup    | O(1)       | O(1) – or strictly O(`n`) | `ImmutableDictionary<T>` lookup    | O(log `n`) |
| `SortedDictionary<T>.Add` | O(log `n`) | O(`n` log `n`)            | `ImmutableSortedDictionary<T>.Add` | O(log `n`) |

A `List<T>` can be efficiently enumerated using either a `for` loop or a `foreach` loop. An `ImmutableList<T>`, however, does a poor job inside a `for` loop, due to the O(log `n`) time for its indexer. Enumerating an `ImmutableList<T>` using a `foreach` loop is efficient because `ImmutableList<T>` uses a binary tree to store its data instead of a simple array like `List<T>` uses. An array can be very quickly indexed into, whereas a binary tree must be walked down until the node with the desired index is found.

Additionally, `SortedSet<T>` has the same complexity as `ImmutableSortedSet<T>`. That's because they both use binary trees. The significant difference, of course, is that `ImmutableSortedSet<T>` uses an immutable binary tree. Since `ImmutableSortedSet<T>` also offers a <xref:System.Collections.Immutable.ImmutableSortedSet%601.Builder?displayProperty=nameWithType> class that allows mutation, you can have both immutability and performance.

<a name="BKMK_RelatedTopics"></a>

## Related Topics

|Title|Description|
|-----------|-----------------|
|[Selecting a Collection Class](selecting-a-collection-class.md)|Describes the different collections and helps you select one for your scenario.|
|[Commonly Used Collection Types](commonly-used-collection-types.md)|Describes commonly used generic and nongeneric collection types such as <xref:System.Array?displayProperty=nameWithType>, <xref:System.Collections.Generic.List%601?displayProperty=nameWithType>, and <xref:System.Collections.Generic.Dictionary%602?displayProperty=nameWithType>.|
|[When to Use Generic Collections](when-to-use-generic-collections.md)|Discusses the use of generic collection types.|
|[Comparisons and Sorts Within Collections](comparisons-and-sorts-within-collections.md)|Discusses the use of equality comparisons and sorting comparisons in collections.|
|[Sorted Collection Types](sorted-collection-types.md)|Describes sorted collections performance and characteristics|
|[Hashtable and Dictionary Collection Types](hashtable-and-dictionary-collection-types.md)|Describes the features of generic and non-generic hash-based dictionary types.|
|[Thread-Safe Collections](thread-safe/index.md)|Describes collection types such as <xref:System.Collections.Concurrent.BlockingCollection%601?displayProperty=nameWithType> and <xref:System.Collections.Concurrent.ConcurrentBag%601?displayProperty=nameWithType> that support safe and efficient concurrent access from multiple threads.|
|System.Collections.Immutable|Introduces the immutable collections and provides links to the collection types.|

<a name="BKMK_Reference"></a>

## Reference

<xref:System.Array?displayProperty=nameWithType>
<xref:System.Collections?displayProperty=nameWithType>
<xref:System.Collections.Concurrent?displayProperty=nameWithType>
<xref:System.Collections.Generic?displayProperty=nameWithType>
<xref:System.Collections.Specialized?displayProperty=nameWithType>
<xref:System.Linq?displayProperty=nameWithType>
<xref:System.Collections.Immutable>
