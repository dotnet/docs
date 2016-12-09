---
title: When to Use Generic Collections
description: When to Use Generic Collections
keywords: .NET, .NET Core
author: mairaw
ms.author: mairaw
ms.date: 06/20/2016
ms.topic: article
ms.prod: .net
ms.technology: dotnet-standard
ms.devlang: dotnet
ms.assetid: 971e08bd-b63f-4832-9e61-9f65cbedd352
---

# When to Use Generic Collections

Using generic collections is generally recommended, because you gain the immediate benefit of type safety without having to derive from a base collection type and implement type-specific members. Generic collection types also generally perform better than the corresponding nongeneric collection types (and better than types that are derived from nongeneric base collection types) when the collection elements are value types, because with generics there is no need to box the elements. 

You should use the generic collection classes in the [System.Collections.Concurrent](https://docs.microsoft.com/dotnet/core/api/System.Collections.Concurrent) namespace when multiple threads might be adding or removing items from the collection concurrently.

The following generic types correspond to existing collection types: 

*   [List&lt;T&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Generic.List-1) is the generic class that corresponds to [ArrayList](https://docs.microsoft.com/dotnet/core/api/System.Collections.ArrayList).

*   [Dictionary&lt;TKey, TValue&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Generic.Dictionary-2) and [ConcurrentDictionary&lt;TKey, TValue&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Concurrent.ConcurrentDictionary-2) are the generic classes that correspond to [Hashtable](https://docs.microsoft.com/dotnet/core/api/System.Collections.Hashtable). 

*   [Collection&lt;T&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.ObjectModel.Collection-1) is the generic class that corresponds to [CollectionBase](https://docs.microsoft.com/dotnet/core/api/System.Collections.CollectionBase). `Collection<T>` can be used as a base class, but unlike `CollectionBase`, it is not abstract. This makes it much easier to use.

*   [ReadOnlyCollection&lt;T&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.ObjectModel.ReadOnlyCollection-1) is the generic class that corresponds to [ReadOnlyCollectionBase](https://docs.microsoft.com/dotnet/core/api/System.Collections.ReadOnlyCollectionBase). `ReadOnlyCollection<T>` is not abstract, and has a constructor that makes it easy to expose an existing [List&lt;T&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Generic.List-1) as a read-only collection.

*   The [Queue&lt;T&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Generic.Queue-1), [ConcurrentQueue&lt;T&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Concurrent.ConcurrentQueue-1), [Stack&lt;T&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Generic.Stack-1), [ConcurrentStack&lt;T&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Concurrent.ConcurrentStack-1), and [SortedList&lt;TKey, TValue&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Generic.SortedList-2) generic classes correspond to the respective nongeneric classes with the same names.

## Additional Types

Several generic collection types do not have nongeneric counterparts. They include the following: 

*   [LinkedList&lt;T&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Generic.LinkedList-1) is a general-purpose linked list that provides O(1) insertion and removal operations.

*   [SortedDictionary&lt;TKey, TValue&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Generic.SortedDictionary-2) is a sorted dictionary with O(log n) insertion and retrieval operations, which makes it a useful alternative to [SortedList&lt;TKey, TValue&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Generic.SortedList-2). 

*   [KeyedCollection&lt;TKey, TItem&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.ObjectModel.KeyedCollection-2) is a hybrid between a list and a dictionary, which provides a way to store objects that contain their own keys.

*   [BlockingCollection&lt;T&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Concurrent.BlockingCollection-1) implements a collection class with bounding and blocking functionality.

*   [ConcurrentBag&lt;T&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Concurrent.ConcurrentBag-1) provides fast insertion and removal of unordered elements.

## LINQ to Objects

The LINQ to Objects feature enables you to use LINQ queries to access in-memory objects as long as the object type implements the [System.Collections.IEnumerable](https://docs.microsoft.com/dotnet/core/api/System.Collections.IEnumerable) or [System.Collections.Generic.IEnumerable&lt;T&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Generic.IEnumerable-1) interface. LINQ queries provide a common pattern for accessing data; are typically more concise and readable than standard `foreach` loops; and provide filtering, ordering and grouping capabilities. LINQ queries can also improve performance.

## Additional Functionality

Some of the generic types have functionality that is not found in the nongeneric collection types. For example, the [List&lt;T&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Generic.List-1) class, which corresponds to the nongeneric [ArrayList](https://docs.microsoft.com/dotnet/core/api/System.Collections.ArrayList) class, has a number of methods that accept generic delegates, such as the [Predicate&lt;T&gt;](https://docs.microsoft.com/dotnet/core/api/System.Predicate-1) delegate that allows you to specify methods for searching the list, and the [Action&lt;T&gt;](https://docs.microsoft.com/dotnet/core/api/System.Action-1) delegate that represents methods that act on each element of the list.

The [List&lt;T&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Generic.List-1) class allows you to specify your own [IComparer&lt;T&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Generic.IComparer-1) generic interface implementations for sorting and searching the list. The [SortedDictionary&lt;TKey, TValue&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Generic.SortedDictionary-2) and [SortedList&lt;TKey, TValue&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Generic.SortedList-2) classes also have this capability. In addition, these classes let you specify comparers when the collection is created. In similar fashion, the [Dictionary&lt;TKey, TValue&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Generic.Dictionary-2) and [KeyedCollection&lt;TKey, TItem&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.ObjectModel.KeyedCollection-2) classes let you specify your own equality comparers.

## See Also

[Collections and Data Structures](index.md) 

[Commonly Used Collection Types](commonly-used-collection-types.md)
