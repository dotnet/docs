# Thread-Safe Collections

The [System.Collections.Concurrent](http://dotnet.github.io/api/System.Collections.Concurrent.html) namespace includes several collection classes that are both thread-safe and scalable. Multiple threads can safely and efficiently add or remove items from these collections, without requiring additional synchronization in user code. When you write new code, use the concurrent collection classes whenever the collection will be writing to multiple threads concurrently. If you are only reading from a shared collection, then you can use the classes in the [System.Collections.Generic](http://dotnet.github.io/api/System.Collections.Generic.html) namespace. We recommend that you do not use [System.Collections](http://dotnet.github.io/api/System.Collections.html) collection classes unless you are required to target the .NET Framework 1.1 or earlier runtime.

## Fine-Grained Locking and Lock-Free Mechanisms

Some of the concurrent collection types use lightweight synchronization mechanisms such as [SpinLock](http://dotnet.github.io/api/System.Threading.SpinLock.html), [SpinWait](http://dotnet.github.io/api/System.Threading.SpinWait.html), [SemaphoreSlim](http://dotnet.github.io/api/System.Threading.SemaphoreSlim.html), and [CountdownEvent](http://dotnet.github.io/api/System.Threading.CountdownEvent.html). These synchronization types typically use busy spinning for brief periods before they put the thread into a true `Wait` state. When wait times are expected to be very short, spinning is far less computationally expensive than waiting, which involves an expensive kernel transition. For collection classes that use spinning, this efficiency means that multiple threads can add and remove items at a very high rate.

The [ConcurrentQueue&lt;T&gt;](http://dotnet.github.io/api/System.Collections.Concurrent.ConcurrentQueue%601.html) and [ConcurrentStack&lt;T&gt;](http://dotnet.github.io/api/System.Collections.Concurrent.ConcurrentStack%601.html) classes do not use locks at all. Instead, they rely on Interlocked operations to achieve thread-safety.

> **Note**  
>
>Because the concurrent collections classes support [ICollection](http://dotnet.github.io/api/System.Collections.ICollection.html), they provide implementations for the `IsSynchronized` and `SyncRoot` properties, even though these properties are irrelevant. `IsSynchronized` always returns `false` and `SyncRoot` is always null.

The following table lists the collection types in the [System.Collections.Concurrent](http://dotnet.github.io/api/System.Collections.Concurrent.html) namespace.

Type | Description
---- | -----------
[BlockingCollection&lt;T&gt;](http://dotnet.github.io/api/System.Collections.Concurrent.BlockingCollection%601.html) | Provides bounding and blocking functionality for any type that implements [IProducerConsumerCollection&lt;T&gt;](http://dotnet.github.io/api/System.Collections.Concurrent.IProducerConsumerCollection%601.html). For more information, see [BlockingCollection Overview](threadsafe/blockingcollection-overview.md).
[ConcurrentBag&lt;T&gt;](http://dotnet.github.io/api/System.Collections.Concurrent.ConcurrentBag%601.html) | Thread-safe implementation of an unordered collection of elements.
[ConcurrentDictionary&lt;TKey, TValue&gt;](http://dotnet.github.io/api/System.Collections.Concurrent.ConcurrentDictionary%602.html) | Thread-safe implementation of a dictionary of key-value pairs.
[ConcurrentQueue&lt;T&gt;](http://dotnet.github.io/api/System.Collections.Concurrent.ConcurrentQueue%601.html) | Thread-safe implementation of a FIFO (first-in, first-out) queue.
[ConcurrentStack&lt;T&gt;](http://dotnet.github.io/api/System.Collections.Concurrent.ConcurrentStack%601.html) | Thread-safe implementation of a LIFO (last-in, first-out) stack.
[IProducerConsumerCollection&lt;T&gt;](http://dotnet.github.io/api/System.Collections.Concurrent.IProducerConsumerCollection%601.html) | The interface that a type must implement to be used in a `BlockingCollection`.

## Thread Synchronization in the .NET Framework version 1.0 and 2.0 Collections

The collections first introduced in the .NET Framework version 1.0 are found in the [System.Collections](http://dotnet.github.io/api/System.Collections.html) namespace. These collections, which include the commonly used [ArrayList](http://dotnet.github.io/api/System.Collections.ArrayList.html) and [Hashtable](http://dotnet.github.io/api/System.Collections.Hashtable.html), provide some thread-safety through the `Synchronized` property, which returns a thread-safe wrapper around the collection. The wrapper works by locking the entire collection on every add or remove operation. Therefore, each thread that is attempting to access the collection must wait for its turn to take the one lock. This is not scalable and can cause significant performance degradation for large collections. Also, the design is not completely protected from race conditions. 

The collection classes first introduced in the .NET Framework version 2.0 are found in the [System.Collections.Generic](http://dotnet.github.io/api/System.Collections.Generic.html) namespace. These include [List&lt;T&gt;](http://dotnet.github.io/api/System.Collections.Generic.List%601.html), [Dictionary&lt;TKey, TValue&gt;](http://dotnet.github.io/api/System.Collections.Generic.Dictionary%602.html), and so on. These classes provide improved type safety and performance compared to the `System.Collections` classes. However, the `System.Collections.Generic` collection classes do not provide any thread synchronization; user code must provide all synchronization when items are added or removed on multiple threads concurrently.

We recommend the `System.Collections.Concurrent` collection classes because they provide not only the type safety of the `System.Collections.Generic` collection classes, but also more efficient and more complete thread safety than the `System.Collections` collections provide.

## Related Topics

Title | Description
----- | -----------
[BlockingCollection Overview](threadsafe/blockingcollection-overview.md) | Describes the functionality provided by the `BlockingCollection<T>` type.
[When to Use a Thread-Safe Collection](threadsafe/when-to-use-a-thread-safe-collection.md) | Explains when is it appropriate to use a thread-safe collection.
[How to: Add and Remove Items from a ConcurrentDictionary](threadsafe\how-to-add-and-remove-items.md) | Describes how to add and remove elements from a `ConcurrentDictionary<TKey, TValue>`.
[How to: Add and Take Items Individually from a BlockingCollection](threadsafe\how-to-add-and-take-items.md) | Describes how to add and retrieve items from a blocking collection without using the read-only enumerator.
[How to: Add Bounding and Blocking Functionality to a Collection](threadsafe\how-to-add-bounding-and-blocking.md ) | Describes how to use any collection class as the underlying storage mechanism for an `IProducerConsumerCollection<T>;` collection.
[How to: Use ForEach to Remove Items in a BlockingCollection](threadsafe\how-to-use-foreach-to-remove.md ) | Describes how to use `foreach` to remove all items in a blocking collection.
[How to: Use Arrays of Blocking Collections in a Pipeline](threadsafe\how-to-use-arrays-of-blockingcollections.md) | Describes how to use multiple blocking collections at the same time to implement a pipeline.
[How to: Create an Object Pool by Using a ConcurrentBag](threadsafe\how-to-create-an-object-pool.md) | Shows how to use a concurrent bag to improve performance in scenarios where you can reuse objects instead of continually creating new ones.

## Reference

[System.Collections.Concurrent](http://dotnet.github.io/api/System.Collections.Concurrent.html)






 


