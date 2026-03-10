---
title: "Breaking change - System.Linq.AsyncEnumerable in .NET 10"
description: "Learn about the breaking change in .NET 10 where the AsyncEnumerable class is now included."
ms.date: 12/11/2025
ai-usage: ai-assisted
ms.custom: https://github.com/dotnet/docs/issues/44886
---

# System.Linq.AsyncEnumerable in .NET 10

.NET 10 introduces the <xref:System.Linq.AsyncEnumerable> class, which provides a full set of LINQ extension methods for the <xref:System.Collections.Generic.IAsyncEnumerable`1> type. This class replaces the [community-maintained `System.Linq.Async` NuGet library](https://www.nuget.org/packages/System.Linq.Async), potentially causing compilation errors due to ambiguities.

## Version introduced

.NET 10

## Previous behavior

Previously, the `AsyncEnumerable` class in the [community-maintained `System.Linq.Async` package](https://www.nuget.org/packages/System.Linq.Async) provided LINQ support for <xref:System.Collections.Generic.IAsyncEnumerable`1>.

## New behavior

The <xref:System.Linq.AsyncEnumerable> class in .NET 10, and in the [`System.Linq.AsyncEnumerable` NuGet package](https://www.nuget.org/packages/System.Linq.AsyncEnumerable/), provides LINQ support for <xref:System.Collections.Generic.IAsyncEnumerable`1>.

## Type of breaking change

This change can affect [source compatibility](../../categories.md#source-compatibility).

## Reason for change

<xref:System.Collections.Generic.IAsyncEnumerable`1> is a commonly used interface, so the platform itself should provide LINQ support for the type. Maintainers of `System.Linq.Async` and other community members petitioned for inclusion directly in the platform.

## Recommended action

If you're upgrading to .NET 10 and your code includes a direct package reference to `System.Linq.Async`, remove that package reference or [upgrade to version 7.0.0](https://endjin.com/blog/2025/11/ix-v7-dotnet-10-linq-iasyncenumerable). For multitargeting both .NET 10 and a previous version, add a package reference to `System.Linq.AsyncEnumerable` instead.

If `System.Linq.Async` is consumed indirectly via another package, avoid ambiguity errors by adding `<ExcludeAssets>` metadata with a value of `compile` or `all`:

- To allow transitive use of `System.Linq.Async`, set `<ExcludeAssets>` to `compile`:

  ```xml
  <PackageReference Include="System.Linq.Async" Version="6.0.1">
    <ExcludeAssets>compile</ExcludeAssets>
  </PackageReference>
  ```

  This configuration prevents direct usage in your code while allowing other packages to continue using System.Linq.Async internally.

- For complete exclusion, set `<ExcludeAssets>` to `all`:

  ```xml
  <PackageReference Include="System.Linq.Async" Version="6.0.1">
    <ExcludeAssets>all</ExcludeAssets>
  </PackageReference>
  ```

  Use this configuration only if you're certain no dependencies require System.Linq.Async at runtime.

Most consuming code should be compatible without changes, but some call sites might need updates to refer to newer names and signatures. For example, a `Select` call like `e.Select(i => i * 2)` works the same before and after. However, the call `e.SelectAwait(async (int i, CancellationToken ct) => i * 2)` needs to be changed to use `Select` instead of `SelectAwait`, as in `e.Select(async (int i, CancellationToken ct) => i * 2)`.

For the full set of LINQ extension methods available for <xref:System.Collections.Generic.IAsyncEnumerable`1>, see the [System.Linq.AsyncEnumerable API documentation](xref:System.Linq.AsyncEnumerable).

## Affected APIs

- <xref:System.Linq.AsyncEnumerable?displayProperty=fullName>
- <xref:System.Collections.Generic.IAsyncEnumerable`1?displayProperty=fullName>
- [System.Linq.Async package](https://www.nuget.org/packages/System.Linq.Async) (community-maintained)
- [Ix.NET v7.0: .NET 10 and LINQ for IAsyncEnumerable\<T>](https://endjin.com/blog/2025/11/ix-v7-dotnet-10-linq-iasyncenumerable)
