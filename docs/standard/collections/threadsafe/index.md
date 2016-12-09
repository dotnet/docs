---
title: Thread-Safe Collections
description: Thread-Safe Collections
keywords: .NET, .NET Core
author: mairaw
ms.author: mairaw
ms.date: 06/20/2016
ms.topic: article
ms.prod: .net
ms.technology: dotnet-standard
ms.devlang: dotnet
ms.assetid: 92d5515d-f5d6-4a09-8bbb-31865d678643
---

# Thread-Safe Collections

The [System.Collections.Concurrent](https://docs.microsoft.com/dotnet/core/api/System.Collections.Concurrent) namespace includes several collection classes that are both thread-safe and scalable. Multiple threads can safely and efficiently add or remove items from these collections, without requiring additional synchronization in user code. When you write new code, use the concurrent collection classes whenever the collection will be writing to multiple threads concurrently. If you are only reading from a shared collection, then you can use the classes in the [System.Collections.Generic](https://docs.microsoft.com/dotnet/core/api/System.Collections.Generic) namespace. We recommend that you do not use [System.Collections](https://docs.microsoft.com/dotnet/core/api/System.Collections) collection classes unless you are required to target the .NET Framework 1.1 or earlier runtime.

## Fine-Grained Locking and Lock-Free Mechanisms

Some of the concurrent collection types use lightweight synchronization mechanisms such as [SpinLock](https://docs.microsoft.com/dotnet/core/api/System.Threading.SpinLock), [SpinWait](https://docs.microsoft.com/dotnet/core/api/System.Threading.SpinWait), [SemaphoreSlim](https://docs.microsoft.com/dotnet/core/api/System.Threading.SemaphoreSlim), and [CountdownEvent](https://docs.microsoft.com/dotnet/core/api/System.Threading.CountdownEvent). These synchronization types typically use busy spinning for brief periods before they put the thread into a true `Wait` state. When wait times are expected to be very short, spinning is far less computationally expensive than waiting, which involves an expensive kernel transition. For collection classes that use spinning, this efficiency means that multiple threads can add and remove items at a very high rate.

The [ConcurrentQueue&lt;T&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Concurrent.ConcurrentQueue-1) and [ConcurrentStack&lt;T&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Concurrent.ConcurrentStack-1) classes do not use locks at all. Instead, they rely on Interlocked operations to achieve thread-safety.

> [!NOTE]
> Because the concurrent collections classes support [ICollection](https://docs.microsoft.com/dotnet/core/api/System.Collections.ICollection), they provide implementations for the `IsSynchronized` and `SyncRoot` properties, even though these properties are irrelevant. `IsSynchronized` always returns `false` and `SyncRoot` is always null.

The following table lists the collection types in the [System.Collections.Concurrent](https://docs.microsoft.com/dotnet/core/api/System.Collections.Concurrent) namespace.

Type | Description
---- | -----------
[BlockingCollection&lt;T&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Concurrent.BlockingCollection-1) | Provides bounding and blocking functionality for any type that implements [IProducerConsumerCollection&lt;T&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Concurrent.IProducerConsumerCollection-1). For more information, see [BlockingCollection Overview](blockingcollection-overview.md).
[ConcurrentBag&lt;T&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Concurrent.ConcurrentBag-1) | Thread-safe implementation of an unordered collection of elements.
[ConcurrentDictionary&lt;TKey, TValue&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Concurrent.ConcurrentDictionary-2) | Thread-safe implementation of a dictionary of key-value pairs.
[ConcurrentQueue&lt;T&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Concurrent.ConcurrentQueue-1) | Thread-safe implementation of a FIFO (first-in, first-out) queue.
[ConcurrentStack&lt;T&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Concurrent.ConcurrentStack-1) | Thread-safe implementation of a LIFO (last-in, first-out) stack.
[IProducerConsumerCollection&lt;T&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Concurrent.IProducerConsumerCollection-1) | The interface that a type must implement to be used in a `BlockingCollection`.

## Thread Synchronization in the .NET Framework version 1.0 and 2.0 Collections

The collections first introduced in the .NET Framework version 1.0 are found in the [System.Collections](https://docs.microsoft.com/dotnet/core/api/System.Collections) namespace. These collections, which include the commonly used [ArrayList](https://docs.microsoft.com/dotnet/core/api/System.Collections.ArrayList) and [Hashtable](https://docs.microsoft.com/dotnet/core/api/System.Collections.Hashtable), provide some thread-safety through the `Synchronized` property, which returns a thread-safe wrapper around the collection. The wrapper works by locking the entire collection on every add or remove operation. Therefore, each thread that is attempting to access the collection must wait for its turn to take the one lock. This is not scalable and can cause significant performance degradation for large collections. Also, the design is not completely protected from race conditions. 

The collection classes first introduced in the .NET Framework version 2.0 are found in the [System.Collections.Generic](https://docs.microsoft.com/dotnet/core/api/System.Collections.Generic) namespace. These include [List&lt;T&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Generic.List-1), [Dictionary&lt;TKey, TValue&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Generic.Dictionary-2), and so on. These classes provide improved type safety and performance compared to the `System.Collections` classes. However, the `System.Collections.Generic` collection classes do not provide any thread synchronization; user code must provide all synchronization when items are added or removed on multiple threads concurrently.

We recommend the `System.Collections.Concurrent` collection classes because they provide not only the type safety of the `System.Collections.Generic` collection classes, but also more efficient and more complete thread safety than the `System.Collections` collections provide.

## Related Topics

Title | Description
----- | -----------
[BlockingCollection Overview](blockingcollection-overview.md) | Describes the functionality provided by the `BlockingCollection<T>` type.
[When to Use a Thread-Safe Collection](when-to-use-a-thread-safe-collection.md) | Explains when is it appropriate to use a thread-safe collection.
[How to: Add and Remove Items from a ConcurrentDictionary](how-to-add-and-remove-items.md) | Describes how to add and remove elements from a `ConcurrentDictionary<TKey, TValue>`.
[How to: Add and Take Items Individually from a BlockingCollection](how-to-add-and-take-items.md) | Describes how to add and retrieve items from a blocking collection without using the read-only enumerator.
[How to: Add Bounding and Blocking Functionality to a Collection](how-to-add-bounding-and-blocking.md) | Describes how to use any collection class as the underlying storage mechanism for an `IProducerConsumerCollection<T>;` collection.
[How to: Use ForEach to Remove Items in a BlockingCollection](how-to-use-foreach-to-remove.md) | Describes how to use `foreach` to remove all items in a blocking collection.
[How to: Use Arrays of Blocking Collections in a Pipeline](how-to-use-arrays-of-blockingcollections.md) | Describes how to use multiple blocking collections at the same time to implement a pipeline.
[How to: Create an Object Pool by Using a ConcurrentBag](how-to-create-an-object-pool.md) | Shows how to use a concurrent bag to improve performance in scenarios where you can reuse objects instead of continually creating new ones.

## Reference

[System.Collections.Concurrent](https://docs.microsoft.com/dotnet/core/api/System.Collections.Concurrent)






 


