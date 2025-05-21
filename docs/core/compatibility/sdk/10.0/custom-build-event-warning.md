---
title: "Breaking change - MSBUILDCUSTOMBUILDEVENTWARNING escape hatch removed"
description: "Learn about the breaking change where the MSBUILDCUSTOMBUILDEVENTWARNING environment variable is no longer supported."
ms.date: 2/25/2025
ai-usage: ai-assisted
ms.custom: https://github.com/dotnet/docs/issues/44998
ms.topic: concept-article
---

# MSBUILDCUSTOMBUILDEVENTWARNING escape hatch removed

The `MSBUILDCUSTOMBUILDEVENTWARNING` environment variable, which previously allowed custom build events derived from <xref:Microsoft.Build.Framework.BuildEventArgs>, is no longer supported.

## Version introduced

.NET 10 Preview 1

## Previous behavior

Users could set the `MSBUILDCUSTOMBUILDEVENTWARNING` environment variable to enable processing of custom build events.

## New behavior

The value of the `MSBUILDCUSTOMBUILDEVENTWARNING` environment variable is not respected anymore.

## Type of breaking change

This is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

The escape hatch mechanism provided by the `MSBUILDCUSTOMBUILDEVENTWARNING` environment variable was a temporary workaround. For more information, see the [original breaking change](../8.0/custombuildeventargs.md).

## Recommended action

Use one of the following newly introduced, built-in events for extensibility instead of your custom derived build event:

- <xref:Microsoft.Build.Framework.ExtendedCustomBuildEventArgs>
- <xref:Microsoft.Build.Framework.ExtendedBuildErrorEventArgs>
- <xref:Microsoft.Build.Framework.ExtendedBuildMessageEventArgs>
- <xref:Microsoft.Build.Framework.ExtendedBuildWarningEventArgs>

## Affected APIs

- <xref:Microsoft.Build.Framework.CustomBuildEventArgs?displayProperty=fullName>
