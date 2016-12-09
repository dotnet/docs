---
title: BlockingCollection Overview
description: BlockingCollection Overview
keywords: .NET, .NET Core
author: mairaw
ms.author: mairaw
ms.date: 06/20/2016
ms.topic: article
ms.prod: .net
ms.technology: dotnet-standard
ms.devlang: dotnet
ms.assetid: a1a867de-53c2-49ca-9a1a-e5770a942724
---

# BlockingCollection Overview

[BlockingCollection&lt;T&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Concurrent.BlockingCollection-1) is a thread-safe collection class that provides the following features:

*   An implementation of the Producer-Consumer pattern.

*   Thread-safe addition and removal of items from a collection.

*   Optional maximum capacity.

*   Insertion and removal operations that block when collection is empty or full.

*   Insertion and removal "try" operations that do not block or that block up to a specified period of time.

*   Encapsulates any collection type that implements [IProducerConsumerCollection&lt;T&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Concurrent.IProducerConsumerCollection-1).

*   Cancellation with cancellation tokens.

*   Two kinds of enumeration with `foreach`: 

    1. Read-only enumeration.
    
    2. Enumeration that removes items as they are enumerated.
    
## Bounding and Blocking Support 

[BlockingCollection&lt;T&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Concurrent.BlockingCollection-1) supports bounding and blocking. Bounding means you can set the maximum capacity of the collection. Bounding is important in certain scenarios because it enables you to control the maximum size of the collection in memory, and it prevents the producing threads from moving too far ahead of the consuming threads.

Multiple threads or tasks can add items to the collection concurrently, and if the collection reaches its specified maximum capacity, the producing threads will block until an item is removed. Multiple consumers can remove items concurrently, and if the collection becomes empty, the consuming threads will block until a producer adds an item. A producing thread can call `CompleteAdding` to indicate that no more items will be added. Consumers monitor the `IsCompleted` property to know when the collection is empty and no more items will be added. The following example shows a simple `BlockingCollection` with a bounded capacity of 100. A producer task adds items to the collection as long as some external condition is true, and then calls `CompleteAdding`. The consumer task takes items until the `IsCompleted` property is true.

```csharp
// A bounded collection. It can hold no more 
// than 100 items at once.
BlockingCollection<Data> dataItems = new BlockingCollection<Data>(100);


// A simple blocking consumer with no cancellation.
Task.Run(() => 
{
    while (!dataItems.IsCompleted)
    {

        Data data = null;
        // Blocks if number.Count == 0
        // IOE means that Take() was called on a completed collection.
        // Some other thread can call CompleteAdding after we pass the
        // IsCompleted check but before we call Take. 
        // In this example, we can simply catch the exception since the 
        // loop will break on the next iteration.
        try
        {
            data = dataItems.Take();
        }
        catch (InvalidOperationException) { }

        if (data != null)
        {
            Process(data);
        }
    }
    Console.WriteLine("\r\nNo more items to take.");
});

// A simple blocking producer with no cancellation.
Task.Run(() =>
{
    while (moreItemsToAdd)
    {
        Data data = GetData();
        // Blocks if numbers.Count == dataItems.BoundedCapacity
        dataItems.Add(data);
    }
    // Let consumer know we are done.
    dataItems.CompleteAdding();
});
```

For a complete example, see [How to: Add and Take Items Individually from a BlockingCollection](how-to-add-and-take-items.md).

## Timed Blocking Operations

In timed blocking `TryAdd` and `TryTake` operations on bounded collections, the method tries to add or take an item. If an item is available it is placed into the variable that was passed in by reference, and the method returns `true`. If no item is retrieved after a specified time-out period the method returns `false`. The thread is then free to do some other useful work before trying again to access the collection. For an example of timed blocking access, see the second example in [How to: Add and Take Items Individually from a BlockingCollection](how-to-add-and-take-items.md).

## Cancelling Add and Take Operations

Add and Take operations are typically performed in a loop. You can cancel a loop by passing in a `CancellationToken` to the `TryAdd` or `TryTake` method, and then checking the value of the token's `IsCancellationRequested` property on each iteration. If the value is `true`, then it is up to you to respond the cancellation request by cleaning up any resources and exiting the loop. The following example shows an overload of `TryAdd` that takes a cancellation token, and the code that uses it:

```csharp
BlockingCollection<string> bc = new BlockingCollection<string>(new ConcurrentBag<string>(), 1000 );
```

## Specifying the Collection Type

When you create a `BlockingCollection<T>;`, you can specify not only the bounded capacity but also the type of collection to use. For example, you could specify a [ConcurrentQueue&lt;T&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Concurrent.ConcurrentQueue-1) for first in-first out (FIFO) behavior, or a [ConcurrentStack&lt;T&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Concurrent.ConcurrentStack-1) for last in-first out (LIFO) behavior. You can use any collection class that implements the [IProducerConsumerCollection&lt;T&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Concurrent.IProducerConsumerCollection-1) interface. The default collection type for `BlockingCollection<T>` is `ConcurrentQueue<T>`. The following code example shows how to create a `BlockingCollection<T>` of strings that has a capacity of 1000 and uses a [ConcurrentBag&lt;T&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Concurrent.ConcurrentBag-1):

```csharp
BlockingCollection<string> bc = new BlockingCollection<string>(new ConcurrentBag<string>(), 1000 );
```

## IEnumerable Support

`BlockingCollection<T>` provides a `GetConsumingEnumerable` method that enables consumers to use a `foreach` statement to remove items until the collection is completed, which means it is empty and no more items will be added. For more information, see [How to: Use ForEach to Remove Items in a BlockingCollection](how-to-use-foreach-to-remove.md).

## Using Many BlockingCollections As One

For scenarios in which a consumer needs to take items from multiple collections simultaneously, you can create arrays of `BlockingCollection<T>` and use the static methods such as `TakeFromAny` and `AddToAny` that will add to or take from any of the collections in the array. If one collection is blocking, the method immediately tries another until it finds one that can perform the operation. For more information, see [How to: Use Arrays of Blocking Collections in a Pipeline](how-to-use-arrays-of-blockingcollections.md).

## See Also

[System.Collections.Concurrent](https://docs.microsoft.com/dotnet/core/api/System.Collections.Concurrent)

[Collections and Data Structures](../index.md)

[Thread-Safe Collections](index.md)

