---
title: "Breaking change: MSBuild 17 doesn't support GetType()"
description: Learn about the breaking change in the .NET 6 SDK where it's no longer supported to call GetType() within MSBuild property functions.
ms.date: 09/13/2021
---
# MSBuild no longer supports calling GetType()

MSBuild 17 no longer supports calling the `GetType()` instance method within property functions. This method allowed unpredictable code execution during evaluation and could cause Visual Studio hangs.

## Version introduced

.NET SDK 6.0.100-rc1

## Previous behavior

`GetType()` calls in MSBuild property functions would execute and sometimes caused unpredictable behavior in Visual Studio.

## New behavior

Starting with the .NET 6 SDK, if you call `GetType()` in an MSBuild property function, you'll see the following compile-time error during project evaluation:

**The function "GetType" on type "System.String" is not available for execution as an MSBuild property function.**

## Change category

This change affects [*source compatibility*](../../categories.md#source-compatibility).

## Reason for change

This functionality was not documented or commonly used. It caused performance and reliability issues with project loading, especially in Visual Studio.

The only known common use of this pattern was in the [CBT system](https://commonbuildtoolset.github.io/), which has been deprecated.

## Recommended action

Replace any calls to `GetType()` with alternative MSBuild logic.

## Affected APIs

N/A
