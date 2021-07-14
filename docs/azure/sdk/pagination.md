---
title: Pagination in async responses with the Azure SDK for .NET
description: 
ms.date: 07/14/2021
ms.custom: devx-track-dotnet
ms.author: dapine
author: IEvangelist
---

# Pagination in async responses with the Azure SDK for .NET

In this article, you'll learn how to use the Azure SDK for .NET pagination and iteration functionality to work efficiently and productively with large data sets. Starting with C# 8, you can create and consume streams asynchronously using [Asynchronous streams](../../csharp/whats-new/csharp-8.md#asynchronous-streams).

> [!IMPORTANT]
> This article applies to client libraries that use the most recent versions of the Azure SDK for .NET. To see if a library is supported, refer to the list of [Azure SDK latest releases](packages.md#all-libraries). If your application is using an older version of the Azure SDK client libraries, refer to specific instructions in the applicable service documentation.

## Pageable return types

Clients instantiated from the Azure SDK for .NET can return the following pageable types:

| Type                                               | Description                                              |
|----------------------------------------------------|----------------------------------------------------------|
| [`Pageable<T>`](xref:Azure.Pageable%601)           | A collection of values retrieved in pages                |
| [`AsyncPageable<T>`](xref:Azure.AsyncPageable%601) | A collection of values asynchronously retrieved in pages |

## Iterate over `AsyncPageable` with `await foreach`

To iterate over an `AsyncPageable<T>` using the [`await foreach`](/dotnet/csharp/language-reference/proposals/csharp-8.0/async-streams#foreach) syntax, consider the following example:

:::code source="snippets/pagination/Program.cs" range="44-52":::

In the preceding C# code:

- The <xref:Azure.Security.KeyVault.Secrets.SecretClient.GetPropertiesOfSecretsAsync%2A?displayProperty=nameWithType> method is invoked, and returns an `AsyncPageable<SecretProperties>` object.
- In an `await foreach` loop, each `SecretProperties` is asynchronously yielded.
- As each `secret` is materialized, it's `Name` is written to the console.

## Iterate over `AsyncPageable` with while

To iterate over an `AsyncPageable` when the `await foreach` syntax isn't available, use a `while` loop.

:::code source="snippets/pagination/Program.cs" range="54-71":::

In the preceding C# code:

- The <xref:Azure.Security.KeyVault.Secrets.SecretClient.GetPropertiesOfSecretsAsync%2A?displayProperty=nameWithType> method is invoked, and returns an `AsyncPageable<SecretProperties>` object.
- The <xref:Azure.AsyncPageable%601.GetAsyncEnumerator%2A?displayProperty=nameWithType> method is invoked, returning an `IAsyncEnumerator<SecretProperties>`.
- The <xref:System.Collections.Generic.IAsyncEnumerator%601.MoveNextAsync> method is invoked repeatedly until there are no items to return.

## Iterate over `AsyncPageable` pages

If you want to have control over receiving pages of values from the service use `AsyncPageable<T>.AsPages` method:

:::code source="snippets/pagination/Program.cs" range="73-87":::

## Use `System.Linq.Async` with `AsyncPageable`

The [`System.Linq.Async`](https://www.nuget.org/packages/System.Linq.Async) package provides a set of LINQ methods that operate on <xref:System.Collections.Generic.IAsyncEnumerable%601> type. Because `AsyncPageable<T>` implements `IAsyncEnumerable<T>` you can use `System.Linq.Async` to easily query and transform the data.

### Convert to a `List<T>`

`ToListAsync` can be used to convert an `AsyncPageable` to a `List<T>`. This might make several service calls if the data isn't returned in a single page.

:::code source="snippets/pagination/Program.cs" range="89-95":::

### Take the first N elements

`Take` can be used to get only the first `N` elements of the `AsyncPageable`. Using `Take` will make the fewest service calls required to get `N` items.

:::code source="snippets/pagination/Program.cs" range="97-104":::

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

:::code source="snippets/pagination/Program.cs" range="107-115":::

## See also

- [Dependency injection with the Azure SDK for .NET](dependency-injection.md)
- [Thread safety and client lifetime management for Azure SDK objects](thread-safety.md)
- [`System.Linq.Async`](https://www.nuget.org/packages/System.Linq.Async)
