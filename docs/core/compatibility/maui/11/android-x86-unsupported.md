---
title: "Breaking change - Android x86 is not supported"
description: "Learn about the breaking change in .NET 11 where Android x86 is not supported."
ms.date: 10/21/2026
ai-usage: ai-generated
ms.custom: https://github.com/dotnet/docs/issues/56480
---

# Android x86 is not supported

In .NET 11, Android x86 is not supported.

## Version introduced

.NET 11

## Previous behavior

The Mono runtime had an `android-x86` path for 32-bit x86, so mobile apps could run on Android x86 even though it was not an officially supported platform.

## New behavior

CoreCLR doesn't have an `android-x86` runtime identifier. `android-x64` remains available for x86-64 emulators.

## Type of breaking change

This change affects [binary compatibility](../../categories.md#binary-compatibility) and is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

The .NET 11 Android workload doesn't provide CoreCLR runtime files for 32-bit x86.

## Recommended action

- Move tests to x86-64 emulator images and the `android-x64` RID.
- If you still need 32-bit x86, keep that target on .NET 10.

## Affected APIs

None. This change affects Android runtime identifiers and deployment files.
