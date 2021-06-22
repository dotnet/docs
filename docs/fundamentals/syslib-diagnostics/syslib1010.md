---
title: SYSLIB1010 warning
description: Learn about the diagnostic that generates compile-time warning SYSLIB1010.
ms.date: 05/07/2021
---

# SYSLIB1010: Logging methods must be partial

A method annotated with the `LoggerMessageAttribute` is not marked as partial.

## Workarounds

All logging methods must be declared partial.

[!INCLUDE [suppress-syslib-warning](includes/suppress-source-generator-diagnostics.md)]
