---
title: Pagination with the Azure SDK for .NET
description: Learn how to use pagination with the Azure SDK for .NET.
ms.date: 07/15/2021
ms.custom: devx-track-dotnet
ms.author: dapine
author: IEvangelist
---

# Pagination with the Azure SDK for .NET

In this article, you'll learn how to use the Azure SDK for .NET pagination functionality to work efficiently and productively with large data sets. Pagination is the act of dividing large data sets into pages, making it easier for the consumer to iterate through smaller amounts of data. Starting with C# 8, you can create and consume streams asynchronously using [Asynchronous (async) streams](../../csharp/whats-new/csharp-8.md#asynchronous-streams). Async streams are based on the <xref:System.Collections.Generic.IAsyncEnumerable%601> interface. The Azure SDK for .NET exposes an implementation of `IAsyncEnumerable<T>` with its `AsyncPageable<T>` class.

All of the samples in this article rely on the following NuGet packages:

- [Azure.Security.KeyVault.Secrets][azure-key-vault]
- [Microsoft.Extensions.Azure][ms-ext-azure]
- [Microsoft.Extensions.Hosting][ms-ext-hosting]
- [System.Linq.Async][system-linq-async]

[azure-key-vault]: https://www.nuget.org/packages/Azure.Security.KeyVault.Secrets
[ms-ext-azure]: https://www.nuget.org/packages/Microsoft.Extensions.Azure
[ms-ext-hosting]: https://www.nuget.org/packages/Microsoft.Extensions.Hosting
[system-linq-async]: https://www.nuget.org/packages/System.Linq.Async

For the latest directory of Azure SDK for .NET packages, see [Azure SDK latest releases](packages.md#all-libraries).

## Pageable return types

Clients instantiated from the Azure SDK for .NET can return the following pageable types.

| Type                                               | Description                                              |
|----------------------------------------------------|----------------------------------------------------------|
| [`Pageable<T>`](xref:Azure.Pageable%601)           | A collection of values retrieved in pages                |
| [`AsyncPageable<T>`](xref:Azure.AsyncPageable%601) | A collection of values asynchronously retrieved in pages |

Most of the samples in this article are asynchronous, using variations of the `AsyncPageable<T>` type. Using asynchronous programming for I/O-bound operations is ideal. A perfect use case is using the async APIs from the Azure SDK for .NET as these operations represent HTTP/S network calls.

## Iterate over `AsyncPageable` with `await foreach`

To iterate over an `AsyncPageable<T>` using the [`await foreach`](/dotnet/csharp/language-reference/proposals/csharp-8.0/async-streams#foreach) syntax, consider the following example:

:::code source="snippets/pagination/Program.cs" range="45-53":::

In the preceding C# code:

- The <xref:Azure.Security.KeyVault.Secrets.SecretClient.GetPropertiesOfSecretsAsync%2A?displayProperty=nameWithType> method is invoked and returns an `AsyncPageable<SecretProperties>` object.
- In an `await foreach` loop, each `SecretProperties` is asynchronously yielded.
- As each `secret` is materialized, its `Name` is written to the console.

## Iterate over `AsyncPageable` with `while`

To iterate over an `AsyncPageable<T>` when the `await foreach` syntax isn't available, use a `while` loop.

:::code source="snippets/pagination/Program.cs" range="55-72":::

In the preceding C# code:

- The <xref:Azure.Security.KeyVault.Secrets.SecretClient.GetPropertiesOfSecretsAsync%2A?displayProperty=nameWithType> method is invoked, and returns an `AsyncPageable<SecretProperties>` object.
- The <xref:Azure.AsyncPageable%601.GetAsyncEnumerator%2A?displayProperty=nameWithType> method is invoked, returning an `IAsyncEnumerator<SecretProperties>`.
- The <xref:System.Collections.Generic.IAsyncEnumerator%601.MoveNextAsync> method is invoked repeatedly until there are no items to return.

## Iterate over `AsyncPageable` pages

If you want control over receiving pages of values from the service, use the [`AsyncPageable<T>.AsPages`](xref:Azure.AsyncPageable%601.AsPages%2A) method:

:::code source="snippets/pagination/Program.cs" range="74-88":::

In the preceding C# code:

- The <xref:Azure.Security.KeyVault.Secrets.SecretClient.GetPropertiesOfSecretsAsync%2A?displayProperty=nameWithType> method is invoked and returns an `AsyncPageable<SecretProperties>` object.
- The <xref:Azure.AsyncPageable%601.AsPages%2A?displayProperty=nameWithType> method is invoked and returns an `IAsyncEnumerable<Page<SecretProperties>>`.
- Each page is iterated over asynchronously, using `await foreach`.
- Each page has a set of <xref:Azure.Page%601.Values?displayProperty=nameWithType>, which represents an `IReadOnlyList<T>` that's iterated over with a synchronous `foreach`.
- Each page also contains a <xref:Azure.Page%601.ContinuationToken?displayProperty=nameWithType>, which can be used to request the next page.

## Use `System.Linq.Async` with `AsyncPageable`

The [`System.Linq.Async`](https://www.nuget.org/packages/System.Linq.Async) package provides a set of [LINQ](../../standard/linq/index.md) methods that operate on <xref:System.Collections.Generic.IAsyncEnumerable%601> type. Because `AsyncPageable<T>` implements [`IAsyncEnumerable<T>`](xref:System.Collections.Generic.IAsyncEnumerable%601), you can use `System.Linq.Async` to query and transform the data.

### Convert to a `List<T>`

Use `ToListAsync` to convert an `AsyncPageable<T>` to a `List<T>`. This method might make several service calls if the data isn't returned in a single page.

:::code source="snippets/pagination/Program.cs" range="90-96":::

In the preceding C# code:

- The <xref:Azure.Security.KeyVault.Secrets.SecretClient.GetPropertiesOfSecretsAsync%2A?displayProperty=nameWithType> method is invoked and returns an `AsyncPageable<SecretProperties>` object.
- The `ToListAsync` method is awaited, which materializes a new `List<SecretProperties>` instance.

### Take the first N elements

`Take` can be used to get only the first `N` elements of the `AsyncPageable`. Using `Take` will make the fewest service calls required to get `N` items.

:::code source="snippets/pagination/Program.cs" range="98-105":::

### More methods

`System.Linq.Async` provides other methods that provide functionality equivalent to their synchronous [`Enumerable` counterparts](xref:System.Linq.Enumerable). Examples of such methods include `Select`, `Where`, `OrderBy`, and `GroupBy`.

### Beware client-side evaluation

When using the `System.Linq.Async` package, beware that LINQ operations are executed on the client. The following query would fetch *all* the items just to count them:

```csharp
// DO NOT DO THIS! 😲
int expensiveSecretCount = await client.GetPropertiesOfSecretsAsync().CountAsync();
```

> [!WARNING]
> The same warning applies to operators like `Where`. Always prefer server-side filtering, aggregation, or projections of data if available.

## As an observable sequence

The [`System.Linq.Async`](https://www.nuget.org/packages/System.Linq.Async) package is primarily used to provide observer pattern capabilities over `IAsyncEnumerable<T>` sequences. Asynchronous streams are pull-based. As their items are iterated over, the next available item is *pulled*. This approach is in juxtaposition with the observer pattern, which is push-based. As items become available, they're *pushed* to subscribers who act as observers. The `System.Linq.Async` package provides the `ToObservable` extension method that lets you convert an `IAsyncEnumerable<T>` to an [`IObservable<T>`](xref:System.IObservable%601).

Imagine an `IObserver<SecretProperties>` implementation:

:::code source="snippets/pagination/Program.cs" range="127-133":::

You could consume the `ToObservable` extension method as follows:

:::code source="snippets/pagination/Program.cs" range="118-125":::

In the preceding C# code:

- The <xref:Azure.Security.KeyVault.Secrets.SecretClient.GetPropertiesOfSecretsAsync%2A?displayProperty=nameWithType> method is invoked and returns an `AsyncPageable<SecretProperties>` object.
- The `ToObservable()` method is called on the `AsyncPageable<SecretProperties>` instance, returning an `IObservable<SecretProperties>`.
- The `observable` is subscribed to, passing in the observer implementation, returning the subscription to the caller.
- The subscription is an `IDisposable`. When it's disposed, the subscription ends.

## Iterate over pageable

`Pageable<T>` is a synchronous version of `AsyncPageable<T>` that can be used with a normal `foreach` loop.

:::code source="snippets/pagination/Program.cs" range="108-116":::

> [!IMPORTANT]
> While this synchronous API is available, use the asynchronous API alternatives for a better experience.

## See also

- [Dependency injection with the Azure SDK for .NET](dependency-injection.md)
- [Thread safety and client lifetime management for Azure SDK objects](thread-safety.md)
- [`System.Linq.Async`](https://www.nuget.org/packages/System.Linq.Async)
- [Task-based asynchronous pattern](../../standard/asynchronous-programming-patterns/task-based-asynchronous-pattern-tap.md)
