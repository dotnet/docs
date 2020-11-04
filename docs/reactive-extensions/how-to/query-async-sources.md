---
title: Query asynchronous Observable sequences
description: Learn how to query asynchronous Observable sequences using Reactive Extensions in .NET.
author: IEvangelist
ms.author: dapine
ms.date: 11/03/2020
---

# Query asynchronous Observable sequences

Besides .NET events, other asynchronous data sources exist in .NET. One of them is the asynchronous method pattern. In this design pattern, two methods are provided. One method (usually named BeginX) is used to start the computation and returns an IAsyncResult handle that's passed to the second method (usually named EndX), which then retrieves the result of the computation. Completion is usually signaled by implementing an AsyncCallback delegate or polling IAsyncResult.IsCompleted. Code adhere to this pattern is often difficult to read and maintain. In this topic, we will show how to use Rx factory methods to convert such asynchronous data sources to observable sequences.

## Converting Async Patterns to Observable Sequences

Many asynchronous methods in .NET are written with signatures like BeginX and EndX where X is the method name that is being executed asynchronously. BeginX takes arguments to execute the method, an AsyncCallback which is an action that takes an IAsyncResult and returns nothing, and finally an object state. EndX takes the IAsyncResult which is passed in from the AsyncCallback to retrieve the value of the asynchronous call.

The FromAsyncPattern operator of the [Observable](hh244252\(v=vs.103\).md) type wraps the Begin and End methods (which are being passed as parameters to the operator), and returns a function that takes the same parameters as Begin and returns an observable. This observable represents a sequence that publishes a single value, which is the asynchronous result of the call you just specified.

In the following example, we will convert BeginRead and EndRead for a [Stream](https://msdn.microsoft.com/en-us/library/8f86tw9e) object which uses the IAsyncResult pattern to a function that returns an observable sequence. For the generic parameters of the FromAsyncPattern operator, we specify the types of the arguments of **BeginRead** up to the callback. Since the EndRead method returns a value, we append this type as the final generic parameter for FromAsyncPattern. If you hover over `var` for `read`, you will notice that the return value of FromAsyncPattern is a function delegate that has the following signature:  `Func<byte[], int32,int32, IObservable<int32>>`, which means that this function takes 3 parameters (the same ones for BeginRead) and returns an IObservable\<Int32\>. This IObservable contains one value, which is the integer returned by EndRead, and contains the number of bytes read from the stream, between zero (0) and the number of bytes you requested. Since we now get an IObservable instead of an IAsyncResult, we can use all the LINQ operators available to Observables and subscribe, parse or compose it.

```csharp
using Stream inputStream = Console.OpenStandardInput();
var read = Observable.FromAsyncPattern<byte[], int, int, int>(inputStream.BeginRead, inputStream.EndRead);
byte[] someBytes = new byte[10];
IObservable<int> source = read(someBytes, 0, 10);
IDisposable subscription =
    source.Subscribe(
                            value => WriteLine($"OnNext: {value}"),
    ex => WriteLine($"OnError: {ex.Message}"),
    () => WriteLine("OnCompleted"));
Console.ReadKey();
```
