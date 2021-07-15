---
title: Pagination with the Azure SDK for .NET
description: Learn how to use pagination with the Azure SDK for .NET
ms.date: 07/14/2021
ms.custom: devx-track-dotnet
ms.author: dapine
author: IEvangelist
---

# Pagination with the Azure SDK for .NET

In this article, you'll learn how to use the Azure SDK for .NET pagination functionality to work efficiently and productively with large data sets. Pagination is the act of dividing returned data into pages, making it easier for the consumer to iterate through smaller amounts of data. Starting with C# 8, you can create and consume streams asynchronously using [Asynchronous streams](../../csharp/whats-new/csharp-8.md#asynchronous-streams).

All of the samples in this article rely on the following NuGet packages:

- [Azure.Security.KeyVault.Secrets][azure-key-vault]
- [Microsoft.Extensions.Azure][ms-ext-azure]
- [Microsoft.Extensions.Hosting][ms-ext-hosting]
- [System.Linq.Async][system-linq-async]

[azure-key-vault]: https://www.nuget.org/packages/Azure.Security.KeyVault.Secrets
[ms-ext-azure]: https://www.nuget.org/packages/Microsoft.Extensions.Azure
[ms-ext-hosting]: https://www.nuget.org/packages/Microsoft.Extensions.Hosting
[system-linq-async]: https://www.nuget.org/packages/System.Linq.Async

For the latest listing of Azure SDK for .NET, see [Azure SDK latest releases](packages.md#all-libraries).

## Pageable return types

Clients instantiated from the Azure SDK for .NET can return the following pageable types:

| Type                                               | Description                                              |
|----------------------------------------------------|----------------------------------------------------------|
| [`Pageable<T>`](xref:Azure.Pageable%601)           | A collection of values retrieved in pages                |
| [`AsyncPageable<T>`](xref:Azure.AsyncPageable%601) | A collection of values asynchronously retrieved in pages |

## Iterate over `AsyncPageable` with `await foreach`

To iterate over an `AsyncPageable<T>` using the [`await foreach`](/dotnet/csharp/language-reference/proposals/csharp-8.0/async-streams#foreach) syntax, consider the following example:

:::code source="snippets/pagination/Program.cs" range="45-53":::

In the preceding C# code:

- The <xref:Azure.Security.KeyVault.Secrets.SecretClient.GetPropertiesOfSecretsAsync%2A?displayProperty=nameWithType> method is invoked, and returns an `AsyncPageable<SecretProperties>` object.
- In an `await foreach` loop, each `SecretProperties` is asynchronously yielded.
- As each `secret` is materialized, it's `Name` is written to the console.

## Iterate over `AsyncPageable` with while

To iterate over an `AsyncPageable<T>` when the `await foreach` syntax isn't available, use a `while` loop.

:::code source="snippets/pagination/Program.cs" range="55-72":::

In the preceding C# code:

- The <xref:Azure.Security.KeyVault.Secrets.SecretClient.GetPropertiesOfSecretsAsync%2A?displayProperty=nameWithType> method is invoked, and returns an `AsyncPageable<SecretProperties>` object.
- The <xref:Azure.AsyncPageable%601.GetAsyncEnumerator%2A?displayProperty=nameWithType> method is invoked, returning an `IAsyncEnumerator<SecretProperties>`.
- The <xref:System.Collections.Generic.IAsyncEnumerator%601.MoveNextAsync> method is invoked repeatedly until there are no items to return.

## Iterate over `AsyncPageable` pages

If you want to have control over receiving pages of values from the service use [`AsyncPageable<T>.AsPages`](xref:Azure.AsyncPageable%601.AsPages%2A) method:

:::code source="snippets/pagination/Program.cs" range="74-88":::

In the preceding C# code:

- The <xref:Azure.Security.KeyVault.Secrets.SecretClient.GetPropertiesOfSecretsAsync%2A?displayProperty=nameWithType> method is invoked, and returns an `AsyncPageable<SecretProperties>` object.
- The <xref:Azure.AsyncPageable%601.AsPages%2A?displayProperty=nameWithType> method is invoked, and returns an `IAsyncEnumerable<Page<SecretProperties>>`.
- Each page is iterated over asynchronously, using `await foreach`.
- Each page has a set of <xref:Azure.Page%601.Values?displayProperty=nameWithType>, which represents an `IReadOnlyList<T>` which are iterated over with non-async `foreach`.
- Each page also contains a <xref:Azure.Page%601.ContinuationToken?displayProperty=nameWithType> which can be used to request the next page.

## Use `System.Linq.Async` with `AsyncPageable`

The [`System.Linq.Async`](https://www.nuget.org/packages/System.Linq.Async) package provides a set of LINQ methods that operate on <xref:System.Collections.Generic.IAsyncEnumerable%601> type. Because `AsyncPageable<T>` implements [`IAsyncEnumerable<T>`](xref:System.Collections.Generic.IAsyncEnumerable%601) you can use `System.Linq.Async` to easily query and transform the data.

### Convert to a `List<T>`

Use `ToListAsync` to convert an `AsyncPageable<T>` to a `List<T>`. This might make several service calls if the data isn't returned in a single page.

:::code source="snippets/pagination/Program.cs" range="90-96":::

In the preceding C# code:

- The <xref:Azure.Security.KeyVault.Secrets.SecretClient.GetPropertiesOfSecretsAsync%2A?displayProperty=nameWithType> method is invoked, and returns an `AsyncPageable<SecretProperties>` object.
- The `ToListAsync` method is awaited, which materializes a new `List<SecretProperties>` instance.

### Take the first N elements

`Take` can be used to get only the first `N` elements of the `AsyncPageable`. Using `Take` will make the fewest service calls required to get `N` items.

:::code source="snippets/pagination/Program.cs" range="98-105":::

### As an observable sequence

Asynchronous streams are pull-based, meaning as their items are iterated over the next available item is pulled. This is in juxtaposition with the observable-pattern, which is push-based. The `System.Linq.Async` package provides the `ToObservable` extension method that lets you convert an `IAsyncEnumerable<T>` to an [`IObservable<T>`](xref:System.IObservable%601).

Imagine a simple `IObserver<SecretProperties>` implemenation:

:::code source="snippets/pagination/Program.cs" range="127-133":::

You could consume the `ToObservable` extension method as follows:

:::code source="snippets/pagination/Program.cs" range="118-125":::

### More methods

`System.Linq.Async` provides other useful methods like `Select`, `Where`, `OrderBy`, `GroupBy`, etc. that provide functionality equivalent to their synchronous [`Enumerable` counterparts](https://docs.microsoft.com/dotnet/api/system.linq.enumerable).

### Beware client-side evaluation

When using the `System.Linq.Async` package, beware that LINQ operations are executed on the client. The following query would fetch *all* the items just to count them:

```csharp
// DANGER! DO NOT COPY: CountAsync as used here fetches all the secrets locally to count them.
int expensiveSecretCount = await client.GetPropertiesOfSecretsAsync().CountAsync();
```

> [!WARNING]
> The same warning applies to operators like `Where`. Always prefer server-side filtering, aggregation, or projections of data if available.

## Iterate over pageable

`Pageable<T>` is a synchronous version of `AsyncPageable<T>`, it can be used with a normal `foreach` loop.

:::code source="snippets/pagination/Program.cs" range="108-116":::

## See also

- [Dependency injection with the Azure SDK for .NET](dependency-injection.md)
- [Thread safety and client lifetime management for Azure SDK objects](thread-safety.md)
- [`System.Linq.Async`](https://www.nuget.org/packages/System.Linq.Async)
