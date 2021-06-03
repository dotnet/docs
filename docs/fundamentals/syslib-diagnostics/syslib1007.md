---
title: SYSLIB1007 error
description: Learn about the diagnostic that generates compile-time error SYSLIB1007.
ms.date: 05/07/2021
---

# SYSLIB1007: Logging methods must return void

A method annotated with the `LoggerMessageAttribute` attribute returns a value.

## Workarounds

All logging methods must return void.

[!INCLUDE [suppress-syslib-warning](includes/suppress-source-generator-diagnostics.md)]
