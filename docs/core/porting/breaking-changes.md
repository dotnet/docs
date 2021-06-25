---
title: Breaking changes
description: Breaking changes between releases of .NET and how it impacts compatibility.
author: stebon
ms.date: 06/14/2021
---
# Breaking Changes

Changes that affect compatibility, otherwise known as breaking changes, will occur between versions of .NET. This is particularly impactful when porting from .NET Framework to .NET due to certain technologies not being available as well as the effort to make .NET a cross-platform framework.
We strive to maintain a high level of compatibility between .NET versions, so while breaking changes will occur, they are carefully considered.
Before upgrading major versions check the breaking changes documentation for changes that might impact you.

## Categories of breaking changes.

For types of breaking changes such as modifications to the public contract or behavioral changes and what is allowed or disallowed see [Changes that affect compatibility](../compatibility/index.md)

## Types of compatibility.

Compatibility refers to the ability to compile or execute code on a version of a .NET implementation other than the one with which the code was originally developed. For details on the six different ways a change can affect compatibility see [How code changes can affect compatibility](../compatibility/categories.md)

## Find breaking changes.

Changes that affect compatibility are documented and should be reviewed before porting from .NET Framework to .NET or when upgrading to a newer version of .NET.
All breaking change documentation can be seen at [Breaking changes reference overview](../compatibility/breaking-changes.md)
