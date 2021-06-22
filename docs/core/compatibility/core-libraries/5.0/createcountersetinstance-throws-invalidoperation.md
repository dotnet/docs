---
title: "Breaking change: CreateCounterSetInstance throws InvalidOperationException if instance already exists"
description: Learn about the .NET 5 breaking change in core .NET libraries where CounterSet.CreateCounterSetInstance throws a different exception if the counter already exists.
ms.date: 11/01/2020
---
# CounterSet.CreateCounterSetInstance now throws InvalidOperationException if instance already exists

Starting in .NET 5, <xref:System.Diagnostics.PerformanceData.CounterSet.CreateCounterSetInstance(System.String)?displayProperty=nameWithType> throws an <xref:System.InvalidOperationException> instead of an <xref:System.ArgumentException> if the counter set already exists.

## Change description

In .NET Framework and .NET Core 1.0 to 3.1, you can create an instance of the counter set by calling <xref:System.Diagnostics.PerformanceData.CounterSet.CreateCounterSetInstance%2A>. However, if the counter set already exists, the method throws an <xref:System.ArgumentException> exception.

In .NET 5 and later versions, when you call <xref:System.Diagnostics.PerformanceData.CounterSet.CreateCounterSetInstance%2A> and the counter set exists, an <xref:System.InvalidOperationException> exception is thrown.

## Version introduced

5.0

## Recommended action

If you catch <xref:System.ArgumentException> exceptions in your app when calling <xref:System.Diagnostics.PerformanceData.CounterSet.CreateCounterSetInstance%2A>, consider also catching <xref:System.InvalidOperationException> exceptions.

> [!NOTE]
> Catching <xref:System.ArgumentException> exceptions is not recommended.

## Affected APIs

- <xref:System.Diagnostics.PerformanceData.CounterSet.CreateCounterSetInstance%2A?displayProperty=fullName>

<!--

### Category

Core .NET libraries

### Affected APIs

- `M:System.Diagnostics.PerformanceData.CounterSet.CreateCounterSetInstance(System.String)`

-->
