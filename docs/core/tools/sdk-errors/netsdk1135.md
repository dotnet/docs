---
title: "NETSDK1135: SupportedOSPlatformVersion can't be higher than TargetPlatformVersion"
description: How to resolve the `SupportedOSPlatformVersion can't be higher than TargetPlatformVersion' error.
ms.topic: error-reference
ms.date: 07/08/2022
f1_keywords:
- NETSDK1135
---
# NETSDK1135: SupportedOSPlatformVersion can't be higher than TargetPlatformVersion

The value that your project file specifies for `SupportedOSPlatformVersion` is too high. The full error message is similar to the following example:

> SupportedOSPlatformVersion `<Version>` cannot be higher than `TargetPlatformVersion` `<Version>`.

Check your project files for `SupportedOSPlatformVersion`. `TargetPlatformVersion` (TPV) is inferred from the `TargetFramework` value. For example, `net6.0-windows10.0.19041` will set the TPV to be `10.0.19041`. .NET uses `TargetPlatformVersion` to determine which APIs are available at compile time.
