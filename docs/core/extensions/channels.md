---
title: Channels
description: Learn the official synchronization data structures in System.Threading.Channels for producers and consumers with .NET.
author: IEvangelist
ms.author: dapine
ms.date: 06/26/2023
---

# System.Threading.Channels library

The <xref:System.Threading.Channels?displayProperty=fullName> namespace provides a set of synchronization data structures for passing data between producers and consumers asynchronously. The library targets .NET Standard and works on all .NET implementations.

This library is available in the [System.Threading.Channels](https://www.nuget.org/packages/System.Threading.Channels) NuGet package. However, if you're using .NET Core 3.0 or later, the package is included as part of the framework.

## Producer/consumer conceptual programming model

Channels are an implementation of the producer/consumer conceptual programming model. In this programming model, producers asynchronously produce data, and consumers asynchronously consume that data. In other words, this model hands off data from one party to another. Try to think of channels as you would any other common generic collection type, such as a `List<T>`. The primary difference is that this collection manages synchronization and provides various consumption models through factory creation options. These options control the behavior of the channels, such as how many elements they're allowed to store and what happens if that limit is reached, or whether the channel is accessed by multiple producers or multiple consumers concurrently.

## Bounding strategies

Depending on how a `Channel<T>` is created, its reader and writer behave differently.

To create a channel that specifies a maximum capacity, call <xref:System.Threading.Channels.Channel.CreateBounded%2A?displayProperty=nameWithType>. To create a channel that is used by any number of readers and writers concurrently, call <xref:System.Threading.Channels.Channel.CreateUnbounded%2A?displayProperty=nameWithType>. Each bounding strategy exposes various creator-defined options, either <xref:System.Threading.Channels.BoundedChannelOptions> or <xref:System.Threading.Channels.UnboundedChannelOptions> respectively.

> [!NOTE]
> Regardless of the bounding strategy, a channel will always throw a <xref:System.Threading.Channels.ChannelClosedException> when it's used after it's been closed.

### Unbounded channels

To create an unbounded channel, call one of the <xref:System.Threading.Channels.Channel.CreateUnbounded%2A?displayProperty=nameWithType> overloads:

```csharp
var channel = Channel.CreateUnbounded<T>();
```

When you create an unbounded channel, by default, the channel can be used by any number of readers and writers concurrently. Alternatively, you can specify nondefault behavior when creating an unbounded channel by providing an `UnboundedChannelOptions` instance. The channel's capacity is unbounded and all writes are performed synchronously. For more examples, see [Unbounded creation patterns](#unbounded-creation-patterns).

### Bounded channels

To create a bounded channel, call one of the <xref:System.Threading.Channels.Channel.CreateBounded%2A?displayProperty=nameWithType> overloads:

```csharp
var channel = Channel.CreateBounded<T>(7);
```

The preceding code creates a channel that has a maximum capacity of `7` items. When you create a bounded channel, the channel is bound to a maximum capacity. When the bound is reached, the default behavior is that the channel asynchronously blocks the producer until space becomes available. You can configure this behavior by specifying an option when you create the channel. Bounded channels can be created with any capacity value greater than zero. For other examples, see [Bounded creation patterns](#bounded-creation-patterns).

#### Full mode behavior

When using a bounded channel, you can specify the behavior the channel adheres to when the configured bound is reached. The following table lists the full mode behaviors for each <xref:System.Threading.Channels.BoundedChannelFullMode> value:

| Value | Behavior |
|--|--|
| <xref:System.Threading.Channels.BoundedChannelFullMode.Wait?displayProperty=nameWithType> | This is the default value. Calls to `WriteAsync` wait for space to be available in order to complete the write operation. Calls to `TryWrite` return `false` immediately. |
| <xref:System.Threading.Channels.BoundedChannelFullMode.DropNewest?displayProperty=nameWithType> | Removes and ignores the newest item in the channel in order to make room for the item being written. |
| <xref:System.Threading.Channels.BoundedChannelFullMode.DropOldest?displayProperty=nameWithType> | Removes and ignores the oldest item in the channel in order to make room for the item being written. |
| <xref:System.Threading.Channels.BoundedChannelFullMode.DropWrite?displayProperty=nameWithType> | Drops the item being written. |

> [!IMPORTANT]
> Whenever a <xref:System.Threading.Channels.Channel%602.Writer%2A?displayProperty=nameWithType> produces faster than a <xref:System.Threading.Channels.Channel%602.Reader%2A?displayProperty=nameWithType> can consume, the channel's writer experiences back pressure.

## Producer APIs

The producer functionality is exposed on the <xref:System.Threading.Channels.Channel%602.Writer%2A?displayProperty=nameWithType>. The producer APIs and expected behavior are detailed in the following table:

| API | Expected behavior |
|--|--|
| <xref:System.Threading.Channels.ChannelWriter%601.Complete%2A?displayProperty=nameWithType> | Marks the channel as being complete, meaning no more items are written to it. |
| <xref:System.Threading.Channels.ChannelWriter%601.TryComplete%2A?displayProperty=nameWithType> | Attempts to mark the channel as being completed, meaning no more data is written to it. |
| <xref:System.Threading.Channels.ChannelWriter%601.TryWrite%2A?displayProperty=nameWithType> | Attempts to write the specified item to the channel. When used with an unbounded channel, this always returns `true` unless the channel's writer signals completion with either <xref:System.Threading.Channels.ChannelWriter%601.Complete%2A?displayProperty=nameWithType>, or <xref:System.Threading.Channels.ChannelWriter%601.TryComplete%2A?displayProperty=nameWithType>. |
| <xref:System.Threading.Channels.ChannelWriter%601.WaitToWriteAsync%2A?displayProperty=nameWithType> | Returns a <xref:System.Threading.Tasks.ValueTask%601> that completes when space is available to write an item. |
| <xref:System.Threading.Channels.ChannelWriter%601.WriteAsync%2A?displayProperty=nameWithType> | Asynchronously writes an item to the channel. |

## Consumer APIs

The consumer functionality is exposed on the <xref:System.Threading.Channels.Channel%602.Reader%2A?displayProperty=nameWithType>. The consumer APIs and expected behavior are detailed in the following table:

| API | Expected behavior |
|--|--|
| <xref:System.Threading.Channels.ChannelReader%601.ReadAllAsync%2A?displayProperty=nameWithType> | Creates an <xref:System.Collections.Generic.IAsyncEnumerable%601> that enables reading all of the data from the channel. |
| <xref:System.Threading.Channels.ChannelReader%601.ReadAsync%2A?displayProperty=nameWithType> | Asynchronously reads an item from the channel. |
| <xref:System.Threading.Channels.ChannelReader%601.TryPeek%2A?displayProperty=nameWithType> | Attempts to peek at an item from the channel. |
| <xref:System.Threading.Channels.ChannelReader%601.TryRead%2A?displayProperty=nameWithType> | Attempts to read an item from the channel. |
| <xref:System.Threading.Channels.ChannelReader%601.WaitToReadAsync%2A?displayProperty=nameWithType> | Returns a <xref:System.Threading.Tasks.ValueTask%601> that completes when data is available to read. |

## Common usage patterns

There are several usage patterns for channels. The API is designed to be simple, consistent, and as flexible as possible. All of the asynchronous methods return a `ValueTask` (or `ValueTask<bool>`) that represents a lightweight asynchronous operation that can avoid allocating if the operation completes synchronously and potentially even asynchronously. Additionally, the API is designed to be composable, in that the creator of a channel makes promises about its intended usage. When a channel is created with certain parameters, the internal implementation can operate more efficiently knowing these promises.

### Creation patterns

Imagine that you're creating a producer/consumer solution for a global position system (GPS). You want to track the coordinates of a device over time. A sample coordinates object might look like this:

:::code language="csharp" source="./snippets/channels/Coordinates.cs":::

#### Unbounded creation patterns

One common usage pattern is to create a default unbounded channel:

:::code language="csharp" source="snippets/channels/Program.Unbounded.cs" id="unbounded":::

But instead, let's imagine that you want to create an unbounded channel with multiple producers and consumers:

:::code language="csharp" source="snippets/channels/Program.Unbounded.cs" id="unboundedoptions":::

In this case, all writes are synchronous, even the `WriteAsync`. This is because an unbounded channel always has available room for a write effectively immediately. However, with `AllowSynchronousContinuations` set to `true`, the writes may end up doing work associated with a reader by executing their continuations. This doesn't affect the synchronicity of the operation.

#### Bounded creation patterns

With bounded channels, the configurability of the channel should be known to the consumer to help ensure proper consumption. That is, the consumer should know what behavior the channel exhibits when the configured bound is reached. Let's explore some of the common bounded creation patterns.

The simplest way to create a bounded channel is to specify a capacity:

:::code language="csharp" source="snippets/channels/Program.Bounded.cs" id="boundedcapcity":::

The preceding code creates a bounded channel with a max capacity of `1`. Other options are available, some options are the same as an unbounded channel, while others are specific to unbounded channels:

:::code language="csharp" source="snippets/channels/Program.Bounded.cs" id="boundedoptions":::

In the preceding code, the channel is created as a bounded channel that's limited to 1,000 items, with a single writer but many readers. Its full mode behavior is defined as `DropWrite`, which means that it drops the item being written if the channel is full.

To observe items that are dropped when using bounded channels, register an `itemDropped` callback:

:::code language="csharp" source="snippets/channels/Program.Bounded.cs" id="boundedcallback":::

Whenever the channel is full and a new item is added, the `itemDropped` callback is invoked. In this example, the provided callback writes the item to the console, but you're free to take any other action you want.

### Producer patterns

Imagine that the producer in this scenario is writing new coordinates to the channel. The producer can do this by calling <xref:System.Threading.Channels.ChannelWriter%601.TryWrite%2A>:

:::code language="csharp" source="snippets/channels/Program.Producer.cs" id="whiletrywrite":::

The preceding producer code:

- Accepts the `Channel<Coordinates>.Writer` (`ChannelWriter<Coordinates>`) as an argument, along with the initial `Coordinates`.
- Defines a conditional `while` loop that attempts to move the coordinates using `TryWrite`.

An alternative producer might use the `WriteAsync` method:

:::code language="csharp" source="snippets/channels/Program.Producer.cs" id="whilewrite":::

Again, the `Channel<Coordinates>.Writer` is used within a `while` loop. But this time, the <xref:System.Threading.Channels.ChannelWriter%601.WriteAsync%2A> method is called. The method will continue only after the coordinates have been written. When the `while` loop exits, a call to <xref:System.Threading.Channels.ChannelWriter%601.Complete%2A> is made, which signals that no more data is written to the channel.

Another producer pattern is to use the <xref:System.Threading.Channels.ChannelWriter%601.WaitToWriteAsync%2A> method, consider the following code:

:::code language="csharp" source="snippets/channels/Program.Producer.cs" id="waittowrite":::

As part of the conditional `while`, the result of the `WaitToWriteAsync` call is used to determine whether to continue the loop.

### Consumer patterns

There are several common channel consumer patterns. When a channel is never ending, meaning it produces data indefinitely, the consumer could use a `while (true)` loop, and read data as it becomes available:

:::code language="csharp" source="snippets/channels/Program.Consumer.cs" id="whiletrue":::

> [!NOTE]
> This code will throw an exception if the channel is closed.

An alternative consumer could avoid this concern by using a nested while loop, as shown in the following code:

:::code language="csharp" source="snippets/channels/Program.Consumer.cs" id="nestedwhile":::

In the preceding code, the consumer waits to read data. Once the data is available, the consumer tries to read it. These loops continue to evaluate until the producer of the channel signals that it no longer has data to be read. With that said, when a producer is known to have a finite number of items it produces and it signals completion, the consumer can use `await foreach` semantics to iterate over the items:

:::code language="csharp" source="snippets/channels/Program.Consumer.cs" id="awaitforeach":::

The preceding code uses the <xref:System.Threading.Channels.ChannelReader%601.ReadAllAsync%2A> method to read all of the coordinates from the channel.

## See also

- [On .NET show: Working with Channels in .NET](/shows/on-net/working-with-channels-in-net)
- [.NET Blog: An Introduction to System.Threading.Channels](https://devblogs.microsoft.com/dotnet/an-introduction-to-system-threading-channels)
- [Managed threading basics](../../standard/threading/managed-threading-basics.md)
