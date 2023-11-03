---
title: "Breaking change: System.Windows.Extensions doesn't reference System.Drawing.Common"
description: Learn about the breaking change in .NET 8 where the System.Windows.Extensions package no longer references System.Drawing.Common.
ms.date: 11/03/2023
---
# System.Windows.Extensions doesn't reference System.Drawing.Common

The [System.Windows.Extensions package](https://www.nuget.org/packages/System.Windows.Extensions) no longer references the [System.Drawing.Common](https://www.nuget.org/packages/System.Drawing.Common) package.

## Version introduced

.NET 8 Preview 7

## Previous behavior

Previously, the System.Windows.Extensions package referenced the System.Drawing.Common package.

## New behavior

Starting in .NET 8, the System.Windows.Extensions package no longer references the System.Drawing.Common package. If you depended on the System.Windows.Extensions package bringing in System.Drawing.Common, you might see a compilation error similar to this (but not necessarily for <xref:System.Drawing.FontConverter>):

> **error CS1069: The type name 'FontConverter' could not be found in the namespace 'System.Drawing'. This type has been forwarded to assembly 'System.Drawing.Common, Version=0.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51' Consider adding a reference to that assembly.**

## Change category

This change can affect [*source compatibility*](../../categories.md#source-compatibility).

## Reason for change

This change avoids a dependency on System.Drawing.Common when System.Windows.Extensions is referenced.

This change helps more components remove a dependency on System.Drawing.Common unless they actually need it. For more information, see [dotnet/msbuild issue 8962](dotnet/msbuild#8962).

## Recommended action

If you still need to use System.Drawing.Common, add a direct reference.

## Affected APIs

N/A
