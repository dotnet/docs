---
title: "Breaking change: C# 14 overload resolution with span parameters"
description: Learn about the .NET 10 breaking change in core .NET libraries where overloads with span parameters are applicable in more scenarios.
ms.date: 01/30/2025
ai-usage: ai-assisted
---
# C# 14 overload resolution with span parameters

C# 14, which ships with .NET 10, introduces new [built-in span conversions and type inference rules](https://github.com/dotnet/csharplang/issues/7905). Those changes make overloads with span parameters applicable in more scenarios.

## Previous behavior

In C# 13 and earlier, an extension method taking a `ReadOnlySpan<T>` or `Span<T>` receiver was not applicable to a value of type `T[]`. Therefore, only non-span extension methods like the ones from the `System.Linq.Enumerable` class were usually bound inside Expression lambdas.

## New behavior

In C# 14 and later, methods with `ReadOnlySpan<T>` or `Span<T>` parameters can participate in type inference or be used as extension methods in more scenarios. This makes span-based methods like the ones from the `System.MemoryExtensions` class bind in more scenarios, including inside Expression lambdas where they will cause run-time exceptions when compiled with interpretation.

## Version introduced

.NET 10 Preview 1

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

The C# language feature allows simplified API design and usage (for example, one <xref:System.ReadOnlySpan`1> extension method can apply to both spans and arrays).

## Recommended action

If you need to continue using Expression interpretation, make sure the non-span overloads are bound, for example, by casting arguments to the exact types the method signature takes or calling the extension methods as explicit static invocations:

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

M((array, num) => array.Contains(num)); // fails, binds to MemoryExtensions.Contains
M((array, num) => ((IEnumerable<int>)array).Contains(num)); // ok, binds to Enumerable.Contains
M((array, num) => array.AsEnumerable().Contains(num)); // ok, binds to Enumerable.Contains
M((array, num) => Enumerable.Contains(array, num)); // ok, binds to Enumerable.Contains

void M(Expression<Func<int[], int, bool>> e) => e.Compile(preferInterpretation: true);
```

## Affected APIs

- <xref:System.Linq.Expressions.Expression`1.Compile*?displayProperty=fullName>
