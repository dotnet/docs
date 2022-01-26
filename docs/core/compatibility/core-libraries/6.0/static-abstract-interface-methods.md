---
title: "Breaking change: Static abstract members in interfaces"
description: Learn about the .NET 6 breaking change where `static` interface members can now be marked `abstract`.
ms.date: 09/08/2021
---
# Static abstract members in interfaces

.NET 6 is previewing a new feature where `static` interface members can be marked as `abstract`. This feature involves several changes to the ECMA 335 spec to allow intermediate language (IL) metadata patterns that were previously considered illegal. For more information, see [dotnet/runtime#49558](https://github.com/dotnet/runtime/issues/49558).

> [!NOTE]
> The feature is in preview, and it's possible that additional changes or support may be introduced between .NET 6 and a future version of .NET when the feature stabilizes.

## Old behavior

If a static interface was marked as `abstract`:

- The C# compiler generated [error CS0112](../../../../csharp/misc/cs0112.md).
- Tools and other compilers generated illegal IL metadata.

## New behavior

Starting in .NET 6, static interface members can be marked as `abstract` and will compile successfully. In addition, the IL metadata patterns that are generated are now considered legal due to changes in the ECMA 335 spec.

The implementation of `static abstract` interface members is provided by types that implement the interface.

> [!NOTE]
> For .NET 6, you must [enable preview features](../../../project-sdk/msbuild-props.md#enablepreviewfeatures) in your project to be able to mark an interface member as `static abstract`.

Since this is a newly legal IL pattern, existing tooling may incorrectly process the associated metadata and have unexpected behavior. It's likely that tooling will encounter the new metadata pattern, because interfaces with `static abstract` members now appear on the primitive types, for example, <xref:System.Int32?displayProperty=fullName>.

## Version introduced

.NET 6

## Type of breaking change

This change can affect [binary compatibility](../../categories.md#binary-compatibility).

## Reason for change

This change was introduced because there was no way to abstract over static members and write generalized code that applies across types that define those static members. This was particularly problematic for member kinds that only exist in a static form, for example, operators.

## Recommended action

Update any tooling that consumes .NET binaries or C# source code to account for the new concept of `static abstract` interface members, including those that now exist on the .NET primitive types.

## Affected APIs

N/A
