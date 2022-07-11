---
title: "NETSDK1100: The target framework is out of support"
description: How to resolve the `framework out of support' error message.
author: tdykstra
ms.author: tdykstra
ms.topic: error-reference
ms.date: 07/08/2022
f1_keywords:
- NETSDK1100
---
# NETSDK1100: The target framework is out of support

NETSDK1100 indicates that you're building a project that targets Windows on Linux or macOS. The full error message is similar to the following example:

> To build a project targeting Windows on this operating system, set the `EnableWindowsTargeting` property to true.

To resolve this error, set the `EnableWindowsTargeting` property to true.

By default, we download all targeting packs (and runtime packs for self-contained builds) for the current target framework whether they are needed or not, because they might be brought in by a transitive framework reference. We didn't want to ship the Windows targeting packs with the non-Windows SDK builds, but we also didn't want a vanilla Console or ASP.NET Core app to automatically download these targeting and runtime packs the first time you build. The `EnableWindowsTargeting` property enables them to only be downloaded if you opt in.
