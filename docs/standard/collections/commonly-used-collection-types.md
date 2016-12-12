---
title: Commonly Used Collection Types
description: Commonly Used Collection Types
keywords: .NET, .NET Core
author: mairaw
ms.author: mairaw
ms.date: 06/20/2016
ms.topic: article
ms.prod: .net
ms.technology: dotnet-standard
ms.devlang: dotnet
ms.assetid: 55861611-1e40-4cc2-9ec5-0b2df4ba6c0c
---

# Commonly Used Collection Types

Collection types are the common variations of data collections, such as hash tables, queues, stacks, bags, dictionaries, and lists.

Collections are based on the [`ICollection`](https://docs.microsoft.com/dotnet/core/api/System.Collections.ICollection) interface, the [`IList`](https://docs.microsoft.com/dotnet/core/api/System.Collections.IList) interface, the [`IDictionary`](https://docs.microsoft.com/dotnet/core/api/System.Collections.IDictionary) interface, or their generic counterparts. The `IList` interface and the `IDictionary` interface are both derived from the `ICollection` interface; therefore, all collections are based on the `ICollection` interface either directly or indirectly. In collections based on the `IList` interface (such as [`Array`](https://docs.microsoft.com/dotnet/core/api/System.Array), [`ArrayList`](https://docs.microsoft.com/dotnet/core/api/System.Collections.ArrayList), or [`List<T>)`](https://docs.microsoft.com/dotnet/core/api/System.Collections.Generic.List-1) or directly on the `ICollection` interface (such as [`Queue`](https://docs.microsoft.com/dotnet/core/api/System.Collections.Queue), [`ConcurrentQueue<T>`](https://docs.microsoft.com/dotnet/core/api/System.Collections.Concurrent.ConcurrentQueue-1), [`Stack`](https://docs.microsoft.com/dotnet/core/api/System.Collections.Stack), [`ConcurrentStack<T>`](https://docs.microsoft.com/dotnet/core/api/System.Collections.Concurrent.ConcurrentStack-1) or [`LinkedList<T>`](https://docs.microsoft.com/dotnet/core/api/System.Collections.Generic.LinkedList-1)), every element contains only a value. In collections based on the `IDictionary` interface (such as the [`Hashtable`](https://docs.microsoft.com/dotnet/core/api/System.Collections.Hashtable) and [`SortedList`](https://docs.microsoft.com/dotnet/core/api/System.Collections.SortedList) classes, the [`Dictionary<TKey, TValue>`](https://docs.microsoft.com/dotnet/core/api/System.Collections.Generic.Dictionary-2) and [`SortedList<TKey, TValue>`](https://docs.microsoft.com/dotnet/core/api/System.Collections.Generic.SortedList-2) generic classes), or the [`ConcurrentDictionary<TKey, TValue>`](https://docs.microsoft.com/dotnet/core/api/System.Collections.Concurrent.ConcurrentDictionary-2) classes, every element contains both a key and a value. The [`KeyedCollection<TKey, TItem>`](https://docs.microsoft.com/dotnet/core/api/System.Collections.ObjectModel.KeyedCollection-2) class is unique because it is a list of values with keys embedded within the values and, therefore, it behaves like a list and like a dictionary.

Generic collections are the best solution to strong typing. However, if your language does not support generics, the [`System.Collections`](https://docs.microsoft.com/dotnet/core/api/System.Collections) namespace includes base collections, such as [`CollectionBase`](https://docs.microsoft.com/dotnet/core/api/System.Collections.CollectionBase), [`ReadOnlyCollectionBase`](https://docs.microsoft.com/dotnet/core/api/System.Collections.ReadOnlyCollectionBase), and [`DictionaryBase`](https://docs.microsoft.com/dotnet/core/api/System.Collections.DictionaryBase), which are abstract base classes that can be extended to create collection classes that are strongly typed. When efficient multi-threaded collection access is required, use the generic collections in the [`System.Collections.Concurrent`](https://docs.microsoft.com/dotnet/core/api/System.Collections.Concurrent) namespace.

Collections can vary, depending on how the elements are stored, how they are sorted, how searches are performed, and how comparisons are made. The [`Queue`](https://docs.microsoft.com/dotnet/core/api/System.Collections.Queue) class and the [`Queue<T>`](https://docs.microsoft.com/dotnet/core/api/System.Collections.Generic.Queue-1) generic class provide first-in-first-out lists, while the [`Stack`](https://docs.microsoft.com/dotnet/core/api/System.Collections.Stack) class and the [`Stack<T>`](https://docs.microsoft.com/dotnet/core/api/System.Collections.Generic.Stack-1) generic class provide last-in-first-out lists. The [`SortedList`](https://docs.microsoft.com/dotnet/core/api/System.Collections.SortedList) class and the [`SortedList<TKey, TValue>`](https://docs.microsoft.com/dotnet/core/api/System.Collections.Generic.SortedList-2) generic class provide sorted versions of the [`Hashtable`](https://docs.microsoft.com/dotnet/core/api/System.Collections.Hashtable) class and the [`Dictionary<TKey, TValue>`](https://docs.microsoft.com/dotnet/core/api/System.Collections.Generic.Dictionary-2) generic class. The elements of a `Hashtable` or a `Dictionary<TKey, TValue>` are accessible only by the key of the element, but the elements of a `SortedList` or a [`KeyedCollection<TKey, TItem>`](https://docs.microsoft.com/dotnet/core/api/System.Collections.ObjectModel.KeyedCollection-2) are accessible either by the key or by the index of the element. The indexes in all collections are zero-based, except [`Array`](https://docs.microsoft.com/dotnet/core/api/System.Array), which allows arrays that are not zero-based.

The LINQ to Objects feature allows you to use LINQ queries to access in-memory objects as long as the object type implements [`IEnumerable`](https://docs.microsoft.com/dotnet/core/api/System.Collections.IEnumerable) or [`IEnumerable<T>`](https://docs.microsoft.com/dotnet/core/api/System.Collections.Generic.IEnumerable-1). LINQ queries provide a common pattern for accessing data; are typically more concise and readable than standard foreach loops; and provide filtering, ordering and grouping capabilities. LINQ queries can also improve performance.

## Related Topics

Title | Description
----- | -----------
[`Collections and Data Structures`](index.md) | Discusses the various collection types available in the .NET Framework, including stacks, queues, lists, arrays, and dictionaries.
[`Hashtable and Dictionary Collection Types`](hashtable-and-dictionary-collection-types.md) | Describes the features of generic and non-generic hash-based dictionary types.
[`Sorted Collection Types`](sorted-collection-types.md) | Describes sorted collections performance and characteristics.

## Reference

[`System.Collections`](https://docs.microsoft.com/dotnet/core/api/System.Collections)

[`System.Collections.Generic`](https://docs.microsoft.com/dotnet/core/api/System.Collections.Generic)

[`System.Collections.ICollection`](https://docs.microsoft.com/dotnet/core/api/System.Collections.ICollection)

[`System.Collections.Generic.ICollection<T>`](https://docs.microsoft.com/dotnet/core/api/System.Collections.Generic.ICollection-1)

[`System.Collections.IList`](https://docs.microsoft.com/dotnet/core/api/System.Collections.IList)

[`System.Collections.Generic.IList<T>`](https://docs.microsoft.com/dotnet/core/api/System.Collections.Generic.IList-1)

[`System.Collections.IDictionary`](https://docs.microsoft.com/dotnet/core/api/System.Collections.IDictionary)

[`System.Collections.Generic.IDictionary<TKey, TValue>`](https://docs.microsoft.com/dotnet/core/api/System.Collections.Generic.IDictionary-2)

[`System.Linq`](https://docs.microsoft.com/dotnet/core/api/System.Linq)
