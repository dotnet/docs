---
title: "Breaking change: Specifying explicit struct Size is now disallowed with InlineArray"
description: "Learn about the breaking change in .NET 10 where specifying explicit Size to a struct decorated with InlineArrayAttribute now throws TypeLoadException."
ms.date: 08/08/2025
ai-usage: ai-assisted
---

# Specifying explicit struct Size is now disallowed with InlineArray

Applying explicit `Size` to a struct decorated with <xref:System.Runtime.CompilerServices.InlineArrayAttribute> is ambiguous and now is not supported in the type loader. Previously, specifying explicit `Size` would result in implementation-specific behavior that might or might not match user expectations.

## Version introduced

.NET 10 Preview 7

## Previous behavior

Previously, specifying explicit `Size` would result in implementation-specific behavior that might or might not match user expectations.

## New behavior

Starting in .NET 10 Preview 7, creating instances of such structs and other uses will result in a <xref:System.TypeLoadException> being thrown.

## Type of breaking change

This change is a [binary incompatible](../../categories.md#binary-compatibility) change. Existing binaries might encounter a breaking change in behavior, such as failure to load or execute, and if so, require recompilation.

## Reason for change

Specifying `Size` for an inline array struct is ambiguous and any interpretation would contradict the specification.

## Recommended action

In the unlikely case where you need to specify explicit size either for the array element or for the whole inline array, introduce a struct wrapping the element type or the whole array type. In the layout of the wrapper, the `Size` can be specified accordingly and unambiguously.

## Affected APIs

- Type loader (affects types that were not originally rejected)
