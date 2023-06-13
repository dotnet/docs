---
title: ".NET 8 breaking change: IndexOfAnyValues renamed to SearchValues"
description: Learn about the .NET 8 breaking change in core .NET libraries where the IndexOfAnyValues type was renamed to SearchValues.
ms.date: 06/05/2023
---
# IndexOfAnyValues renamed to SearchValues

.NET 8 Preview 1 introduced a new `System.Buffers.IndexOfAnyValues<T>` type to speed up `IndexOfAny`-like operations. In .NET 8 Preview 5, the type has been renamed to <xref:System.Buffers.SearchValues%601>.

## Previous behavior

In previous preview versions of .NET 8, the affected types were named `IndexOfAnyValues` and `System.Buffers.IndexOfAnyValues<T>`.

## New behavior

`IndexOfAnyValues` and `System.Buffers.IndexOfAnyValues<T>` are now named <xref:System.Buffers.SearchValues> and <xref:System.Buffers.SearchValues%601>.

## Version introduced

.NET 8 Preview 5

## Type of breaking change

This change can affect [source compatibility](../../categories.md#source-compatibility) and [binary compatibility](../../categories.md#binary-compatibility).

## Reason for change

The type was renamed to `SearchValues` to allow us to extend its functionality in the future without making the name of the type misleading. `IndexOfAnyValues` was introduced in a previous preview version of .NET 8 as a way to cache computation associated with preparing any number of values for use in a search. We expected to only use it with `IndexOfAny` and possibly `Contains`. However, there are other places that could benefit from exposing overloads of other operations that would take an `IndexOfAnyValues`, like `Count`, `Replace`, or `Remove`, and in those contexts, the `IndexOfAnyValues` name doesn't make sense.

## Recommended action

If you've written code using `IndexOfAnyValues` in a previous preview version of .NET 8, replace all usages with `SearchValues`.
This should be as simple as a text-based find-and-replace of "IndexOfAnyValues" with "SearchValues".

## Affected APIs

- `System.Buffers.IndexOfAnyValues<T>`
- `System.Buffers.IndexOfAnyValues.Create()`
- `System.MemoryExtensions.IndexOfAny<T>(ReadOnlySpan<T>, IndexOfAnyValues<T>)`
- `System.MemoryExtensions.IndexOfAny<T>(Span<T>, IndexOfAnyValues<T>)`
- `System.MemoryExtensions.IndexOfAnyExcept<T>(ReadOnlySpan<T>, IndexOfAnyValues<T>)`
- `System.MemoryExtensions.IndexOfAnyExcept<T>(Span<T>, IndexOfAnyValues<T>)`
