---
title: "Breaking change: Inline array struct size limit is enforced"
description: Learn about the .NET 9 breaking change in core .NET libraries where the size limit for inline arrays is now enforced.
ms.date: 02/09/2024
---
# Inline array struct size limit is enforced

The <xref:System.Runtime.CompilerServices.InlineArrayAttribute> attribute was introduced in .NET 8 to annotate struct types that have a single field. Inline array structs were intended to have a size limit of 1 mebibyte (MiB). However, due to a bug, the limit wasn't enforced for inline array structs that have a sequential layout, which is also the default layout as emitted by C#. This change enforces the size limit.

## Previous behavior

In .NET 8, you could declare an inline array struct with any positive, non-zero size. In extreme cases, the effective size was unpredictable. For example, a struct whose size was declared as `Int32.MaxValue + 1` ended up having a size of 1 due to wrap-around.

## New behavior

Starting in .NET 9, the size limit of 1 MiB is enforced.

## Version introduced

.NET 9 Preview 1

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

This change fixes a bug in the implementation where the size limit wasn't enforced.

## Recommended action

If you have code that uses inline array structs with very large instances that exceed the limit, reduce the size of these structs.

## Affected APIs

- <xref:System.Runtime.CompilerServices.InlineArrayAttribute?displayProperty=fullName>
