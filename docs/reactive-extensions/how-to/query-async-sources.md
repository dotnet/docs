---
title: Query asynchronous observable sequences
description: Learn how to query asynchronous observable sequences using Reactive Extensions for .NET.
author: IEvangelist
ms.author: dapine
ms.date: 11/06/2020
---

# Query asynchronous observable sequences

Besides .NET events, other asynchronous data sources exist in .NET. One of them is the task-based asynchronous operations. These asynchronous operations, designated by [generalized async return types](../../csharp/programming-guide/concepts/async/async-return-types.md#generalized-async-return-types-and-valuetasktresult), are valid operations to convert into observable sequences. In this article you will learn how to use Rx factory methods to convert asynchronous data sources to observable sequences.

## Convert async code to observable sequences

Many asynchronous methods in .NET are written with the task-based asynchronous pattern. The `FromAsync<T>` operator of the `Observable` type wraps the task returning methods (which are being passed as parameters to the operator), and returns a function that takes the same parameters, and returns an observable. This observable represents a sequence that publishes a single value, which is the asynchronous result of the call you just specified.

:::code language="csharp" source="snippets/async/Program.cs":::

In the preceding example, you convert <xref:System.IO.Stream.ReadAsync(System.Byte[],System.Int32,System.Int32)?displayProperty=nameWithType> into a local function named `Read`. When evaluated it yields an `IObservable<int>`. The `Read` function accepts the same parameters as the `ReadAsync` method you're wrapping. Since you now have an `IObservable<int>` instead of a `Task<int>`, you can use all the LINQ operators available to observables and subscribe, parse, or compose it.

The <xref:System.Console.OpenStandardInput?displayProperty=nameWithType> stream is used, allowing the user to enter some text into the console window. The example calls the `Read` function, and subscribes to the `IObservable<int>`. When the user enters text, the `OnNext` callback is invoked writing the number of bytes from the input stream that were read.

Example output might resemble the following, given the user types `"Does this thing work?!":

```console
Type something, then press the ENTER key.
Does this thing work?!
OnNext: bytes read=24
OnCompleted
```

## See also

- [Query event-based observable sequences in .NET](query-event-sequences.md)
- [Query observable sequences using LINQ operators](query-sequences-linq.md)
- [Use schedulers with observables](use-schedulers.md)
