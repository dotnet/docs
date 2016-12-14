---
title: Sorted Collection Types  
description: Sorted Collection Types  
keywords: .NET, .NET Core
author: mairaw
ms.author: mairaw
ms.date: 06/20/2016
ms.topic: article
ms.prod: .net
ms.technology: dotnet-standard
ms.devlang: dotnet
ms.assetid: bdc9c13e-e56a-433b-a293-c92364f6e9cb
---

# Sorted Collection Types  
 
 The [System.Collections.SortedList](https://docs.microsoft.com/dotnet/core/api/System.Collections.SortedList) class, the [System.Collections.Generic.SortedList&lt;TKey, TValue&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Generic.SortedList-2) generic class, and the [System.Collections.Generic.SortedDictionary&lt;TKey, TValue&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Generic.SortedDictionary-2) generic class are similar to the [Hashtable](https://docs.microsoft.com/dotnet/core/api/System.Collections.Hashtable) class and the [Dictionary&lt;TKey, TValue&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Generic.Dictionary-2) generic class in that they implement the [IDictionary](https://docs.microsoft.com/dotnet/core/api/System.Collections.IDictionary) interface, but they maintain their elements in sort order by key, and they do not have the O(1) insertion and retrieval characteristic of hash tables. The three classes have several features in common:  

 *   All three classes implement the [System.Collections.IDictionary](https://docs.microsoft.com/dotnet/core/api/System.Collections.IDictionary) interface. The two generic classes also implement the [System.Collections.Generic.IDictionary&lt;TKey, TValue&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Generic.IDictionary-2) generic interface.  
 
 *   Each element is a key/value pair for enumeration purposes.   
  
> [!NOTE]  
> The nongeneric [SortedList](https://docs.microsoft.com/dotnet/core/api/System.Collections.SortedList) class returns [DictionaryEntry](https://docs.microsoft.com/dotnet/core/api/System.Collections.DictionaryEntry) objects when enumerated, although the two generic types return [KeyValuePair&lt;TKey, TValue&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Generic.KeyValuePair-2) objects.  
   
*   Elements are sorted according to a [System.Collections.IComparer](https://docs.microsoft.com/dotnet/core/api/System.Collections.IComparer) implementation (for nongeneric `SortedList`) or a [System.Collections.Generic.IComparer&lt;T&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Generic.IComparer-1) implementation (for the two generic classes).  
   
 *   Each class provides properties that return collections containing only the keys or only the values.  
   
The following table lists some of the differences between the two sorted list classes and the [SortedDictionary<TKey, TValue>](https://docs.microsoft.com/dotnet/core/api/System.Collections.Generic.SortedDictionary-2) class.  
   
 `SortedList` nongeneric class and `SortedList<TKey, TValue>` generic class | `SortedDictionary<TKey, TValue>` generic class  
 --------------------------------------------------------------------------------- | ------------------------------  
 The properties that return keys and values are indexed, allowing efficient indexed retrieval. | No indexed retrieval.  
 Retrieval is O(log n). | Retrieval is O(log n).  
 Insertion and removal are generally O(n); however, insertion is O(1) for data that are already in sort order, so that each element is added to the end of the list. (This assumes that a resize is not required.) | Insertion and removal are O(log n).  
 Uses less memory than a `SortedDictionary<TKey, TValue>`. | Uses more memory than the `SortedList` nongeneric class and the `SortedList<TKey, TValue>` generic class.  
  
 For sorted lists or dictionaries that must be accessible concurrently from multiple threads, you can add sorting logic to a class that derives from [ConcurrentDictionary&lt;TKey, TValue&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Concurrent.ConcurrentDictionary-2).  
  
 > [!NOTE]  
 > For values that contain their own keys (for example, employee records that contain an employee ID number), you can create a keyed collection that has some characteristics of a list and some characteristics of a dictionary by deriving from the [KeyedCollection&lt;TKey, TItem&gt;]() generic class.  
   
 The [SortedSet&lt;T&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Generic.SortedSet-1) class provides a self-balancing tree that maintains data in sorted order after insertions, deletions, and searches. This class and the [HashSet&lt;T&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Generic.HashSet-1) class implement the [ISet&lt;T&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Generic.ISet-1) interface.  
   
## See Also  
  
[System.Collections.IDictionary](https://docs.microsoft.com/dotnet/core/api/System.Collections.IDictionary)  
   
[System.Collections.Generic.IDictionary&lt;TKey, TValue&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Generic.IDictionary-2)  
   
[ConcurrentDictionary&lt;TKey, TValue&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Concurrent.ConcurrentDictionary-2)  
 
[Commonly Used Collection Types](commonly-used-collection-types.md) 
