---
title: SYSLIB1009 warning
description: Learn about the diagnostic that generates compile-time warning SYSLIB1009.
ms.date: 05/07/2021
---

# SYSLIB1009: Logging methods must be static

A method annotated with the `LoggerMessageAttribute` is not static.

## Workarounds

All logging methods must be declared as static.

[!INCLUDE [suppress-syslib-warning](includes/suppress-source-generator-diagnostics.md)]
