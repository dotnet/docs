---
title: "Breaking change: EnumConverter validates registered types to be enum"
description: Learn about the .NET 9 breaking change where EnumConverter now validates that the type to be registered is an enum type.
ms.date: 10/04/2024
---
# EnumConverter validates registered types to be enum

<xref:System.ComponentModel.EnumConverter> is a type converter that converts to and from an `enum` type. EnumConverter now validates that the type to be registered is of an `enum` type.

## Previous behavior

Previously, the type to be registered was not validated to be an `enum` type.

## New behavior

Starting in .NET 9, <xref:System.ComponentModel.EnumConverter> throws an <xref:System.ArgumentException> if the type to be converted is not an `enum` type. Any derived classes of <xref:System.ComponentModel.EnumConverter> should also respect this requirement.

## Version introduced

.NET 9 Preview 7

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

It is logical to enforce the requirement that <xref:System.ComponentModel.EnumConverter> be used to convert to and from `enum` types only. It was likely an oversight that this requirement wasn't added earlier.

However, the primary driving factor for this change was for trimming purposes. [Trimming](../../../deploying/trimming/prepare-libraries-for-trimming.md) doesn't trim `enum` types, but using <xref:System.ComponentModel.EnumConverter> for `enum` types required <xref:System.Diagnostics.CodeAnalysis.DynamicallyAccessedMembersAttribute> annotation for an `enum` type. This means that using `EnumConverter` generates unnecessary trim warnings. A recent change removed the annotation requirement. Part of the reason for that change was to enforce that `EnumConverter` only be used with `enums`.

## Recommended action

There is no easy workaround if an <xref:System.ComponentModel.EnumConverter> is used to convert to and from a non-`enum` type.

## Affected APIs

- <xref:System.ComponentModel.EnumConverter.%23ctor(System.Type)> constructor
