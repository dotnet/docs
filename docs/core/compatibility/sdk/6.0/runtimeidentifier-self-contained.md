---
title: "Breaking change: `RuntimeIdentifier` warning if self-contained is unspecified"
description: Learn about the breaking change in .NET 6 where specifying a `RuntimeIdentifier` without specifying whether an app is self-contained results in a warning.
ms.date: 09/20/2021
---
# RuntimeIdentifier warning if self-contained is unspecified

If you specify a `RuntimeIdentifier` in your project file or use the `-r` option with `dotnet`, the .NET SDK defaults the build, publish, and run outputs to be self-contained applications. The default without specifying a `RuntimeIdentifier` is to have a framework-dependent application. This change introduces a new warning (NETSDK1179) if you specify a `RuntimeIdentifier` without specifying whether the application is self-contained.

## Version introduced

.NET 6 RC 1

## Previous behavior

In previous versions, specifying a `RuntimeIdentifier` would silently change the application from a framework-dependent application to a self-contained application.

## New behavior

In .NET 6, if you specify a `RuntimeIdentifier` without specifying whether the application is self-contained, you'll get the following warning:

**warning NETSDK1179: One of '--self-contained' or '--no-self-contained' options are required when '--runtime' is used.**

For example, the following command will generate the warning:

```dotnetcli
dotnet publish -r win-x86
```

## Change category

This change may affect [*source compatibility*](../../categories.md#source-compatibility).

## Reason for change

The default without specifying a `RuntimeIdentifier` is to generate a framework-dependent application. This default caused confusion for many customers. The purpose of adding the warning is to:

- Warn customers of the behavior change to default to a framework-dependent app.
- Encourage customers to specifically choose the type of application they want to build.
- Prepare customers for possibly changing the behavior in .NET 7 to default to framework-dependent.

## Recommended action

- Specify a boolean value in your project file for `SelfContained`.
- Or, add `--sc` with a value to your build or publish command.

## Affected APIs

N/A
