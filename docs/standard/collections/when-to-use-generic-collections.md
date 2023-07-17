---
description: "Learn more about: When to use generic collections"
title: "When to Use Generic Collections"
ms.date: 04/30/2020
helpviewer_keywords: 
  - "collections [.NET], generic"
  - "generic collections [.NET]"
ms.assetid: e7b868b1-11fe-4ac5-bed3-de68aca47739
---

# When to use generic collections

Using generic collections gives you the automatic benefit of type safety without having to derive from a base collection type and implement type-specific members. Generic collection types also generally perform better than the corresponding nongeneric collection types (and better than types that are derived from nongeneric base collection types) when the collection elements are value types, because with generics, there's no need to box the elements.

For programs that target .NET Standard 1.0 or later, use the generic collection classes in the <xref:System.Collections.Concurrent> namespace when multiple threads might be adding or removing items from the collection concurrently. Additionally, when immutability is desired, consider the generic collection classes in the <xref:System.Collections.Immutable> namespace.

The following generic types correspond to existing collection types:

- <xref:System.Collections.Generic.List%601> is the generic class that corresponds to <xref:System.Collections.ArrayList>.

- <xref:System.Collections.Generic.Dictionary%602> and <xref:System.Collections.Concurrent.ConcurrentDictionary%602> are the generic classes that correspond to <xref:System.Collections.Hashtable>.

- <xref:System.Collections.ObjectModel.Collection%601> is the generic class that corresponds to <xref:System.Collections.CollectionBase>. <xref:System.Collections.ObjectModel.Collection%601> can be used as a base class, but unlike <xref:System.Collections.CollectionBase>, it is not abstract, which makes it much easier to use.

- <xref:System.Collections.ObjectModel.ReadOnlyCollection%601> is the generic class that corresponds to <xref:System.Collections.ReadOnlyCollectionBase>. <xref:System.Collections.ObjectModel.ReadOnlyCollection%601> is not abstract and has a constructor that makes it easy to expose an existing <xref:System.Collections.Generic.List%601> as a read-only collection.

- The <xref:System.Collections.Generic.Queue%601>, <xref:System.Collections.Concurrent.ConcurrentQueue%601>, <xref:System.Collections.Immutable.ImmutableQueue%601>, <xref:System.Collections.Immutable.ImmutableArray%601>, <xref:System.Collections.Generic.SortedList%602>, and <xref:System.Collections.Immutable.ImmutableSortedSet%601> generic classes correspond to the respective nongeneric classes with the same names.

## Additional Types

Several generic collection types do not have nongeneric counterparts. They include the following:

- <xref:System.Collections.Generic.LinkedList%601> is a general-purpose linked list that provides O(1) insertion and removal operations.

- <xref:System.Collections.Generic.SortedDictionary%602> is a sorted dictionary with O(log `n`) insertion and retrieval operations, which makes it a useful alternative to <xref:System.Collections.Generic.SortedList%602>.

- <xref:System.Collections.ObjectModel.KeyedCollection%602> is a hybrid between a list and a dictionary, which provides a way to store objects that contain their own keys.

- <xref:System.Collections.Concurrent.BlockingCollection%601> implements a collection class with bounding and blocking functionality.

- <xref:System.Collections.Concurrent.ConcurrentBag%601> provides fast insertion and removal of unordered elements.

### Immutable builders

When you desire immutability functionality in your app, the <xref:System.Collections.Immutable> namespace offers generic collection types you can use. All of the immutable collection types offer `Builder` classes that can optimize performance when you're performing multiple mutations. The `Builder` class batches operations in a mutable state. When all mutations have been completed, call the `ToImmutable` method to "freeze" all nodes and create an immutable generic collection, for example, an <xref:System.Collections.Immutable.ImmutableList%601>.

The `Builder` object can be created by calling the nongeneric `CreateBuilder()` method. From a `Builder` instance, you can call `ToImmutable()`. Likewise, from the `Immutable*` collection, you can call `ToBuilder()` to create a builder instance from the generic immutable collection. The following are the various `Builder` types.

- <xref:System.Collections.Immutable.ImmutableArray%601.Builder>
- <xref:System.Collections.Immutable.ImmutableDictionary%602.Builder>
- <xref:System.Collections.Immutable.ImmutableHashSet%601.Builder>
- <xref:System.Collections.Immutable.ImmutableList%601.Builder>
- <xref:System.Collections.Immutable.ImmutableSortedDictionary%602.Builder>
- <xref:System.Collections.Immutable.ImmutableSortedSet%601.Builder>

## LINQ to Objects

The LINQ to Objects feature enables you to use LINQ queries to access in-memory objects as long as the object type implements the <xref:System.Collections.IEnumerable?displayProperty=nameWithType> or <xref:System.Collections.Generic.IEnumerable%601?displayProperty=nameWithType> interface. LINQ queries provide a common pattern for accessing data; are typically more concise and readable than standard `foreach` loops; and provide filtering, ordering, and grouping capabilities. LINQ queries can also improve performance. For more information, see [LINQ to Objects (C#)](../../csharp/linq/query-a-collection-of-objects.md), [LINQ to Objects (Visual Basic)](../../visual-basic/programming-guide/concepts/linq/linq-to-objects.md), and [Parallel LINQ (PLINQ)](../parallel-programming/introduction-to-plinq.md).

## Additional Functionality

Some of the generic types have functionality that is not found in the nongeneric collection types. For example, the <xref:System.Collections.Generic.List%601> class, which corresponds to the nongeneric <xref:System.Collections.ArrayList> class, has a number of methods that accept generic delegates, such as the <xref:System.Predicate%601> delegate that allows you to specify methods for searching the list, the <xref:System.Action%601> delegate that represents methods that act on each element of the list, and the <xref:System.Converter%602> delegate that lets you define conversions between types.

The <xref:System.Collections.Generic.List%601> class allows you to specify your own <xref:System.Collections.Generic.IComparer%601> generic interface implementations for sorting and searching the list. The <xref:System.Collections.Generic.SortedDictionary%602> and <xref:System.Collections.Generic.SortedList%602> classes also have this capability. In addition, these classes let you specify comparers when the collection is created. In similar fashion, the <xref:System.Collections.Generic.Dictionary%602> and <xref:System.Collections.ObjectModel.KeyedCollection%602> classes let you specify your own equality comparers.

## See also

- [Collections and Data Structures](index.md)
- [Commonly Used Collection Types](commonly-used-collection-types.md)
- [Generics](../generics/index.md)
