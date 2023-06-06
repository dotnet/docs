---
title: ".NET 8 breaking change: IndexOfAnyValues renamed to SearchValues"
description: Learn about the .NET 8 breaking change in core .NET libraries where the IndexOfAnyValues type was renamed to SearchValues.
ms.date: 06/05/2023
---
# IndexOfAnyValues renamed to SearchValues

.NET 8 Preview 1 introduced a new <xref:System.Buffers.IndexOfAnyValues%601> type to speed up `IndexOfAny`-like operations. In .NET 8 Preview 5, the type has been renamed to `SearchValues<T>`.

## Previous behavior

The affected types were named <xref:System.Buffers.IndexOfAnyValues> and <xref:System.Buffers.IndexOfAnyValues%601>.

## New behavior

<xref:System.Buffers.IndexOfAnyValues> and <xref:System.Buffers.IndexOfAnyValues%601> are now named <xref:System.Buffers.SearchValues> and <xref:System.Buffers.SearchValues%601>.

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

- <xref:System.Buffers.IndexOfAnyValues%601?displayProperty=fullName>
- <xref:System.Buffers.IndexOfAnyValues.Create%2A?displayProperty=fullName>
- <xref:System.MemoryExtensions.IndexOfAny%60%601(System.ReadOnlySpan{%60%600},System.Buffers.IndexOfAnyValues{%60%600})?displayProperty=fullName>
- <xref:System.MemoryExtensions.IndexOfAny%60%601(System.Span{%60%600},System.Buffers.IndexOfAnyValues{%60%600})?displayProperty=fullName>
- <xref:System.MemoryExtensions.IndexOfAnyExcept%60%601(System.ReadOnlySpan{%60%600},System.Buffers.IndexOfAnyValues{%60%600})?displayProperty=fullName>
- <xref:System.MemoryExtensions.IndexOfAnyExcept%60%601(System.Span{%60%600},System.Buffers.IndexOfAnyValues{%60%600})?displayProperty=fullName>
