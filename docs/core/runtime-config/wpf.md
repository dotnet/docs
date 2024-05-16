---
title: WPF config settings
description: Learn about the settings that configure WPF for .NET apps.
ms.date: 09/08/2023
---
# Runtime configuration options for WPF

This article details the settings you can use to configure Windows Presentation Framework (WPF) in .NET.

[!INCLUDE [complus-prefix](../../../includes/complus-prefix.md)]

## Hardware acceleration in RDP

- Configures whether hardware acceleration is used for WPF apps that are accessed through Remote Desktop Protocol (RDP). Hardware acceleration refers to the use of a computer's graphics processing unit (GPU) to speed up the rendering of graphics and visual effects in an application. This can result in improved performance and more seamless, responsive graphics.
- If you omit this setting, graphics are rendered by software instead. This is equivalent to setting the value to `false`.

| Setting type | Setting name | Values | Version introduced |
|--------------|--------------|--------|--------------------|
| **runtimeconfig.json** | `Switch.System.Windows.Media.EnableHardwareAccelerationInRdp` | `true` - enabled<br/>`false` - disabled | .NET 8 |
| **Environment variable** | N/A | | |

[!INCLUDE [runtimehostconfigurationoption](includes/runtimehostconfigurationoption.md)]
