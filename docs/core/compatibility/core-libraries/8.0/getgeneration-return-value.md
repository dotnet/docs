---
title: ".NET 8 breaking change: GC.GetGeneration might return Int32.MaxValue"
description: Learn about the .NET 8 breaking change in core .NET libraries where GC.GetGeneration might return Int32.MaxValue for certain object types.
ms.date: 05/02/2023
---
# GC.GetGeneration might return Int32.MaxValue

Starting in .NET 8, <xref:System.GC.GetGeneration%2A?displayProperty=nameWithType> might return <xref:System.Int32.MaxValue?displayProperty=nameWithType> for objects allocated on non-GC heaps (also referred as "frozen" heaps), where previously it returned 2. When and how the runtime allocates objects on non-GC heaps is an internal implementation detail. String literals, for example, are allocated on a non-GC heap, and the following method call might return <xref:System.Int32.MaxValue?displayProperty=nameWithType>.

```csharp
int gen = int GetGeneration("string");
```

## Previous behavior

Previously, <xref:System.GC.GetGeneration%2A?displayProperty=nameWithType> returned integer values in the range of 0-2.

## New behavior

Starting in .NET 8, <xref:System.GC.GetGeneration%2A?displayProperty=nameWithType> can return a value of 0, 1, 2, or <xref:System.Int32.MaxValue?displayProperty=nameWithType>.

## Version introduced

.NET 8 Preview 4

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

.NET introduced a new, non-GC kind of heap that's slightly different from the existing heaps, which are large object heap (LOH), small object heap (SOH), and pinned object heap (POH).

## Recommended action

Make sure you're not using the return value from `GC.GetGeneration()` as an array indexer or for anything else where <xref:System.Int32.MaxValue?displayProperty=nameWithType> is unexpected.

## Affected APIs

- <xref:System.GC.GetGeneration(System.Object)?displayProperty=fullName>
- <xref:System.GC.GetGeneration(System.WeakReference)?displayProperty=fullName>
