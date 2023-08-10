---
title: ".NET 8 breaking change: Removed Boolean-based overloads of ToFrozenDictionary/ToFrozenSet"
description: Learn about the .NET 8 breaking change in core .NET libraries where the ToFrozenSet and ToFrozenDictionary overloads with a Boolean parameter have been removed.
ms.date: 08/01/2023
---
# Removed Boolean-based overloads of ToFrozenDictionary/ToFrozenSet

Overloads of <xref:System.Collections.Frozen.FrozenDictionary.ToFrozenDictionary%2A> and <xref:System.Collections.Frozen.FrozenSet.ToFrozenSet%2A> previously allowed for a Boolean `optimizeForReading` argument to be supplied. These overloads have been removed in .NET 8 Preview 7.

## Previous behavior

In .NET 8 Preview 1 through Preview 6, you could call overloads of <xref:System.Collections.Frozen.FrozenDictionary.ToFrozenDictionary%2A> and <xref:System.Collections.Frozen.FrozenSet.ToFrozenSet%2A> that had an `optimizeForReading` parameter. If you passed `true`, the implementations constructed instances of <xref:System.Collections.Frozen.FrozenDictionary%602> and <xref:System.Collections.Frozen.FrozenSet%601> that were optimized for performing lookups and reading data from the collections, at the expense of potentially much more time spent in the `ToFrozenDictionary()` and `ToFrozenSet()` calls.

## New behavior

Starting in .NET 8 Preview 7, the [affected overloads](#affected-apis) have been removed. Now all of the <xref:System.Collections.Frozen.FrozenDictionary.ToFrozenDictionary%2A> and <xref:System.Collections.Frozen.FrozenSet.ToFrozenSet%2A> overloads spend extra time to construct a collection that's optimized for reading.

## Version introduced

.NET 8 Preview 7

## Type of breaking change

This change can affect [binary compatibility](../../categories.md#binary-compatibility) and [source compatibility](../../categories.md#source-compatibility).

## Reason for change

Construction performance has been optimized such that it now no longer makes sense to differentiate modes. `ToFrozenDictionary()` and `ToFrozenSet()` now always produce implementations optimized for reading, regardless of which overload is used.

## Recommended action

If you called the overloads that had a Boolean parameter, remove the Boolean argument from the call site.

## Affected APIs

- `System.Collections.Frozen.FrozenDictionary.ToFrozenDictionary<TKey,TValue>(System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<TKey,TValue>>,System.Boolean)`
- `System.Collections.Frozen.FrozenDictionary.ToFrozenDictionary<TKey,TValue>(System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<TKey,TValue>>,System.Collections.Generic.IEqualityComparer<TKey,TValue>,System.Boolean)`
- `System.Collections.Frozen.FrozenSet.ToFrozenSet<TKey,TValue>(System.Collections.Generic.IEnumerable<TKey,TValue>,System.Boolean)`
- `System.Collections.Frozen.FrozenSet.ToFrozenSet<TKey,TValue>(System.Collections.Generic.IEnumerable<TKey,TValue>,System.Collections.Generic.IEqualityComparer<TKey,TValue>,System.Boolean)`
