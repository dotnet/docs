---
title: Breaking changes can affect porting your app
description: Breaking changes can occur when porting your code from .NET framework to .NET and between versions of .NET. This article describes categories of breaking changes, ways a change can affect compatibility and how to find breaking changes.
author: StephenBonikowsky
ms.author: stebon
ms.date: 06/14/2021
---
# Breaking changes may occur when porting code

Changes that affect compatibility, otherwise known as breaking changes, will occur between versions of .NET. Changes are impactful when porting from .NET Framework to .NET because of certain technologies not being available. Also, you can come across breaking changes simply because .NET is a cross-platform technology and .NET Framework isn't.

Microsoft strives to maintain a high level of compatibility between .NET versions, so while breaking changes do occur, they're carefully considered.

Before upgrading major versions, check the breaking changes documentation for changes that might affect you.

## Categories of breaking changes

There are several types of breaking changes...

- modifications to the public contract
- behavioral changes
- Platform support
- Internal implementation changes
- Code changes

For more information about what is allowed or disallowed, see [Changes that affect compatibility](../compatibility/index.md)

## Types of compatibility

Compatibility refers to the ability to compile or run code on a .NET implementation other than the one with which the code was originally developed.

There are six different ways a change can affect compatibility...

- Behavioral changes
- Binary compatibility
- Source compatibility
- Design-time compatibility
- Backwards compatibility
- Forward compatibility

For more information, see [How code changes can affect compatibility](../compatibility/categories.md)

## Find breaking changes

Changes that affect compatibility are documented and should be reviewed before porting from .NET Framework to .NET or when upgrading to a newer version of .NET.

For more information, see [Breaking changes reference overview](../compatibility/breaking-changes.md)
