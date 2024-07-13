---
title: "Breaking change: Default `Equals()` and `GetHashCode()` throw for types marked with `InlineArrayAttribute`"
description: Learn about the .NET 9 breaking change in core .NET libraries where the default implementations of `Equals()` and `GetHashCode()` throw an exception for types marked with `InlineArrayAttribute`.
ms.date: 07/10/2024
---
# Default `Equals()` and `GetHashCode()` throw for types marked with `InlineArrayAttribute`

The default behavior for <xref:System.ValueType.Equals(System.Object)> and <xref:System.ValueType.GetHashCode> on types marked with <xref:System.Runtime.CompilerServices.InlineArrayAttribute> is now to throw a <xref:System.NotSupportedException>. Library authors should override these two methods if they're expected to not throw.

## Previous behavior

Previously, the default implementations only used the placeholder `ref` field when computing equality or the hash code.

## New behavior

Starting in .NET 9, a <xref:System.NotSupportedException> is always thrown from the default implementations for <xref:System.ValueType.Equals(System.Object)> and <xref:System.ValueType.GetHashCode> when <xref:System.Runtime.CompilerServices.InlineArrayAttribute> is applied to a type.

## Version introduced

.NET 9 Preview 6

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

The current behavior is incorrect for both determining equality and computing the hash code, and users are led into a false sense of correctness when calling these functions.

## Recommended action

Library authors should implement both <xref:System.ValueType.Equals(System.Object)> and <xref:System.ValueType.GetHashCode> on all types marked with <xref:System.Runtime.CompilerServices.InlineArrayAttribute>.

## Affected APIs

- <xref:System.ValueType.Equals(System.Object)?displayProperty=fullName>
- <xref:System.ValueType.GetHashCode?displayProperty=fullName>
