---
title: Channels in .NET
description: Learn how to use System.Threading.Channels in .NET.
author: IEvangelist
ms.author: dapine
ms.date: 08/02/2022
---

# System.Threading.Channels in .NET

The <xref:System.Threading.Channels?displayProperty=fullName> namespace provides a set of synchronization data structures for passing data between producers and consumers asynchronously. The library targets .NET Standard and works on all .NET implementations.

This library is available in the [System.Threading.Channels](https://www.nuget.org/packages/System.Threading.Channels) NuGet package (or included when targeting .NET Core 2.1+).

## Producer/consumer conceptual programming model

Channels are an implementation of the producer/consumer conceptual programming model. In this programming model, producers asynchronously produce data, and consumers asynchronously consume that data. In other words, this model hands off data from one party to another. Try to think of channels as you would any other common generic collection type, such as a `List<T>`. The primary difference is that this collection manages synchronization and provides various consumption models through factory creation options. These options control the _bounding strategies_ employed by the channel instance and the behavior of the channel when the bound is reached.

## Bounding strategies

Depending on how a `Channel<T>` is created, its reader and writer will behave differently.

To create a channel that specifies a maximum capacity, call <xref:System.Threading.Channels.Channel.CreateBounded%2A?displayProperty=nameWithType>. To create a channel that can be used by any number of readers and writers concurrently, call <xref:System.Threading.Channels.Channel.CreateUnbounded%2A?displayProperty=nameWithType>. Each bounding strategy exposes various creator-defined options, either <xref:System.Threading.Channels.BoundedChannelOptions> or <xref:System.Threading.Channels.UnboundedChannelOptions> respectively.

> [!NOTE]
> Regardless of the bounding strategy, a channel will always throw a <xref:System.Threading.Channels.ChannelClosedException> when it's used after it's been closed.

### Unbounded channels

To create an unbounded channel, call one of the <xref:System.Threading.Channels.Channel.CreateUnbounded%2A?displayProperty=nameWithType> overloads:

```csharp
var channel = Channel.CreateUnbounded<string>();
```

When you create an unbounded channel, by default, the channel can be used by any number of readers and writers concurrently. Alternatively, you can specify non-default behavior when creating an unbounded channel by providing an `UnboundedChannelOptions` instance:

```csharp
var channel = Channel.CreateUnbounded<string>(
    new UnboundedChannelOptions
    {
        SingleWriter = true,
        SingleReader = false,
        AllowSynchronousContinuations = true
    });
```

In the preceding code, the channel will be created with the following options:

- `SingleWriter = true`: The channel guarantees that there will only ever be at most one write operation at a time.
- `SingleReader = false`: The channel is not constrained to a single read operation at any given time.
- `AllowSynchronousContinuations = true`: Operations performed on a channel may synchronously invoke continuations that are subscribed to notifications of pending async operations.

The channel's writer (producer) is unbounded and can write synchronously.

### Bounded channels

To create a bounded channel, call one of the <xref:System.Threading.Channels.Channel.CreateBounded%2A?displayProperty=nameWithType> overloads:

```csharp
var channel = Channel.CreateBounded<string>(10);
```

The preceding code creates a channel that has a maximum capacity of 10 items. When you create a bounded channel, the channel is bound to a maximum capacity. When the bound is reached, the default behavior is that the channel will block the producer or consumer until space becomes available. You can configure this behavior by specifying an option when you create the channel.

```csharp
var channel = Channel.CreateBounded<string>(
    new BoundedChannelOptions(20)
    {
        AllowSynchronousContinuations = true,
        FullMode = BoundedChannelFullMode.DropOldest
    });
```

The preceding code creates a channel that has a maximum capacity of 20 items. The options specify that the channel should drop the oldest item when the channel is full. To handle when an item is dropped, you can provide an `itemDropped` callback:

```csharp
var channel = Channel.CreateBounded<string>(
    new BoundedChannelOptions(50),
    item =>
    {
        Console.WriteLine($"Item dropped: {item}");
    });
```

Whenever the channel is full and a new item is added, the `itemDropped` callback will be invoked. In this example, the provided callback writes the item to the console, but you're free to take any other action you want.

#### Full mode behavior

When using a bounded channel, you can specify the behavior the channel will adhere to when the configured bound is reached. The following table lists the full mode behaviors for each <xref:System.Threading.Channels.BoundedChannelFullMode> value:

| Value | Behavior |
|--|--|
| <xref:System.Threading.Channels.BoundedChannelFullMode.Wait?displayProperty=nameWithType> | This is the default value. Waits for space to be available in order to complete the write operation. |
| <xref:System.Threading.Channels.BoundedChannelFullMode.DropNewest?displayProperty=nameWithType> | Removes and ignores the newest item in the channel in order to make room for the item being written. |
| <xref:System.Threading.Channels.BoundedChannelFullMode.DropOldest?displayProperty=nameWithType> | Removes and ignores the oldest item in the channel in order to make room for the item being written. |
| <xref:System.Threading.Channels.BoundedChannelFullMode.DropWrite?displayProperty=nameWithType> | Drops the item being written. |

> [!IMPORTANT]
> Whenever a <xref:System.Threading.Channels.Channel%602.Writer%2A?displayProperty=nameWithType> produces faster than a <xref:System.Threading.Channels.Channel%602.Reader%2A?displayProperty=nameWithType> can consume, the channel's reader may experience _back pressure_.

## Producer APIs

The producer functionality is exposed on the <xref:System.Threading.Channels.Channel%602.Writer%2A?displayProperty=nameWithType>. The producer APIs and expected behavior are detailed in the following table:

| API | Expected behavior |
|--|--|
| <xref:System.Threading.Channels.ChannelWriter%601.Complete%2A?displayProperty=nameWithType> | Marks the channel as being complete, meaning no more items will be written to it. |
| <xref:System.Threading.Channels.ChannelWriter%601.TryComplete%2A?displayProperty=nameWithType> | Attempts to mark the channel as being completed, meaning no more data will be written to it. |
| <xref:System.Threading.Channels.ChannelWriter%601.TryWrite%2A?displayProperty=nameWithType> | Attempts to write the specified item to the channel. When used with an unbounded channel, this always returns `true` unless the channel's writer signals completion with either <xref:System.Threading.Channels.ChannelWriter%601.Complete%2A?displayProperty=nameWithType>, or <xref:System.Threading.Channels.ChannelWriter%601.TryComplete%2A?displayProperty=nameWithType>. |
| <xref:System.Threading.Channels.ChannelWriter%601.WaitToWriteAsync%2A?displayProperty=nameWithType> | Returns a <xref:System.Threading.Tasks.ValueTask%601> that will complete when space is available to write an item. |
| <xref:System.Threading.Channels.ChannelWriter%601.WriteAsync%2A?displayProperty=nameWithType> | Asynchronously writes an item to the channel. When used with an unbounded channel, this will write synchronously. |

## Consumer APIs

The consumer functionality is exposed on the <xref:System.Threading.Channels.Channel%602.Reader%2A?displayProperty=nameWithType>. The consumer APIs and expected behavior are detailed in the following table:

| API | Expected behavior |
|--|--|
| <xref:System.Threading.Channels.ChannelReader%601.ReadAllAsync%2A?displayProperty=nameWithType> | Creates an <xref:System.Collections.Generic.IAsyncEnumerable%601> that enables reading all of the data from the channel. |
| <xref:System.Threading.Channels.ChannelReader%601.ReadAsync%2A?displayProperty=nameWithType> | Asynchronously reads an item from the channel. |
| <xref:System.Threading.Channels.ChannelReader%601.TryPeek%2A?displayProperty=nameWithType> | Attempts to peek at an item from the channel. |
| <xref:System.Threading.Channels.ChannelReader%601.TryRead%2A?displayProperty=nameWithType> | Attempts to read an item from the channel. |
| <xref:System.Threading.Channels.ChannelReader%601.WaitToReadAsync%2A?displayProperty=nameWithType> | Returns a <xref:System.Threading.Tasks.ValueTask%601> that will complete when data is available to read. |

## Usage patterns

There are several usage patterns for channels. The API is designed to be simple, consistent, and as flexible as possible. All of the asynchronous methods return a `ValueTask` (or `ValueTask<bool>`) that represents a lightweight asynchronous operation that can avoid allocating if the operation completes synchronously. Additionally, the API is designed to be composable, in that the creator of a channel makes promises about its intended usage. When a channel is created with certain parameters, the internal implementation can operate more efficiently knowing these promises.

Imagine that you're creating a producer/consumer solution for a global position system (GPS). You want to track the coordinates of a device over time. A sample coordinates object might look like this:

:::code language="csharp" source="./snippets/channels/channels/Coordinates.cs":::

## See also

- [On .NET show: Working with Channels in .NET](/shows/on-net/working-with-channels-in-net)
- [.NET Blog: An Introduction to System.Threading.Channels](https://devblogs.microsoft.com/dotnet/an-introduction-to-system-threading-channels)
