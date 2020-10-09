---
title: "NETSDK1005 and NETSDK1047: Asset file is missing target"
description: How to resolve the issue of an asset file missing a target
author: sfoslund
ms.topic: error-reference
ms.date: 10/09/2020
f1_keywords:
- NETSDK1005
- NETSDK1047
---
# NETSDK1005 and NETSDK1047: Asset file is missing target

**This article applies to:** ✔️ .NET 2.1.100 SDK and later versions

When the .NET SDK issues error NETSDK1005 or NETSDK1047, the project's assets file is missing information on one of your target frameworks. This can usually be fixed by ensuring that restore is run and that the missing target value is included in the `TargetFrameworks` property of your project.

> [!NOTE]
> There was a known issue with early builds of .NET 5 preview 8 when used with versions of Visual Studio 16.8 previews which resulted in this error. Specifically, if the missing target is `net5.0-windows7.0` or `net5.0`, please ensure that you have updated to the latest versions of Visual Studio and the .NET 5 SDK.
