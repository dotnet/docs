---
title: "Breaking change: Static virtual methods in interfaces"
description: Learn about the .NET 6.0 breaking change where `static` interface methods can now be marked `virtual`.
ms.date: 09/08/2021
---
# Static virtual methods in interfaces

.NET 6 is previewing a new feature where `static` interface methods can be marked as `virtual`. This feature involves several changes to the ECMA spec to allow intermediate language (IL) metadata patterns that were previously considered illegal. For more information, see [dotnet/runtime#49558](https://github.com/dotnet/runtime/issues/49558).

> [!NOTE]
> The feature is in preview, and it's possible that additional changes or support may be introduced between .NET 6 and a future version of .NET when the feature stabilizes.

## Old behavior

Static interface methods could not be marked as `virtual` and would be considered illegal IL.

## New behavior

Static interface methods can be marked as `virtual`. The implementation of these methods is provided by types that implement the interface.

Since this is a newly legal IL pattern, existing tooling may incorrectly process the associated metadata and have unexpected behavior. It's likely that tooling will encounter the new metadata pattern, because interfaces with `static virtual` methods now appear on the primitive types, for example, <xref:System.Int32?displayProperty=fullName>.

## Version introduced

6.0 Preview 7

## Type of breaking change

This change can affect [binary compatibility](../../categories.md#binary-compatibility).

## Reason for change

This change was introduced because there was no way to abstract over static members and write generalized code that applies across types that define those static members. This was particularly problematic for member kinds that only exist in a static form, notably operators. This feature allows generic algorithms over numeric types, represented by interface constraints that specify the presence of given operators.

## Recommended action

Update any tooling that consumes .NET binaries or C# source code to account for the new concept of `static virtual` interface methods, including those that now exist on the .NET primitive types.

## Affected APIs

N/A
