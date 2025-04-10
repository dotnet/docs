---
title: "Breaking change - System.Linq.AsyncEnumerable in .NET 10"
description: "Learn about the breaking change in .NET 10 where the AsyncEnumerable class is now included."
ms.date: 2/21/2025
ai-usage: ai-assisted
ms.custom: https://github.com/dotnet/docs/issues/44886
---

# System.Linq.AsyncEnumerable in .NET 10

.NET 10 introduces the <xref:System.Linq.AsyncEnumerable> class, which provides a full set of LINQ extension methods for the <xref:System.Collections.Generic.IAsyncEnumerable`1> type. This class replaces the [community-maintained `System.Linq.Async` NuGet library](https://www.nuget.org/packages/System.Linq.Async), potentially causing compilation errors due to ambiguities.

## Version introduced

.NET 10 Preview 1

## Previous behavior

The `AsyncEnumerable` class in the [community-maintained `System.Linq.Async` package](https://www.nuget.org/packages/System.Linq.Async) provided LINQ support for <xref:System.Collections.Generic.IAsyncEnumerable`1>.

## New behavior

The <xref:System.Linq.AsyncEnumerable> class in .NET 10, and in the [`System.Linq.AsyncEnumerable` NuGet package](https://www.nuget.org/packages/System.Linq.AsyncEnumerable/), provides LINQ support for <xref:System.Collections.Generic.IAsyncEnumerable`1>.

## Type of breaking change

This is a [source incompatible](../../categories.md#source-compatibility) change.

## Reason for change

<xref:System.Collections.Generic.IAsyncEnumerable`1> is a commonly used interface, so the platform itself should provide LINQ support for the type. Maintainers of `System.Linq.Async` and other community members petitioned for inclusion directly in the platform.

## Recommended action

If upgrading to .NET 10 and the code includes a direct package reference to `System.Linq.Async`, remove that package reference. For multitargeting both .NET 10 and previous versions, add a package reference to `System.Linq.AsyncEnumerable` instead.

If `System.Linq.Async` is consumed indirectly via another package, avoid ambiguity errors by including this in the project:

```xml
<PackageReference Include="System.Linq.Async" Version="6.0.1">
  <ExcludeAssets>all</ExcludeAssets>
</PackageReference>
```

Most consuming code should be compatible without changes, but some call sites might need updates to refer to newer names and signatures.

Refer to the [System.Linq.AsyncEnumerable API documentation](xref:System.Linq.AsyncEnumerable) for the full set of LINQ extension methods available for <xref:System.Collections.Generic.IAsyncEnumerable`1>.

## Affected APIs

- <xref:System.Linq.AsyncEnumerable?displayProperty=fullName>
- <xref:System.Collections.Generic.IAsyncEnumerable`1?displayProperty=fullName>
- [System.Linq.Async package](https://www.nuget.org/packages/System.Linq.Async) (community-maintained)
