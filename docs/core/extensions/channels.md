---
title: Channels in .NET
description: Learn how to use System.Threading.Channels in .NET.
author: IEvangelist
ms.author: dapine
ms.date: 07/29/2022
---

# System.Threading.Channels in .NET

<xref:System.Threading.Channels?displayProperty=fullName> provides a set of synchronization data structures for passing data between producers and consumers asynchronously. It's a library targeting .NET Standard that works on all .NET implementations.

This library is available in the [System.Threading.Channels](https://www.nuget.org/packages/System.Threading.Channels) NuGet package (or included when targeting .NET Core 2.1+).

## Producer/Consumer model

The purpose of the producer/consumer model is to allow producers to asynchronously produce data, and consumers to asynchronously consume that data. In other words, this model hands off data from one party to another. Try to think of the <xref:System.Threading.Channels.Channel%601> type as you would for any other common collection type, such as a `List<T>`. The primary difference is this collection manages synchronization and provides various consumption models through creation options.

## Bounding strategies

To create a channel that specifies a maximum capacity, call <xref:System.Threading.Channels.Channel.CreateBounded%2A?displayProperty=nameWithType>. To create a channel that can be used by any number of readers and writers concurrently, call <xref:System.Threading.Channels.Channel.CreateUnbounded%2A?displayProperty=nameWithType>.



### Producer

| Bounded                                                                                       | Unbounded |
|-----------------------------------------------------------------------------------------------|-----------|
| <xref:System.Threading.Channels.ChannelWriter%601.TryWrite%2A?displayProperty=nameWithType>   |           |
| <xref:System.Threading.Channels.ChannelWriter%601.WriteAsync%2A?displayProperty=nameWithType> |           |
|                                                                                               |           |
|                                                                                               |           |

### Consumer

## Usage patterns


Producer consumer




Bounding strategies

Unbounded vs 				Bounded
Write					TryWrite
WriteAsync - synchronous  	TryWriteAsync {ValueTask}!!

If it's full, I may want you to wait.
If it's full, I may want you to drop an item, again a configurable choice, oldest or newest.
Do you want me to pretend that I took what you just gave me and throw it on the floor?

NOTES:

When bounded, writes will wait until values have been read.

Avoids allocations when completing synchronously.

Back-pressure, producer writes faster than the consumer can read... this leads to back-pressure.

Usage Patterns:

WRITER
while (writer wait to write)
   try write


while (reader wait to read)
    try read

or await foreach w/ complete signal

Creation options
By making promises about usage, the internal implementation can operate more efficiently.

In-process