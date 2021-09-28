---
title: Add and Remove Items from a ConcurrentDictionary
description: Read an example of how to add, retrieve, update, and remove items from the ConcurrentDictionary<TKey,TValue> collection class in .NET.
ms.date: 05/04/2020
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "thread-safe collections, concurrent dictionary"
ms.assetid: 81b64b95-13f7-4532-9249-ab532f629598
---
# How to add and remove items from a ConcurrentDictionary

This example shows how to add, retrieve, update, and remove items from a <xref:System.Collections.Concurrent.ConcurrentDictionary%602?displayProperty=nameWithType>. This collection class is a thread-safe implementation. We recommend that you use it whenever multiple threads might be attempting to access the elements concurrently.

<xref:System.Collections.Concurrent.ConcurrentDictionary%602> provides several convenience methods that make it unnecessary for code to first check whether a key exists before it attempts to add or remove data. The following table lists these convenience methods and describes when to use them.

| Method | Use when… |
|--|--|
| <xref:System.Collections.Concurrent.ConcurrentDictionary%602.AddOrUpdate%2A> | You want to add a new value for a specified key and, if the key already exists, you want to replace its value. |
| <xref:System.Collections.Concurrent.ConcurrentDictionary%602.GetOrAdd%2A> | You want to retrieve the existing value for a specified key and, if the key does not exist, you want to specify a key/value pair. |
| <xref:System.Collections.Concurrent.ConcurrentDictionary%602.TryAdd%2A>, <xref:System.Collections.Concurrent.ConcurrentDictionary%602.TryGetValue%2A>, <xref:System.Collections.Concurrent.ConcurrentDictionary%602.TryUpdate%2A>, <xref:System.Collections.Concurrent.ConcurrentDictionary%602.TryRemove%2A> | You want to add, get, update, or remove a key/value pair, and, if the key already exists or the attempt fails for any other reason, you want to take some alternative action. |

## Example

The following example uses two <xref:System.Threading.Tasks.Task> instances to add some elements to a <xref:System.Collections.Concurrent.ConcurrentDictionary%602> concurrently, and then outputs all of the contents to show that the elements were added successfully. The example also shows how to use the <xref:System.Collections.Concurrent.ConcurrentDictionary%602.AddOrUpdate%2A>, <xref:System.Collections.Generic.Dictionary%602.TryGetValue%2A>, and <xref:System.Collections.Concurrent.ConcurrentDictionary%602.GetOrAdd%2A> methods to add, update, and retrieve items from the collection.

[!code-csharp[CDS#16](../../../../samples/snippets/csharp/VS_Snippets_Misc/cds/cs/cds_dictionaryhowto.cs#16)]
[!code-vb[CDS#16](../../../../samples/snippets/visualbasic/VS_Snippets_Misc/cds/vb/cds_concdict.vb#16)]

<xref:System.Collections.Concurrent.ConcurrentDictionary%602> is designed for multithreaded scenarios. You do not have to use locks in your code to add or remove items from the collection. However, it is always possible for one thread to retrieve a value, and another thread to immediately update the collection by giving the same key a new value.

Also, although all methods of <xref:System.Collections.Concurrent.ConcurrentDictionary%602> are thread-safe, not all methods are atomic, specifically <xref:System.Collections.Concurrent.ConcurrentDictionary%602.GetOrAdd%2A> and <xref:System.Collections.Concurrent.ConcurrentDictionary%602.AddOrUpdate%2A>. To prevent unknown code from blocking all threads, the user delegate that's passed to these methods is invoked outside of the dictionary's internal lock. Therefore, it's possible for this sequence of events to occur:

1. _threadA_ calls <xref:System.Collections.Concurrent.ConcurrentDictionary%602.GetOrAdd%2A>, finds no item, and creates a new item to add by invoking the `valueFactory` delegate.

1. _threadB_ calls <xref:System.Collections.Concurrent.ConcurrentDictionary%602.GetOrAdd%2A> concurrently, its `valueFactory` delegate is invoked and it arrives at the internal lock before _threadA_, and so its new key-value pair is added to the dictionary.

1. _threadA's_ user delegate completes, and the thread arrives at the lock, but now sees that the item exists already.

1. _threadA_ performs a "Get" and returns the data that was previously added by _threadB_.

Therefore, it is not guaranteed that the data that is returned by <xref:System.Collections.Concurrent.ConcurrentDictionary%602.GetOrAdd%2A> is the same data that was created by the thread's `valueFactory`. A similar sequence of events can occur when <xref:System.Collections.Concurrent.ConcurrentDictionary%602.AddOrUpdate%2A> is called.

## See also

- <xref:System.Collections.Concurrent?displayProperty=nameWithType>
- [Thread-Safe Collections](index.md)
