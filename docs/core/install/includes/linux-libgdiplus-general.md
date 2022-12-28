---
author: adegeo
ms.author: adegeo
ms.date: 12/27/2022
ms.topic: include
---

If the .NET app uses the *System.Drawing.Common* assembly, libgdiplus will also need to be installed. Because [*System.Drawing.Common* is no longer supported on Linux](../../compatibility/core-libraries/6.0/system-drawing-common-windows-only.md), this only works on .NET 6 and requires setting the `System.Drawing.EnableUnixSupport` runtime configuration switch.
