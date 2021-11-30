---
title: "Primitives: the extensions library for .NET"
description: Learn about the various primitive types from the Microsoft.Extensions.Primitives library.
author: IEvangelist
ms.author: dapine
ms.date: 11/12/2021
---

# Primitives: The extensions library for .NET

In this article, you'll learn about the [Microsoft.Extensions.Primitives](/dotnet/api/microsoft.extensions.primitives) library. The primitives in this article are *not* to be confused with .NET primitive types from the BCL, or that of the C# language. Instead, the types within the primitives library serve as building blocks for some of the peripheral .NET NuGet packages, such as:

- [`Microsoft.Extensions.Configuration`](https://www.nuget.org/packages/Microsoft.Extensions.Configuration)
- [`Microsoft.Extensions.Configuration.FileExtensions`](https://www.nuget.org/packages/Microsoft.Extensions.Configuration.FileExtensions)
- [`Microsoft.Extensions.FileProviders.Composite`](https://www.nuget.org/packages/Microsoft.Extensions.FileProviders.Composite)
- [`Microsoft.Extensions.FileProviders.Physical`](https://www.nuget.org/packages/Microsoft.Extensions.FileProviders.Physical)
- [`Microsoft.Extensions.Logging.EventSource`](https://www.nuget.org/packages/Microsoft.Extensions.Logging.EventSource)
- [`Microsoft.Extensions.Options`](https://www.nuget.org/packages/Microsoft.Extensions.Options)
- [`System.Text.Json`](https://www.nuget.org/packages/System.Text.Json)

## Change notifications

Propagating notifications when a change occurs is a fundamental concept in programming. The observed state of an object more often than not can change. When change occurs, implementations of the <xref:Microsoft.Extensions.Primitives.IChangeToken?displayProperty=fullName> interface can be used to notify interested parties of said change. The implementations available are as follows:

- <xref:Microsoft.Extensions.Primitives.CancellationChangeToken>
- <xref:Microsoft.Extensions.Primitives.CompositeChangeToken>

As a developer, you're also free to implement your own type. The <xref:Microsoft.Extensions.Primitives.IChangeToken> interface defines a few properties:

- <xref:Microsoft.Extensions.Primitives.IChangeToken.HasChanged?displayProperty=nameWithType>: Gets a value that indicates if a change has occurred.
- <xref:Microsoft.Extensions.Primitives.IChangeToken.ActiveChangeCallbacks?displayProperty=nameWithType>: Indicates if the token will proactively raise callbacks. If `false`, the token consumer must poll `HasChanged` to detect changes.

## Instance-based functionality

Consider the following example usage of the `CancellationChangeToken`:

:::code source="./snippets/primitives/change/Example.Cancellation.cs" id="Cancellation":::

In the preceding example, a <xref:System.Threading.CancellationTokenSource> is instantiated and its <xref:System.Threading.CancellationTokenSource.Token%2A> is passed to the <xref:Microsoft.Extensions.Primitives.CancellationChangeToken.%23ctor%2A> constructor. The initial state of `HasChanged` is written to the console. An `Action<object?> callback` is created that writes when the callback is invoked to the console. The token's <xref:Microsoft.Extensions.Primitives.CancellationChangeToken.RegisterChangeCallback(System.Action{System.Object},System.Object)> method is called, given the `callback`. Within the `using` statement, the `cancellationTokenSource` is cancelled. This triggers the callback, and the state of `HasChanged` is again written to the console.

When you need to take action from multiple sources of change, use the <xref:Microsoft.Extensions.Primitives.CompositeChangeToken>. This implementation aggregates one or more change tokens and fires each registered callback exactly one time regardless of the number of times a change is triggered. Consider the following example:

:::code source="./snippets/primitives/change/Example.Composites.cs" id="Composites":::

In the preceding C# code, three <xref:System.Threading.CancellationTokenSource> objects instances are created and paired with corresponding <xref:Microsoft.Extensions.Primitives.CancellationChangeToken> instances. The composite token is instantiated by passing an array of the tokens to the <xref:Microsoft.Extensions.Primitives.CompositeChangeToken.%23ctor%2A> constructor. The `Action<object?> callback` is created, but this time the `state` object is used and written to console as a formatted message. The callback is registered four times, each with a slightly different state object argument. The code uses a pseudo-random number generator to pick one of the change token sources (doesn't matter which one) and call its <xref:System.Threading.CancellationTokenSource.Cancel> method. This triggers the change, invoking each registered callback exactly once.

## Alternative `static` approach

As an alternative to calling `RegisterChangeCallback`, you could use the <xref:Microsoft.Extensions.Primitives.ChangeToken?displayProperty=nameWithType> static class. Consider the following consumption pattern:

:::code source="./snippets/primitives/change/Example.Static.cs" id="Static":::

Much like previous examples, you'll need an implementation of `IChangeToken` that is produced by the `changeTokenProducer`. The producer is defined as a `Func<IChangeToken>` and it's expected that this will return a new token every invocation. The `consumer` is either an `Action` when not using `state`, or an `Action<TState>` where the generic type `TState` flows through the change notification.

## String tokenizers, segments, and values

Interacting with strings is commonplace in application development. Various representations of strings are parsed, split, or iterated over. The primitives library offers a few choice types that help to make interacting with strings more optimized and efficient. Consider the following types:

- <xref:Microsoft.Extensions.Primitives.StringSegment>: An optimized representation of a substring.
- <xref:Microsoft.Extensions.Primitives.StringTokenizer>: Tokenizes a `string` into `StringSegment` instances.
- <xref:Microsoft.Extensions.Primitives.StringValues>: Represents `null`, zero, one, or many strings in an efficient way.

### The `StringSegment` type

In this section, you'll learn about an optimized representation of a substring known as the <xref:Microsoft.Extensions.Primitives.StringSegment> `struct` type. Consider the following C# code example showing some of the `StringSegment` properties and the `AsSpan` method:

:::code source="./snippets/primitives/string/Example.Segment.cs" id="Segment":::

The preceding code instantiates the `StringSegment` given a `string` value, an `offset`, and a `length`. The <xref:Microsoft.Extensions.Primitives.StringSegment.Buffer?displayProperty=nameWithType> is the original string argument, and the <xref:Microsoft.Extensions.Primitives.StringSegment.Value?displayProperty=nameWithType> is the substring based on the <xref:Microsoft.Extensions.Primitives.StringSegment.Offset?displayProperty=nameWithType> and <xref:Microsoft.Extensions.Primitives.StringSegment.Length?displayProperty=nameWithType> values.

The `StringSegment` struct provides [many methods](/dotnet/api/microsoft.extensions.primitives.stringsegment#methods) for interacting with the segment.

### The `StringTokenizer` type

The <xref:Microsoft.Extensions.Primitives.StringTokenizer> object is a struct type that tokenizes a `string` into `StringSegment` instances. The tokenization of large strings usually involves splitting the string apart and iterating over it. With that said, <xref:System.String.Split%2A?displayProperty=nameWithType> probably comes to mind. These APIs are similar, but in general, <xref:Microsoft.Extensions.Primitives.StringTokenizer> provides better performance. First, consider the following example:

:::code source="./snippets/primitives/string/Example.Tokenizer.cs" id="Tokenizer":::

In the preceding code, an instance of the `StringTokenizer` type is created given 900 auto-generated paragraphs of :::no-loc text="Lorem Ipsum"::: text and an array with a single value of a white-space character `' '`. Each value within the tokenizer is represented as a `StringSegment`. The code iterates the segments, allowing the consumer to interact with each `segment`.

#### Benchmark comparing `StringTokenizer` to `string.Split`

With the various ways of slicing and dicing strings, it feels appropriate to compare two methods with a benchmark. Using the [BenchmarkDotNet](https://www.nuget.org/packages/BenchmarkDotNet) NuGet package, consider the following two benchmark methods:

1. **Using <xref:Microsoft.Extensions.Primitives.StringTokenizer>**:

    :::code source="./snippets/primitives/string/Example.Tokenizer.cs" id="TokenizerBenchmark":::

1. **Using <xref:System.String.Split%2A?displayProperty=nameWithType>**:

    :::code source="./snippets/primitives/string/Example.Tokenizer.cs" id="SplitBenchmark":::

Both methods look similar on the API surface area, and they're both capable of splitting a large string into chunks. The benchmark results below show that the `StringTokenizer` approach is nearly three times faster, but *results may vary*. As with all performance considerations, you should evaluate your specific use case.

| Method      | Mean      | Error     | Standard deviation | Median    | Ratio | Ratio standard deviation |
|-------------|----------:|----------:|-------------------:|----------:|------:|-------------------------:|
| `Tokenizer` | 6.306 ms  | 0.1481 ms | 0.4179 ms          | 6.175 ms  | 0.37  | 0.04                     |
| `Split`     | 16.966 ms | 0.6164 ms | 1.8079 ms          | 16.862 ms | 1.00  | 0.00                     |

***Legend***

- Mean: Arithmetic mean of all measurements
- Error: Half of 99.9% confidence interval
- Standard deviation: Standard deviation of all measurements
- Median: Value separating the higher half of all measurements (50th percentile)
- Ratio: Mean of the ratio distribution (Current/Baseline)
- Ratio standard deviation: Standard deviation of the ratio distribution (Current/Baseline)
- 1 ms: 1 Millisecond (0.001 sec)

For more information on benchmarking with .NET, see [BenchmarkDotNet](https://dotnetfoundation.org/projects/benchmarkdotnet).

### The `StringValues` type

The <xref:Microsoft.Extensions.Primitives.StringValues> object is a `struct` type that represents `null`, zero, one, or many strings in an efficient way. The `StringValues` type can be constructed with either of the following syntaxes: `string?` or `string?[]?`. Using the text from the previous example, consider the following C# code:

:::code source="./snippets/primitives/string/Example.StringValues.cs" id="StringValues":::

The preceding code instantiates a `StringValues` object given an array of string values. The <xref:Microsoft.Extensions.Primitives.StringValues.Count?displayProperty=nameWithType> is written the console.

The `StringValues` type is an implementation of the following collection types:

- `IList<string>`
- `ICollection<string>`
- `IEnumerable<string>`
- `IEnumerable`
- `IReadOnlyList<string>`
- `IReadOnlyCollection<string>`

As such, it can be iterated over and each `value` can be interacted with as needed.

## See also

- [Options pattern in .NET](options.md)
- [Configuration in .NET](configuration.md)
- [Logging providers in .NET](logging-providers.md)
