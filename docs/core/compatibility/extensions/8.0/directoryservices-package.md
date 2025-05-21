---
title: "Breaking change: DirectoryServices package no longer references System.Security.Permissions"
description: Learn about the .NET 8 breaking change in .NET extensions where the System.DirectoryServices package no longer references the System.Security.Permissions package.
ms.date: 08/22/2023
ms.topic: concept-article
---
# DirectoryServices package no longer references System.Security.Permissions

The `System.DirectoryServices` package no longer references the `System.Security.Permissions` package.

## Version introduced

.NET 8 Preview 3

## Previous behavior

The `System.DirectoryServices` package referenced the `System.Security.Permissions` package.

## New behavior

Starting in .NET 8, the `System.DirectoryServices` package *does not* reference the `System.Security.Permissions` package.

## Type of breaking change

This change can affect [source compatibility](../../categories.md#source-compatibility).

## Reason for change

This change avoids a dependency on `System.Drawing.Common` when `System.DirectoryServices` is referenced, which is primarily an issue for non-Windows operating systems.

The dependency on `System.Drawing.Common` was caused by the following package dependencies:

```txt
System.DirectoryServices
 └──System.Security.Permissions
      └──System.Windows.Extensions
           └──System.Drawing.Common
```

## Recommended action

If your app references the `System.DirectoryServices` package and you also have a dependency on `System.Security.Permissions` or any of its dependencies, which might include `System.Windows.Extensions` or `System.Drawing.Common`, you'll need to reference those packages either directly or indirectly.

## Affected APIs

N/A
