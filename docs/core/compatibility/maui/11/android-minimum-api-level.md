---
title: "Breaking change: Minimum Android API level raised to 24"
description: "Learn about the breaking change in .NET 11 where the minimum supported Android API level has been raised from 21 to 24."
ms.date: 05/04/2026
ai-usage: ai-assisted
---

# Minimum Android API level raised to 24

The minimum supported Android API level for .NET 11 has been raised from 21 (Android 5.0) to 24 (Android 7.0).

## Version introduced

.NET 11 Preview 4

## Previous behavior

Previously, you could target devices running Android API 21 (Android 5.0 Lollipop) or newer.

## New behavior

Starting in .NET 11, devices running Android API 24 (Android 7.0 Nougat) or newer are supported. Apps built with .NET 11 can't be installed or run on devices running Android API 21, 22, or 23.

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

Migrating the Android runtime from Mono to CoreCLR requires Android API 24 or later.

## Recommended action

Set `SupportedOSPlatformVersion` to `24` in your project file so your app declares the correct minimum supported Android version to build analyzers and assembly metadata.

If you set `android:minSdkVersion` manually in your Android manifest, raise that value to `24` too so it matches the project setting.

Notify users on devices that run Android 5.x or 6.x that they won't be able to install new updates of your app.

## Affected APIs

None.
